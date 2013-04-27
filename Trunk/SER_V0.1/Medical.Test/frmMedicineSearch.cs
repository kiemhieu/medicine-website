using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Repositories;

namespace Medical.Test
{
    public partial class frmMedicineSearch : Form
    {
        private MedicineRepository reposioryMedicine;
        public frmMedicineSearch()
        {
            reposioryMedicine = new MedicineRepository();
            InitializeComponent();
        }
        public frmMedicineSearch(string sMa,string sTen)
            : this()
        {
            this.txtMaThuoc.Text = sMa;
            this.txtTenThuoc.Text = sTen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = reposioryMedicine.GetByName(txtTenThuoc.Text.Trim());
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmWareHouseDetail frmWHDetail = new frmWareHouseDetail();
            frmWHDetail.IdMedicine = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            frmWHDetail.medicineName = grd.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
            this.Close();
        }
    }
}
