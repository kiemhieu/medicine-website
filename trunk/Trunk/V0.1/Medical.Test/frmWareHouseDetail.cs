using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Test
{
    public partial class frmWareHouseDetail : DockContent
    {
        public int IdWareHouseDetail;
        private WareHouseDetailRepository whDetailRepository = new WareHouseDetailRepository();
        public frmWareHouseDetail()
        {
            InitializeComponent();
            FillToGrid();
        }
        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            lblID.Text = grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString();

        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null)
            {
                IdWareHouseDetail = 0;
            }

            else
            {
                IdWareHouseDetail = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            }
            lblID.Text = IdWareHouseDetail.ToString();

            frmWareHouseDetailEdit.IdWhDetailEdit = IdWareHouseDetail;
            frmWareHouseDetailEdit frmEdit = new frmWareHouseDetailEdit();
            frmEdit.ShowDialog();
            FillToGrid();
        }
        private void FillToGrid()
        {

            bindingSource1.DataSource = whDetailRepository.GetAll();
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
            frmWareHouseDetailEdit frmedit = new frmWareHouseDetailEdit();
            frmWareHouseDetailEdit.IdWhDetailEdit = 0;
            frmedit.ShowDialog();
            FillToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn phòng khám cần xóa!");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa phòng khám này không?", "Xóa phòng khám", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                whDetailRepository.Delete(int.Parse(lblID.Text.Trim()));
            }
            FillToGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn phòng khám cần sửa!");
                return;
            }
            frmWareHouseDetailEdit.IdWhDetailEdit = int.Parse(lblID.Text);
            frmWareHouseDetailEdit frmedit = new frmWareHouseDetailEdit();
            frmedit.ShowDialog();
            FillToGrid();

        }
    }
}
