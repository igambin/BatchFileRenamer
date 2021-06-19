using System.Windows.Forms;

namespace BatchFileRenamer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openInputFolder = new System.Windows.Forms.Button();
            this.workfolder = new System.Windows.Forms.TextBox();
            this.reloadButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSimple = new System.Windows.Forms.TabPage();
            this.simpleReplace = new System.Windows.Forms.Button();
            this.simplePreview = new System.Windows.Forms.Button();
            this.cbSimpleReplace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSimpleSearch = new System.Windows.Forms.ComboBox();
            this.tabRegex = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.regexReplace = new System.Windows.Forms.Button();
            this.cbRegexSearch = new System.Windows.Forms.ComboBox();
            this.regexPreview = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.cbRegexReplace = new System.Windows.Forms.ComboBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.hideSaveResetHint = new System.Windows.Forms.CheckBox();
            this.autoPreview = new System.Windows.Forms.CheckBox();
            this.prefilterByExtension = new System.Windows.Forms.CheckBox();
            this.wannaReally = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.extensionPreFilter = new System.Windows.Forms.TextBox();
            this.ignoreCase = new System.Windows.Forms.CheckBox();
            this.recursionLvl = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.selectOutputFolder = new System.Windows.Forms.Button();
            this.outputFolder = new System.Windows.Forms.TextBox();
            this.enableAlternateOutputFolder = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveChanges = new System.Windows.Forms.Button();
            this.resetChanges = new System.Windows.Forms.Button();
            this.saveresetHint = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabSimple.SuspendLayout();
            this.tabRegex.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recursionLvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openInputFolder
            // 
            this.openInputFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.openInputFolder.Image = ((System.Drawing.Image)(resources.GetObject("openInputFolder.Image")));
            this.openInputFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openInputFolder.Location = new System.Drawing.Point(12, 12);
            this.openInputFolder.Name = "openInputFolder";
            this.openInputFolder.Size = new System.Drawing.Size(130, 25);
            this.openInputFolder.TabIndex = 0;
            this.openInputFolder.Text = "Open Input Folder";
            this.openInputFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openInputFolder.UseVisualStyleBackColor = true;
            this.openInputFolder.Click += new System.EventHandler(this.openInputFolder_Click);
            // 
            // workfolder
            // 
            this.workfolder.AllowDrop = true;
            this.workfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workfolder.Location = new System.Drawing.Point(148, 13);
            this.workfolder.Name = "workfolder";
            this.workfolder.ReadOnly = true;
            this.workfolder.Size = new System.Drawing.Size(560, 23);
            this.workfolder.TabIndex = 1;
            this.workfolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadButton.Location = new System.Drawing.Point(714, 12);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(54, 25);
            this.reloadButton.TabIndex = 2;
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSimple);
            this.tabControl1.Controls.Add(this.tabRegex);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 401);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(759, 102);
            this.tabControl1.TabIndex = 3;
            // 
            // tabSimple
            // 
            this.tabSimple.Controls.Add(this.simpleReplace);
            this.tabSimple.Controls.Add(this.simplePreview);
            this.tabSimple.Controls.Add(this.cbSimpleReplace);
            this.tabSimple.Controls.Add(this.label2);
            this.tabSimple.Controls.Add(this.label1);
            this.tabSimple.Controls.Add(this.cbSimpleSearch);
            this.tabSimple.Location = new System.Drawing.Point(4, 24);
            this.tabSimple.Name = "tabSimple";
            this.tabSimple.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimple.Size = new System.Drawing.Size(751, 74);
            this.tabSimple.TabIndex = 0;
            this.tabSimple.Text = "Simple Search";
            this.tabSimple.UseVisualStyleBackColor = true;
            // 
            // simpleReplace
            // 
            this.simpleReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleReplace.Location = new System.Drawing.Point(677, 40);
            this.simpleReplace.Name = "simpleReplace";
            this.simpleReplace.Size = new System.Drawing.Size(63, 24);
            this.simpleReplace.TabIndex = 2;
            this.simpleReplace.Text = "Replace";
            this.simpleReplace.UseVisualStyleBackColor = true;
            this.simpleReplace.Click += new System.EventHandler(this.simpleReplace_Click);
            // 
            // simplePreview
            // 
            this.simplePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simplePreview.Location = new System.Drawing.Point(677, 11);
            this.simplePreview.Name = "simplePreview";
            this.simplePreview.Size = new System.Drawing.Size(63, 24);
            this.simplePreview.TabIndex = 2;
            this.simplePreview.Text = "Preview";
            this.simplePreview.UseVisualStyleBackColor = true;
            // 
            // cbSimpleReplace
            // 
            this.cbSimpleReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSimpleReplace.FormattingEnabled = true;
            this.cbSimpleReplace.Location = new System.Drawing.Point(98, 41);
            this.cbSimpleReplace.Name = "cbSimpleReplace";
            this.cbSimpleReplace.Size = new System.Drawing.Size(573, 23);
            this.cbSimpleReplace.Sorted = true;
            this.cbSimpleReplace.TabIndex = 0;
            this.cbSimpleReplace.SelectedIndexChanged += new System.EventHandler(this.cbSimpleReplace_ValueChanged);
            this.cbSimpleReplace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbSimpleReplace_ValueChanged);
            this.cbSimpleReplace.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ComboBox_MouseWheel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Replace with";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search for";
            // 
            // cbSimpleSearch
            // 
            this.cbSimpleSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSimpleSearch.FormattingEnabled = true;
            this.cbSimpleSearch.Location = new System.Drawing.Point(98, 12);
            this.cbSimpleSearch.Name = "cbSimpleSearch";
            this.cbSimpleSearch.Size = new System.Drawing.Size(573, 23);
            this.cbSimpleSearch.Sorted = true;
            this.cbSimpleSearch.TabIndex = 0;
            this.cbSimpleSearch.SelectedIndexChanged += new System.EventHandler(this.cbSimpleSearch_EvaluateString);
            this.cbSimpleSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbSimpleSearch_EvaluateString);
            this.cbSimpleSearch.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ComboBox_MouseWheel);
            // 
            // tabRegex
            // 
            this.tabRegex.Controls.Add(this.linkLabel1);
            this.tabRegex.Controls.Add(this.regexReplace);
            this.tabRegex.Controls.Add(this.cbRegexSearch);
            this.tabRegex.Controls.Add(this.regexPreview);
            this.tabRegex.Controls.Add(this.linkLabel2);
            this.tabRegex.Controls.Add(this.cbRegexReplace);
            this.tabRegex.Location = new System.Drawing.Point(4, 24);
            this.tabRegex.Name = "tabRegex";
            this.tabRegex.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegex.Size = new System.Drawing.Size(751, 74);
            this.tabRegex.TabIndex = 1;
            this.tabRegex.Text = "Regular Expressions";
            this.tabRegex.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(15, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 15);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Search RegEx";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.searchRegex_LinkClicked);
            // 
            // regexReplace
            // 
            this.regexReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regexReplace.Location = new System.Drawing.Point(676, 40);
            this.regexReplace.Name = "regexReplace";
            this.regexReplace.Size = new System.Drawing.Size(62, 24);
            this.regexReplace.TabIndex = 2;
            this.regexReplace.Text = "Replace";
            this.regexReplace.UseVisualStyleBackColor = true;
            this.regexReplace.Click += new System.EventHandler(this.regexReplace_Click);
            // 
            // cbRegexSearch
            // 
            this.cbRegexSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRegexSearch.FormattingEnabled = true;
            this.cbRegexSearch.Location = new System.Drawing.Point(98, 12);
            this.cbRegexSearch.Name = "cbRegexSearch";
            this.cbRegexSearch.Size = new System.Drawing.Size(572, 23);
            this.cbRegexSearch.Sorted = true;
            this.cbRegexSearch.TabIndex = 0;
            this.cbRegexSearch.SelectedIndexChanged += new System.EventHandler(this.cbRegexSearch_EvaluateExpression);
            this.cbRegexSearch.Enter += new System.EventHandler(this.cbRegexSearch_EvaluateExpression);
            this.cbRegexSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbRegexSearch_EvaluateExpression);
            this.cbRegexSearch.Leave += new System.EventHandler(this.cbRegexSearch_EvaluateExpression);
            this.cbRegexSearch.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ComboBox_MouseWheel);
            // 
            // regexPreview
            // 
            this.regexPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regexPreview.Location = new System.Drawing.Point(676, 11);
            this.regexPreview.Name = "regexPreview";
            this.regexPreview.Size = new System.Drawing.Size(62, 24);
            this.regexPreview.TabIndex = 2;
            this.regexPreview.Text = "Preview";
            this.regexPreview.UseVisualStyleBackColor = true;
            this.regexPreview.Click += new System.EventHandler(this.regexPreview_Click);
            // 
            // label3
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(3, 44);
            this.linkLabel2.Name = "label3";
            this.linkLabel2.Size = new System.Drawing.Size(89, 15);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.Text = "Replace pattern";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.regexReplace_LinkClicked);
            // 
            // cbRegexReplace
            // 
            this.cbRegexReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRegexReplace.FormattingEnabled = true;
            this.cbRegexReplace.Location = new System.Drawing.Point(98, 41);
            this.cbRegexReplace.Name = "cbRegexReplace";
            this.cbRegexReplace.Size = new System.Drawing.Size(572, 23);
            this.cbRegexReplace.Sorted = true;
            this.cbRegexReplace.TabIndex = 0;
            this.cbRegexReplace.SelectedIndexChanged += new System.EventHandler(this.cbRegexReplace_ValueChanged);
            this.cbRegexReplace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbRegexReplace_ValueChanged);
            this.cbRegexReplace.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ComboBox_MouseWheel);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.hideSaveResetHint);
            this.tabSettings.Controls.Add(this.autoPreview);
            this.tabSettings.Controls.Add(this.prefilterByExtension);
            this.tabSettings.Controls.Add(this.wannaReally);
            this.tabSettings.Controls.Add(this.label6);
            this.tabSettings.Controls.Add(this.extensionPreFilter);
            this.tabSettings.Controls.Add(this.ignoreCase);
            this.tabSettings.Controls.Add(this.recursionLvl);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Location = new System.Drawing.Point(4, 24);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(751, 74);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            // 
            // hideSaveResetHint
            // 
            this.hideSaveResetHint.AutoSize = true;
            this.hideSaveResetHint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hideSaveResetHint.Location = new System.Drawing.Point(201, 40);
            this.hideSaveResetHint.Name = "hideSaveResetHint";
            this.hideSaveResetHint.Size = new System.Drawing.Size(132, 19);
            this.hideSaveResetHint.TabIndex = 7;
            this.hideSaveResetHint.Text = "hide SaveReset-Hint";
            this.hideSaveResetHint.UseVisualStyleBackColor = true;
            this.hideSaveResetHint.CheckedChanged += new System.EventHandler(this.hideSaveResetHint_CheckedChanged);
            // 
            // autoPreview
            // 
            this.autoPreview.AutoSize = true;
            this.autoPreview.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.autoPreview.Location = new System.Drawing.Point(16, 40);
            this.autoPreview.Name = "autoPreview";
            this.autoPreview.Size = new System.Drawing.Size(124, 19);
            this.autoPreview.TabIndex = 10;
            this.autoPreview.Text = "automatic preview";
            this.autoPreview.UseVisualStyleBackColor = true;
            this.autoPreview.CheckedChanged += new System.EventHandler(this.autoPreview_CheckedChanged);
            // 
            // prefilterByExtension
            // 
            this.prefilterByExtension.AutoSize = true;
            this.prefilterByExtension.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.prefilterByExtension.Location = new System.Drawing.Point(558, 11);
            this.prefilterByExtension.Name = "prefilterByExtension";
            this.prefilterByExtension.Size = new System.Drawing.Size(15, 14);
            this.prefilterByExtension.TabIndex = 7;
            this.prefilterByExtension.UseVisualStyleBackColor = true;
            this.prefilterByExtension.CheckedChanged += new System.EventHandler(this.prefilterByExtension_CheckedChanged);
            // 
            // wannaReally
            // 
            this.wannaReally.AutoSize = true;
            this.wannaReally.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.wannaReally.Location = new System.Drawing.Point(201, 9);
            this.wannaReally.Name = "wannaReally";
            this.wannaReally.Size = new System.Drawing.Size(137, 19);
            this.wannaReally.TabIndex = 7;
            this.wannaReally.Text = "WannaReally?-Check";
            this.wannaReally.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "pre-filter by file extensions";
            // 
            // extensionPreFilter
            // 
            this.extensionPreFilter.Location = new System.Drawing.Point(579, 7);
            this.extensionPreFilter.Name = "extensionPreFilter";
            this.extensionPreFilter.PlaceholderText = "e. g.: MKV;MP4;AVI";
            this.extensionPreFilter.Size = new System.Drawing.Size(157, 23);
            this.extensionPreFilter.TabIndex = 8;
            this.extensionPreFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.extensionPreFilter_KeyUp);
            // 
            // ignoreCase
            // 
            this.ignoreCase.AutoSize = true;
            this.ignoreCase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ignoreCase.Location = new System.Drawing.Point(54, 9);
            this.ignoreCase.Name = "ignoreCase";
            this.ignoreCase.Size = new System.Drawing.Size(86, 19);
            this.ignoreCase.TabIndex = 7;
            this.ignoreCase.Text = "ignore case";
            this.ignoreCase.UseVisualStyleBackColor = true;
            // 
            // recursionLvl
            // 
            this.recursionLvl.Location = new System.Drawing.Point(558, 39);
            this.recursionLvl.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recursionLvl.Name = "recursionLvl";
            this.recursionLvl.Size = new System.Drawing.Size(36, 23);
            this.recursionLvl.TabIndex = 5;
            this.recursionLvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.recursionLvl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "subfolder recursion-depth ";
            // 
            // selectOutputFolder
            // 
            this.selectOutputFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.selectOutputFolder.Image = ((System.Drawing.Image)(resources.GetObject("selectOutputFolder.Image")));
            this.selectOutputFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectOutputFolder.Location = new System.Drawing.Point(44, 42);
            this.selectOutputFolder.Name = "selectOutputFolder";
            this.selectOutputFolder.Size = new System.Drawing.Size(98, 25);
            this.selectOutputFolder.TabIndex = 0;
            this.selectOutputFolder.Text = "Output Root";
            this.selectOutputFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectOutputFolder.UseVisualStyleBackColor = true;
            this.selectOutputFolder.Click += new System.EventHandler(this.selectOutputFolder_Click);
            // 
            // outputFolder
            // 
            this.outputFolder.AllowDrop = true;
            this.outputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFolder.Location = new System.Drawing.Point(148, 44);
            this.outputFolder.Name = "outputFolder";
            this.outputFolder.ReadOnly = true;
            this.outputFolder.Size = new System.Drawing.Size(560, 23);
            this.outputFolder.TabIndex = 1;
            this.outputFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            // 
            // enableAlternateOutputFolder
            // 
            this.enableAlternateOutputFolder.AutoSize = true;
            this.enableAlternateOutputFolder.Location = new System.Drawing.Point(22, 47);
            this.enableAlternateOutputFolder.Name = "enableAlternateOutputFolder";
            this.enableAlternateOutputFolder.Size = new System.Drawing.Size(15, 14);
            this.enableAlternateOutputFolder.TabIndex = 5;
            this.enableAlternateOutputFolder.UseVisualStyleBackColor = true;
            this.enableAlternateOutputFolder.CheckedChanged += new System.EventHandler(this.enableAlternateOutputFolder_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(755, 316);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            // 
            // saveChanges
            // 
            this.saveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveChanges.BackColor = System.Drawing.Color.Honeydew;
            this.saveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveChanges.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.saveChanges.ForeColor = System.Drawing.Color.DarkGreen;
            this.saveChanges.Location = new System.Drawing.Point(693, 509);
            this.saveChanges.Name = "saveChanges";
            this.saveChanges.Size = new System.Drawing.Size(75, 40);
            this.saveChanges.TabIndex = 6;
            this.saveChanges.Text = "Save Changes";
            this.saveChanges.UseVisualStyleBackColor = false;
            this.saveChanges.Visible = false;
            this.saveChanges.Click += new System.EventHandler(this.saveChanges_Click);
            // 
            // resetChanges
            // 
            this.resetChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetChanges.BackColor = System.Drawing.SystemColors.Control;
            this.resetChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetChanges.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resetChanges.ForeColor = System.Drawing.Color.Brown;
            this.resetChanges.Location = new System.Drawing.Point(12, 509);
            this.resetChanges.Name = "resetChanges";
            this.resetChanges.Size = new System.Drawing.Size(75, 40);
            this.resetChanges.TabIndex = 6;
            this.resetChanges.Text = "Reset";
            this.resetChanges.UseVisualStyleBackColor = false;
            this.resetChanges.Visible = false;
            this.resetChanges.Click += new System.EventHandler(this.resetChanges_Click);
            // 
            // saveresetHint
            // 
            this.saveresetHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveresetHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saveresetHint.Enabled = false;
            this.saveresetHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveresetHint.Location = new System.Drawing.Point(93, 510);
            this.saveresetHint.Multiline = true;
            this.saveresetHint.Name = "saveresetHint";
            this.saveresetHint.ReadOnly = true;
            this.saveresetHint.Size = new System.Drawing.Size(594, 38);
            this.saveresetHint.TabIndex = 7;
            this.saveresetHint.Text = resources.GetString("saveresetHint.Text");
            this.saveresetHint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.saveresetHint.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.saveresetHint);
            this.Controls.Add(this.resetChanges);
            this.Controls.Add(this.saveChanges);
            this.Controls.Add(this.enableAlternateOutputFolder);
            this.Controls.Add(this.outputFolder);
            this.Controls.Add(this.selectOutputFolder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.workfolder);
            this.Controls.Add(this.openInputFolder);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "File Renamer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSimple.ResumeLayout(false);
            this.tabSimple.PerformLayout();
            this.tabRegex.ResumeLayout(false);
            this.tabRegex.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recursionLvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button openInputFolder;
        private System.Windows.Forms.TextBox workfolder;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSimple;
        private System.Windows.Forms.Button simpleReplace;
        private System.Windows.Forms.Button simplePreview;
        private System.Windows.Forms.ComboBox cbSimpleReplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSimpleSearch;
        private System.Windows.Forms.TabPage tabRegex;
        private System.Windows.Forms.Button regexReplace;
        private System.Windows.Forms.ComboBox cbRegexSearch;
        private System.Windows.Forms.Button regexPreview;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ComboBox cbRegexReplace;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown recursionLvl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox wannaReally;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox extensionPreFilter;
        private System.Windows.Forms.CheckBox ignoreCase;
        private System.Windows.Forms.Button selectOutputFolder;
        private System.Windows.Forms.TextBox outputFolder;
        private System.Windows.Forms.CheckBox enableAlternateOutputFolder;
        private System.Windows.Forms.CheckBox prefilterByExtension;
        private System.Windows.Forms.CheckBox autoPreview;
        private System.Windows.Forms.Button saveChanges;
        private System.Windows.Forms.Button resetChanges;
        private System.Windows.Forms.TextBox saveresetHint;
        private System.Windows.Forms.CheckBox hideSaveResetHint;
        private LinkLabel linkLabel1;
    }
}