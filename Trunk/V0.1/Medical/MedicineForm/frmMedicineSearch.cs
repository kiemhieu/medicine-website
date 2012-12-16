using System;
using System.Windows.Forms;
using Medical.Data.Repositories;
using Medical.Warehouse;

namespace Medical.MedicineForm
{
    public partial class FrmMedicineSearch : Form
    {
        private MedicineRepository reposioryMedicine;
        public int IdMedicine { get; set; }

        public FrmMedicineSearch()
        {
            reposioryMedicine = new MedicineRepository();
            InitializeComponent();
        }
        public FrmMedicineSearch(string sMa,string sTen)
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
            //frmWareHouseDetail frmWHDetail = new frmWareHouseDetail();
            IdMedicine = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());//frmWHDetail.IdMedicine = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            //frmWHDetail.medicineName = grd.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
            this.Close();
        }
    }
}
