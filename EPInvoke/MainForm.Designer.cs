namespace EPInvoke
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button browseButton;
            System.Windows.Forms.ColumnHeader fNameColumnHeader;
            System.Windows.Forms.ColumnHeader fTimeColumnHeader;
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fListView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            browseButton = new System.Windows.Forms.Button();
            fNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            fTimeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            browseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            browseButton.Location = new System.Drawing.Point(336, 3);
            browseButton.Name = "browseButton";
            browseButton.Size = new System.Drawing.Size(80, 24);
            browseButton.TabIndex = 2;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fNameColumnHeader
            // 
            fNameColumnHeader.Text = "File";
            fNameColumnHeader.Width = 182;
            // 
            // fTimeColumnHeader
            // 
            fTimeColumnHeader.Text = "Time";
            fTimeColumnHeader.Width = 112;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // pathBox
            // 
            this.pathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pathBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "Path", true));
            this.pathBox.Location = new System.Drawing.Point(43, 5);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(287, 20);
            this.pathBox.TabIndex = 1;
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataSource = typeof(EPInvoke.State);
            // 
            // fListView
            // 
            this.fListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            fNameColumnHeader,
            fTimeColumnHeader});
            this.tableLayoutPanel1.SetColumnSpan(this.fListView, 3);
            this.fListView.FullRowSelect = true;
            this.fListView.HideSelection = false;
            this.fListView.Location = new System.Drawing.Point(3, 33);
            this.fListView.Name = "fListView";
            this.fListView.Size = new System.Drawing.Size(413, 405);
            this.fListView.TabIndex = 4;
            this.fListView.UseCompatibleStateImageBehavior = false;
            this.fListView.View = System.Windows.Forms.View.Details;
            this.fListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.fListView_ColumnClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.Controls.Add(this.fListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pathBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(browseButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(419, 441);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Explicit P/Invoke 16";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.ListView fListView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource stateBindingSource;
    }
}

