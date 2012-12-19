using System.Windows.Forms;
using Medical.Data.Repositories;
using Medical.Data.Entities;

namespace Medical.Warehouse
{
    public partial class frmWareHouseEdit : Form
    {
        public int WareHouseID { get; set; }
        public int MedicineID { get; set; }

        MedicineRepository medicineRepository = new MedicineRepository();
        public frmWareHouseEdit(int wareHouseID = 0, int medicineID = 0)
        {
            InitializeComponent();
            this.WareHouseID = wareHouseID;
            this.MedicineID = medicineID;
            LoadMedicine();
        }

        private void LoadMedicine()
        {
            cboMedicine.DataSource = medicineRepository.GetAll();
            cboMedicine.DisplayMember = "Name";
            cboMedicine.ValueMember = "Id";

            if (MedicineID > 0)
            {
                cboMedicine.SelectedIndex = GetComboIndex(cboMedicine, MedicineID);
            }
        }

        private int GetComboIndex(ComboBox cbo, int value)
        {
            int i = 0;
            foreach (Medicine item in cbo.Items)
            {
                if (item.Id == value)
                {
                    return i;
                }

                i++;
            }

            return 0;
        }
    }
}
