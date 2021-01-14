using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BatchFileRenamer.Models;

namespace BatchFileRenamer
{
    public partial class SearchExpressionEditor : Form
    {

        private readonly BindingSource _searchData;
        private readonly BindingSource _replaceData;
        public bool IsRegex { get; }

        public SearchExpressionEditor(BindingSource searchEntries, BindingSource replaceEntries, bool isRegex) 
        {
            IsRegex = isRegex;
            _searchData = searchEntries;
            _replaceData = replaceEntries;
            InitializeComponent();
        }

        private DataGridView InitGridView(BindingSource bs)
        {
            var dgv = new DataGridView();
            dgv.DataSource = bs;
            dgv.Columns[0].DataPropertyName = "Value";
            dgv.Columns[0].Name = "Value";
            dgv.ColumnHeadersVisible = false;
            if (IsRegex)
            {
                // WORK IN PROGRESS:
                //if (dgv == searchGridView)
                //    dgv.CellPainting += SearchDgv_CellPainting;
                //else
                //    dgv.CellPainting += ReplaceDgv_CellPainting;
            }
            return dgv;
        }

        #region Custom Regex CellPainting (TODO)
        private void CellPainting(DataGridView dgv, bool isSearch, object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (dgv.Columns[e.ColumnIndex].Name == "entry")
            {
                string content = @"^[a-z\d]+.?text(\s*)(?<name>\w+){1,2}";
                string[] line = content.Split(',');
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                SizeF[] size = new SizeF[line.Length];
                for (int i = 0; i < line.Length; ++i)
                {
                    size[i] = e.Graphics.MeasureString(line[i], e.CellStyle.Font);
                }

                RectangleF rec = new RectangleF(e.CellBounds.Location, new Size(0, 0));
                using (SolidBrush bblack = new SolidBrush(Color.Black), bred = new SolidBrush(Color.Red))
                {
                    for (int i = 0; i < line.Length; ++i)
                    {
                        rec = new RectangleF(new PointF(rec.Location.X + rec.Width, rec.Location.Y), new SizeF(size[i].Width, e.CellBounds.Height));
                        if (i % 2 == 0)
                        {
                            e.Graphics.DrawString(line[i], e.CellStyle.Font, bred, rec, sf);
                        }
                        else
                        {
                            e.Graphics.DrawString(line[i], e.CellStyle.Font, bblack, rec, sf);
                        }
                    }

                }
                e.Handled = true;
            }

            var r = new Regex(@"\(\?\<\w+\>.+\)");

            var x = new Regex(@"^[a-z\d]+.?text(\s*)(?<gname>\w(?<digits>\d+)){1,2}");
            
        }

        //private void SearchDgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) => CellPainting(searchGridView, true, sender, e);
        //private void ReplaceDgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) => CellPainting(replaceGridView, false, sender, e);
        #endregion
    }
}
