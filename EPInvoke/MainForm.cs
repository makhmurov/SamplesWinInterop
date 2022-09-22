using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EPInvoke.Win32;

namespace EPInvoke
{
    using FindData = Win32.WIN32_FIND_DATA;
    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

    public partial class MainForm : Form
    {
        // App state model
        private State state = new State();

        private List<FindData> files = new List<FindData>();

        public MainForm()
        {
            InitializeComponent();
            //InitListView();

            // Setup file mask to skip Dir, Device amd System records
            state.Mask = FileAttributes.Directory | FileAttributes.Device | FileAttributes.System;
            Console.WriteLine("Mask: 0x{0:X}", state.Mask);

            // Get current work directory
            StringBuilder cd = new StringBuilder((int)Win32.MAX_PATH);
            Win32.GetCurrentDirectory(Win32.MAX_PATH, cd);
            state.Path = cd.ToString();

            // Set binding data source model
            stateBindingSource.DataSource = state;
        }

        private void InitListView()
        {
            fListView.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "File"},
                new ColumnHeader() { Text = "Time"},
            });
        }

        private void ShowFiles()
        {
            // Set current work directory
            Win32.SetCurrentDirectory(state.Path);
            
            files.Clear();

            EnumFiles(files.Add, attrExcludeMask: state.Mask);

            // Custom sort
            // LINQ
            /*
            var nameCmp = new CustomFNameComparer(true);
            var timeCmp = new FileTimeComparer();
            files = files.OrderBy(x => x.cFileName, nameCmp)
                         .ThenBy(x => x.ftCreationTime, timeCmp)
                         .ToList();
            */

            // Sort using Custom Comparer
            var ftCmp = new FindDataComparer();
            files.Sort(ftCmp);

            // Show list on form, fill ListView
            UpdateListView();
        }

        private void EnumFiles(Action<FindData> func,
            string pathMask = "*",
            FileAttributes attrMask = (FileAttributes)(-1),
            FileAttributes attrExcludeMask = 0)
        {
            FindData fData;
            var hf = Win32.FindFirstFile(pathMask, out fData);
            do
            {
                //Console.WriteLine("0x{0:X}", (uint)fData.dwFileAttributes);
                // Ignore files defined by attributes mask
                bool inc = (fData.dwFileAttributes & attrMask) > 0;
                bool exc = (fData.dwFileAttributes & attrExcludeMask) == 0;
                if (inc && exc) func(fData);
            } while (Win32.FindNextFile(hf, out fData));
            Win32.FindClose(hf);
        }

        private void UpdateListView()
        {
            fListView.BeginUpdate();
            fListView.Items.Clear();
            foreach (var item in files)
            {
                fListView.Items.Add(GetListItem(item));
            }
            fListView.EndUpdate();
        }

        private ListViewItem GetListItem(FindData fd)
        {
            var interval = FileTimeToInterval(fd.ftCreationTime);
            var time = DateTime.FromFileTime(interval);
            var item = new ListViewItem(new string[]
            {
                fd.cFileName,
                time.ToString(),
            });
            return item;
        }

        // Evnet handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowFiles();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Display the dialog.
            DialogResult result = folderBrowserDialog.ShowDialog();

            // OK button was pressed.
            if (result == DialogResult.OK)
            {
                state.Path = folderBrowserDialog.SelectedPath;
                Console.WriteLine(state.Path);
            }

            // Update data and view
            ShowFiles();
        }

        private void fListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //e.Column;
        }
    }

    // Helper classes

    public class State : INotifyPropertyChanged
    {
        private string path;

        public string Path {
            get { return path; }
            set { path = value; OnPropertyChanged(); }
        }

        public FileAttributes Mask;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // Comparers

    class CustomFNameComparer : IComparer<string>
    {
        private bool _ignoreCase;
        private Func<string, char> GetLastChar;

        public CustomFNameComparer() { }

        public CustomFNameComparer(bool ignoreCase)
        {
            _ignoreCase = ignoreCase;
            if (ignoreCase)
                GetLastChar = GetLastCharCI;
            else
                GetLastChar = GetLastCharCS;
        }

        string GetTitle(string name)
        {
            var doti = name.IndexOf('.');
            if (doti > 0)
            {
                return name.Substring(0, doti);
            }
            return name;
        }

        private char GetLastCharCS(string s)
        {
            return s[s.Length - 1];
        }

        private char GetLastCharCI(string s)
        {
            var ch = GetLastCharCS(s);
            return Char.ToLower(ch);
        }

        /*
        private char GetLastChar(string s)
        {
            char ch = s[s.Length - 1];
            if (_ignoreCase)
            {
                ch = Char.ToLower(ch);
            }
            return ch;
        }
        */

        public int Compare(string x, string y)
        {
            var el1 = GetTitle(x);
            var el2 = GetTitle(y);
            return GetLastChar(el1) - GetLastChar(el2);
        }
    }

    class FileTimeComparer : IComparer<FILETIME>
    {
        public int Compare(FILETIME x, FILETIME y)
        {
            var xi = FileTimeToInterval(x);
            var yi = FileTimeToInterval(y);
            return xi.CompareTo(yi);
        }
    }

    class FindDataComparer : IComparer<FindData>
    {
        CustomFNameComparer nameCmp;
        FileTimeComparer timeCmp;

        public FindDataComparer(bool ignoreCase = true)
        {
            nameCmp = new CustomFNameComparer(ignoreCase);
            timeCmp = new FileTimeComparer();
        }

        public int Compare(FindData x, FindData y)
        {
            // Step 1: Compare Name using custom Comparer (last char)
            int ret = nameCmp.Compare(x.cFileName, y.cFileName);
            if (ret == 0)
            {
                // Step 2: Compare Time using FileTimeComparer
                ret = timeCmp.Compare(x.ftCreationTime, y.ftCreationTime);
            }
            return ret;
        }
    }
}
