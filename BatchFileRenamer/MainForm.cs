using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BatchFileRenamer.Models;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace BatchFileRenamer
{
    public partial class MainForm : Form
    {

        private readonly CommonOpenFileDialog _openFileDialog = new CommonOpenFileDialog("Open Folder");

        private readonly BindingSource _data = new BindingSource();
        private readonly List<RenameFileInfo> _filesData = new List<RenameFileInfo>();

        private readonly BindingSource _ss = new BindingSource();
        private readonly BindingSource _sr = new BindingSource();
        private readonly BindingSource _rs = new BindingSource();
        private readonly BindingSource _rr = new BindingSource();
        private readonly List<string> _simpleSearchData  = new List<string>();
        private readonly List<string> _simpleReplaceData = new List<string>();
        private readonly List<string> _regexSearchData   = new List<string>();
        private readonly List<string> _regexReplaceData  = new List<string>();

        private bool IsUnsaved { get; set; }
        private string InitialWorkFolder { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

        public MainForm()
        {
            InitializeComponent();
        }

        private int _maxRecursionLevel = 0;
        private void ReadFiles()
        {
            var inputFolder = workfolder.Text;

            _filesData.Clear();

            var di = new DirectoryInfo(inputFolder);
            if(!int.TryParse(recursionLvl.Text, out _maxRecursionLevel))
                _maxRecursionLevel = 0;

            List<string> fileFilters = new List<string>();
            if (prefilterByExtension.Checked && !string.IsNullOrWhiteSpace(extensionPreFilter.Text))
            {
                fileFilters = extensionPreFilter.Text.Split(';')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => $".{x.Trim('*', '.', '?', ' ')}")
                    .ToList();
            }

            ReadFiles(di, di, 0, fileFilters);

            ResetData();
        }

        private void ReadFiles(DirectoryInfo rootPath, DirectoryInfo inputFolder, int subfolderLevel, List<string> fileFilters)
        {

            var files = inputFolder.GetFiles("*", SearchOption.TopDirectoryOnly).AsEnumerable();
            if (fileFilters.Any()) files =
                files.Where(f => fileFilters.Any(
                    ff => ff.Equals(f.Extension, ignoreCase.Checked
                            ? StringComparison.CurrentCultureIgnoreCase
                            : StringComparison.CurrentCulture))
                    );
            _filesData.AddRange(files.Select(f => new RenameFileInfo(f, rootPath)));

            if (subfolderLevel < _maxRecursionLevel)
            {
                var folders = inputFolder.GetDirectories("*", SearchOption.TopDirectoryOnly);
                foreach (var folder in folders)
                {
                    ReadFiles(rootPath, folder, subfolderLevel + 1, fileFilters);
                }
            }
        }
        private void InitCombobox<T>(BindingSource bs, ICollection<T> source, ComboBox c)
        {
            bs.DataSource = source;
            c.DataSource = bs;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitCombobox(_ss, _simpleSearchData, cbSimpleSearch);
            InitCombobox(_sr, _simpleReplaceData, cbSimpleReplace);
            InitCombobox(_rs, _regexSearchData, cbRegexSearch);
            InitCombobox(_rr, _regexReplaceData, cbRegexReplace);
            _data.DataSource = _filesData;
            dataGridView1.DataSource = _data;
            dataGridView1.Columns[0].DataPropertyName = "CurrentName";
            dataGridView1.Columns[0].HeaderText = "Current Name";
            dataGridView1.Columns[1].DataPropertyName = "PreviewName";
            dataGridView1.Columns[1].HeaderText = "Preview";
            dataGridView1.Columns[1].ReadOnly = true; 
            GetSettings();
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            if (!control.DroppedDown) ((HandledMouseEventArgs)e).Handled = true;
        }


        public string EvaluateFolderValue(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var di = new DirectoryInfo(input);
                if (di.Exists)
                {
                    return di.FullName;
                }
                while (!di.Exists && di.Parent != null)
                {
                    di = di.Parent;
                    if (di.Exists)
                    {
                        return di.FullName;
                    }
                }
            }
            return "";
        }

        private void EvaluateOutputFolderState()
        {
            if (enableAlternateOutputFolder.Checked)
            {
                selectOutputFolder.Enabled = true;
                outputFolder.Enabled = true;
            }
            else
            {
                selectOutputFolder.Enabled = false;
                outputFolder.Enabled = false;
            }
        }

        private void GetSettings()
        {
            workfolder.Text = EvaluateFolderValue(Properties.FileRenamer.Default.workfolder);
            enableAlternateOutputFolder.Checked = Properties.FileRenamer.Default.enableOutputFolder;
            autoPreview.Checked = Properties.FileRenamer.Default.autoPreview;
            ignoreCase.Checked = Properties.FileRenamer.Default.ignoreCase;
            wannaReally.Checked = Properties.FileRenamer.Default.wannaReally;
            prefilterByExtension.Checked = Properties.FileRenamer.Default.enableExtensionPreFiltering;
            extensionPreFilter.Text = Properties.FileRenamer.Default.extensionPreFilter ?? "";
            recursionLvl.Value = Properties.FileRenamer.Default.recursionLvl;
            tabControl1.SelectedIndex = Properties.FileRenamer.Default.lastUsedTab;
            hideSaveResetHint.Checked = Properties.FileRenamer.Default.hideSaveReset;

            _simpleSearchData.AddRange((Properties.FileRenamer.Default.simpleSearch ?? new StringCollection()).OfType<string>());
            _simpleReplaceData.AddRange((Properties.FileRenamer.Default.simpleReplace ?? new StringCollection()).OfType<string>());
            _regexSearchData.AddRange((Properties.FileRenamer.Default.regexSearch ?? new StringCollection()).OfType<string>());
            _regexReplaceData.AddRange((Properties.FileRenamer.Default.regexReplace ?? new StringCollection()).OfType<string>());
            _ss.ResetBindings(false);
            _sr.ResetBindings(false);
            _rs.ResetBindings(false);
            _rr.ResetBindings(false);

            EvaluateOutputFolderState();

            if (enableAlternateOutputFolder.Checked)
            {
                outputFolder.Text = EvaluateFolderValue(Properties.FileRenamer.Default.outputfolder);
            }

            simplePreview.Enabled = !autoPreview.Checked;
            regexPreview.Enabled = !autoPreview.Checked;

            if(!string.IsNullOrWhiteSpace(workfolder.Text))
            {
                ReloadFolder();
            }
        }

        private void StoreLists(StringCollection sc, List<string> items)
        {
            if (sc != null && sc.Count > 0)
            {
                sc.Clear();
                sc.AddRange(items.ToArray());
            }

        }
        private void SetSettings()
        {
            Properties.FileRenamer.Default.workfolder = workfolder.Text;
            Properties.FileRenamer.Default.ignoreCase = ignoreCase.Checked;
            Properties.FileRenamer.Default.wannaReally = wannaReally.Checked;
            Properties.FileRenamer.Default.recursionLvl = (int)recursionLvl.Value;
            Properties.FileRenamer.Default.enableOutputFolder = enableAlternateOutputFolder.Checked;
            Properties.FileRenamer.Default.outputfolder = outputFolder.Text;
            Properties.FileRenamer.Default.enableExtensionPreFiltering = prefilterByExtension.Checked;
            Properties.FileRenamer.Default.extensionPreFilter = extensionPreFilter.Text;
            Properties.FileRenamer.Default.autoPreview = autoPreview.Checked;
            Properties.FileRenamer.Default.hideSaveReset = hideSaveResetHint.Checked;
            StoreLists(Properties.FileRenamer.Default.simpleSearch, _simpleSearchData);
            StoreLists(Properties.FileRenamer.Default.simpleReplace, _simpleReplaceData);
            StoreLists(Properties.FileRenamer.Default.regexSearch, _regexSearchData);
            StoreLists(Properties.FileRenamer.Default.regexReplace, _regexReplaceData);
            Properties.FileRenamer.Default.lastUsedTab = tabControl1.SelectedIndex;
            Properties.FileRenamer.Default.Save();
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            // if folder opened && wannaReally => show wannaReally
            // try: if dropped is string && Directory.Exists(droppedData) => load WorkFolder
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => SetSettings();
        
        private void cbRegexSearch_EvaluateExpression(object sender, EventArgs e) => EvaluateExpression(sender, e);

        private Regex SearchExpression = null;

        private void EvaluateExpression(object sender, EventArgs e)
        {
            try
            {
                SearchExpression = new Regex(cbRegexSearch.Text, ignoreCase.Checked ? RegexOptions.IgnoreCase : RegexOptions.None);
                cbRegexSearch.BackColor = System.Drawing.SystemColors.Window;
                regexPreview.Enabled = autoPreview.Checked ? false : true;
                regexReplace.Enabled = true;
                if (autoPreview.Checked)
                {
                    regexPreview_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                SearchExpression = null;
                cbRegexSearch.BackColor = System.Drawing.Color.MistyRose;
                regexPreview.Enabled = false;
                regexReplace.Enabled = false;
            }
        }

        private string SearchString = null;
        private bool _listContainsDuplicateNames;

        private void cbSimpleSearch_EvaluateString(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbSimpleSearch.Text))
            {
                SearchString = cbSimpleSearch.Text;
                simplePreview.Enabled = autoPreview.Checked ? false : true;
                simpleReplace.Enabled = true;
                if (autoPreview.Checked)
                {
                    simpleReplace_Click(sender, e);
                }
            }
            else
            {
                SearchString = null;
                simplePreview.Enabled = false;
                simpleReplace.Enabled = false;
            }
        }

        private void simpleReplace_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && SearchString != null)
            {
                foreach (var f in _filesData)
                {
                    if(f.IsMatch())
                    {
                        f.UpdateNameBySimpleReplace(SearchString, cbSimpleReplace.Text, ignoreCase.Checked);
                        IsUnsaved = true;
                    }
                }
            }
            ResetData();
        }

        private void enableAlternateOutputFolder_CheckedChanged(object sender, EventArgs e)
        {
            EvaluateOutputFolderState();
        }

        private void reloadButton_Click(object sender, EventArgs e) => ReloadFolder();

        private void ReloadFolder()
        {
            if (!string.IsNullOrEmpty(workfolder.Text))
            {
                ReadFiles();
            }
        }

        private void regexPreview_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && SearchExpression != null)
            {
                foreach (var f in _filesData)
                {
                    f.SetMatch(SearchExpression.IsMatch(f.CurrentName));
                    if (f.IsMatch())
                    {
                        f.PreviewName = SearchExpression.Replace(f.CurrentName, cbRegexReplace.Text);
                    }
                    else
                    {
                        f.PreviewName = f.CurrentName;
                    }
                }
            }
            ResetData();
        }

        private void regexReplace_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && SearchExpression != null)
            {
                foreach (var f in _filesData)
                {
                    if (f.IsMatch()) {
                        f.UpdateNameByRegexReplace(SearchExpression, cbRegexReplace.Text);
                        IsUnsaved = true;
                    }
                }
            }
            ResetData();
        }

        private void ResetData()
        {
            _data.ResetBindings(false);
            ResetBottomPane();
        }

        private void ResetBottomPane()
        {
            var isModified = _filesData.Any(f => f.IsModified());
            resetChanges.Visible = saveChanges.Visible = isModified;
            saveresetHint.Visible = isModified && !hideSaveResetHint.Checked;
        }

        private void ConflictingNameCheck()
        {
            _filesData.ForEach(f => f.SetConflicting(false));
            foreach (var grouping in _filesData.GroupBy(f => f.CurrentName).Where(g => g.Count() > 1))
            {
                foreach (var file in grouping)
                {
                    file.SetConflicting(true);
                }
            }
            _listContainsDuplicateNames = _filesData.Any(f => f.IsConflicting());
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ConflictingNameCheck();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var file = row.DataBoundItem as RenameFileInfo;
                if (file == null) continue;
                row.Cells[1].Style.BackColor = file.IsMatch() && !string.Equals(file.CurrentName, file.PreviewName) ? Color.MistyRose : Color.Gainsboro;
                row.Cells[0].Style.BackColor = file.IsConflicting() ? Color.LightCoral : Color.White;
                row.Cells[0].Style.ForeColor = file.IsModified() ? Color.Brown : Color.Black;
            }
        }

        private void autoPreview_CheckedChanged(object sender, EventArgs e)
        {
            simplePreview.Enabled = false;
            regexPreview.Enabled = false;
        }

        private void cbSimpleReplace_ValueChanged(object sender, EventArgs e)
        {
            if (autoPreview.Checked)
            {
                cbSimpleSearch_EvaluateString(sender, e);
            }
        }


        private void cbRegexReplace_ValueChanged(object sender, EventArgs e)
        {
            if (autoPreview.Checked)
            {
                cbRegexSearch_EvaluateExpression(sender, e);
            }
        }

        private void openInputFolder_Click(object sender, EventArgs e)
        {
            var folder = EvaluateFolderValue(workfolder.Text);
            _openFileDialog.InitialDirectory = string.IsNullOrWhiteSpace(folder) ? InitialWorkFolder : folder;
            _openFileDialog.IsFolderPicker = true;
            if(_openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                workfolder.Text = _openFileDialog.FileName;
                ReloadFolder();
            }
        }

        private void selectOutputFolder_Click(object sender, EventArgs e)
        {
            var folder = EvaluateFolderValue(outputFolder.Text);
            _openFileDialog.InitialDirectory = string.IsNullOrWhiteSpace(folder) ? workfolder.Text : folder;
            _openFileDialog.IsFolderPicker = true;
            if (_openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputFolder.Text = _openFileDialog.FileName;
            }
        }

        private void hideSaveResetHint_CheckedChanged(object sender, EventArgs e) => ResetBottomPane();

        private void saveChanges_Click(object sender, EventArgs e)
        {
            if (_listContainsDuplicateNames)
            {
                MessageBox.Show("You can't save your changes at the moment as some files have conflicting names. Please check entries where the 'CurrentName' background color is rendered light red.", "Name Clonflict(s) detected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (wannaReally.Checked
                && MessageBox.Show(
                    "Do you really want to save changes to your file system?",
                    "Save Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            var root = enableAlternateOutputFolder.Checked ? outputFolder.Text : null;
            foreach (var f in _filesData)
            {
                f.ApplyChanges(root);
            }
            if (root != null) workfolder.Text = root;
            ReloadFolder();
        }

        private void resetChanges_Click(object sender, EventArgs e)
        {
            if(   wannaReally.Checked 
               && MessageBox.Show(
                   "Do you really want to reset all changes?", 
                   "Reset Changes", 
                   MessageBoxButtons.YesNo, 
                   MessageBoxIcon.Exclamation, 
                   MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            foreach(var f in _filesData)
            {
                f.ResetName();
            }
            ResetData();
        }

        private void prefilterByExtension_CheckedChanged(object sender, EventArgs e) => ReloadFolder();

        private void extensionPreFilter_KeyUp(object sender, KeyEventArgs e) => ReloadFolder();

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var file = dataGridView1.Rows[e.RowIndex].DataBoundItem as RenameFileInfo;
            if(file.IsModified())
            {
                file.PreviewName = file.CurrentName;
            }
            ResetBottomPane();
        }


        EditorForm _editor;
        List<string> _editorSource;

        private void OpenEditor(List<string> source)
        {
            _editor = new EditorForm(source);
            _editor.CancelButtonClicked += _editor_CancelButtonClicked;
            _editor.SaveButtonClicked += _editor_SaveButtonClicked;
            _editor.ShowDialog();
        }

        private void _editor_SaveButtonClicked(object sender, EventArgs e)
        {
            string[] result = _editor.tbContent.Lines;
            _editorSource.Clear();
            _editorSource.AddRange(result);
            _editor.Close();
        }

        private void _editor_CancelButtonClicked(object sender, EventArgs e)
        {
            _editor.Close();
        }

        private void searchRegex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => OpenEditor(_regexSearchData);
    }
}