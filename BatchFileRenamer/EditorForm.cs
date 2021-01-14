using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BatchFileRenamer
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        public EditorForm(List<string> input)
            : this()
        {
            tbContent.Lines = input.ToArray();
        }

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        private void tsbSaveClicked(object sender, EventArgs e)
        {

            SaveButtonClicked(this, new EventArgs());
        }

        private void tsbCancelClicked(object sender, EventArgs e)
        {
            CancelButtonClicked(this, new EventArgs());
        }
    }
}
