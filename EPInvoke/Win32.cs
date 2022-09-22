using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EPInvoke
{
    internal class Win32
    {
        // Constants

        public static readonly IntPtr InvalidHandleValue = new IntPtr(-1);
        public static readonly uint MAX_PATH = 260;

        // File attribute constants,
        // see: https://learn.microsoft.com/en-us/windows/win32/fileio/file-attribute-constants
        // Same declared in System.IO.FileAttributes
        public const uint FILE_ATTRIBUTE_READONLY       = 0x01;
        public const uint FILE_ATTRIBUTE_HIDDEN         = 0x02;
        public const uint FILE_ATTRIBUTE_SYSTEM         = 0x04;
        public const uint FILE_ATTRIBUTE_DIRECTORY      = 0x10;
        public const uint FILE_ATTRIBUTE_DEVICE         = 0x40;
        public const uint FILE_ATTRIBUTE_NORMAL         = 0x80;
        public const uint FILE_ATTRIBUTE_TEMPORARY      = 0x00000100;
        public const uint FILE_ATTRIBUTE_SPARSE_FILE    = 0x00000200;
        public const uint FILE_ATTRIBUTE_REPARSE_POINT  = 0x00000400;

        // Structures

        // The CharSet must match the CharSet of the corresponding PInvoke signature
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WIN32_FIND_DATA
        {
            public FileAttributes dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
            public uint dwFileType;
            public uint dwCreatorType;
            public uint wFinderFlags;
        }

        // Library Functions

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentDirectory(uint nBufferLength, [Out] StringBuilder lpBuffer);

        [DllImport("kernel32.dll")]
        public static extern bool SetCurrentDirectory(string lpPathName);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll")]
        public static extern bool FindClose(IntPtr hFindFile);

        // Utils

        public static long FileTimeToInterval(System.Runtime.InteropServices.ComTypes.FILETIME fileTime)
        {
            long interval = 0;
            interval |= (uint)fileTime.dwHighDateTime;
            interval <<= sizeof(uint) * 8;
            interval |= (uint)fileTime.dwLowDateTime;
            return interval;
        }
    }
}
