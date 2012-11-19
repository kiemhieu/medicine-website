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
    public partial class frmMedicine : DockContent
    {
        public static int IdMedicine = -1;
        private UserRepository userRepository = new UserRepository();
        private MedicineRepository medicineRepository = new MedicineRepository();
        public frmMedicine()
        {
            InitializeComponent();
           FillToGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //Add add = new Add();
            //add.ShowDialog(this);

            //List<User> users = userRepository.GetAll();
            //this.grd.DataSource = users;
        }
        private void FillToGrid()
        {
            List<Medicine> lstMedicines = medicineRepository.GetAll();
            this.grd.DataSource = lstMedicines;
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
           frmMedicinEdit frmedit = new frmMedicinEdit();
           frmMedicinEdit.IdMedicineEdit = 0;
            frmedit.ShowDialog();
            FillToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn bản thuốc cần xóa!");
                return;
            }
            DialogResult dr =MessageBox.Show("Bạn có muốn xóa thuốc này không?", "Xóa thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                medicineRepository.Delete(int.Parse(lblID.Text.Trim()));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn bản thuốc cần sửa!");
                return;
            }
            frmMedicinEdit.IdMedicineEdit = int.Parse(lblID.Text);
            frmMedicinEdit frmedit = new frmMedicinEdit();
            frmedit.ShowDialog();
            FillToGrid();

        }
      
        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString();
           
        }

      

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null)
            {
                IdMedicine = 0;
            }

            else
            {
                IdMedicine = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            }
            frmMedicinEdit.IdMedicineEdit = IdMedicine;
            frmMedicinEdit frmEdit = new frmMedicinEdit();
            frmEdit.ShowDialog();
            FillToGrid();
        }

        

    }
}
