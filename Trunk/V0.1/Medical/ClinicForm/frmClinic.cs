using System;
using System.Windows.Forms;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.ClinicForm
{
    public partial class frmClinic : DockContent
    {
        public int IdClinic;
        private ClinicRepository clinicRepository = new ClinicRepository();
        public frmClinic()
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
                IdClinic = 0;
            }

            else
            {
                IdClinic = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            }
            lblID.Text = IdClinic.ToString();

            frmClinicEdit.IdClinicEdit = IdClinic;
            frmClinicEdit frmEdit = new frmClinicEdit();
            frmEdit.ShowDialog();
            FillToGrid();
        }
        private void FillToGrid()
        {

            bindingSource1.DataSource = clinicRepository.GetAll();
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
            frmClinicEdit frmedit = new frmClinicEdit();
            frmClinicEdit.IdClinicEdit = 0;
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
                clinicRepository.Delete(int.Parse(lblID.Text.Trim()));
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
            frmClinicEdit.IdClinicEdit = int.Parse(lblID.Text);
            frmClinicEdit frmedit = new frmClinicEdit();
            frmedit.ShowDialog();
            FillToGrid();

        }

       
    }
}
