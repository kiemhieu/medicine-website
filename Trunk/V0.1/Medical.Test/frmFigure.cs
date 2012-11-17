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
using WeifenLuo.WinFormsUI.Docking;
namespace Medical.Test
{
    public partial class frmFigure : DockContent
    {
        public int IdFigure;
        public static int IdMedicine = -1;
        private FigureRepository figureRepository = new FigureRepository();
        public frmFigure()
        {
            InitializeComponent();
           
            FillToGrid();

        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex == -1) return;
            lblID.Text = grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString();
            //foreach (DataGridViewRow row in grd.Rows)
            //{
            //    row.DefaultCellStyle.BackColor = Color.Empty;
            //}
            //grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null)
            {
                IdFigure = 0;
            }

            else
            {
                IdFigure = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            }
            lblID.Text = IdFigure.ToString();

            frmFigureEdit.IdFigureEdit = IdFigure;
            frmFigureEdit frmEdit = new frmFigureEdit();
            frmEdit.ShowDialog();
            FillToGrid();
        }
        private void FillToGrid()
        {
            //List<Figure> lst = figureRepository.GetAll();
            //bindingSource1.DataSource = new List<Figure>();
            bindingSource1.DataSource = figureRepository.GetAll();
            //bindingSource1.ResetBindings(true);
            bindingSource1.ResetCurrentItem();
            //this.grd.DataSource = lst;
            //grd.DataSource = bindingSource1;
            //grd.Update();
            this.grd.Refresh();
            this.grd.Parent.Refresh();
            if (grd.Rows.Count == 0)
            { }
            else
            {

                grd.Rows[0].Selected = true;
                lblID.Text = grd.Rows[0].Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmFigureEdit frmedit = new frmFigureEdit();
            frmFigureEdit.IdFigureEdit = 0;
            frmedit.ShowDialog();
            FillToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn phác đồ thuốc cần xóa!");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa phác đồ này không?", "Xóa phác đồ thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                figureRepository.Delete(int.Parse(lblID.Text.Trim()));
            }
            FillToGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn phác đồ cần sửa!");
                return;
            }
            frmFigureEdit.IdFigureEdit = int.Parse(lblID.Text);
            frmFigureEdit frmedit = new frmFigureEdit();
            frmedit.ShowDialog();
            FillToGrid();

        }
    }
}
