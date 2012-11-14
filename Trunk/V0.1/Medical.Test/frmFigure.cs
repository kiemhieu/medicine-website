using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Entities;
using Medical.Data.Repositories;
namespace Medical.Test
{
    public partial class frmFigure : Form
    {
        public int IdFigure;
        public static int IdMedicine = -1;
        private FigureRepository figureRepository = new FigureRepository();
        public frmFigure()
        {
            InitializeComponent();
        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = grd.Rows[e.RowIndex].Cells["ID"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            foreach (DataGridViewRow row in grd.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Empty;
            }
            grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd.Rows[e.RowIndex].Cells["ID"].Value == null)
            {
                IdFigure = 0;
            }

            else
            {
                IdFigure = int.Parse(grd.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            lblID.Text = IdFigure.ToString();

            frmFigureEdit.IdFigureEdit = IdFigure;
            frmFigureEdit frmEdit = new frmFigureEdit();
            frmEdit.ShowDialog();
            FillToGrid();
        }
        private void FillToGrid()
        {
            List<Figure> lst = figureRepository.GetAll();
            this.grd.DataSource = lst;
            this.grd.Refresh();
            this.grd.Parent.Refresh();
            if (grd.Rows.Count == 0)
            { }
            else
            {

                grd.Rows[0].Selected = true;
                lblID.Text = grd.Rows[0].Cells["ID"].Value.ToString();


            }
        }
    }
}
