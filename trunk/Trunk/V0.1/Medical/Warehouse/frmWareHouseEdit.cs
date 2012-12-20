using System.Windows.Forms;
using Medical.Data.Repositories;
using Medical.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
namespace Medical.Warehouse
{
    public partial class frmWareHouseEdit : Form
    {
        public int WareHouseID { get; set; }
        public int MedicineID { get; set; }
        public int ClinicID { get; set; }
        public bool IsOK { get; set; }
        public int MinAllowed { get; set; }
        MedicineRepository medicineRepository = new MedicineRepository();
        WareHouseRepository whRepository = new WareHouseRepository();
        public frmWareHouseEdit(int clinicID = 0, int wareHouseID = 0, int medicineID = 0, int minAllowed = 0)
        {
            InitializeComponent();
            this.WareHouseID = wareHouseID;
            this.MedicineID = medicineID;
            this.ClinicID = clinicID;
            this.MinAllowed = minAllowed;
            LoadMedicine();
        }

        private void LoadMedicine()
        {
            var list = medicineRepository.GetAll();
            var listTmp = whRepository.GetByClinicId(ClinicID);

            if (MedicineID > 0)
            {
                foreach (var item in listTmp)
                {
                    if (item.MedicineId != MedicineID)
                    {
                        var deleteItem = list.Find(c => c.Id == item.MedicineId);
                        list.Remove(deleteItem);
                    }
                }

                cboMedicine.DataSource = list;
                cboMedicine.DisplayMember = "Name";
                cboMedicine.ValueMember = "Id";

                cboMedicine.SelectedIndex = GetComboIndex(cboMedicine, MedicineID);
                cboMedicine.Enabled = false;

                txtMinAllowed.Text = MinAllowed.ToString();
            }
            else
            {
                foreach (var item in listTmp)
                {
                    var deleteItem = list.Find(c => c.Id == item.MedicineId);
                    list.Remove(deleteItem);
                }

                cboMedicine.DataSource = list;
                cboMedicine.DisplayMember = "Name";
                cboMedicine.ValueMember = "Id";
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

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, System.EventArgs e)
        {
            int minAllowed;
            if (int.TryParse(txtMinAllowed.Text, out minAllowed))
            {
                WareHouse item = new WareHouse();
                this.MinAllowed = minAllowed;
                if (WareHouseID > 0)
                {
                    item = whRepository.GetById(WareHouseID);
                    item.MinAllowed = minAllowed;
                    whRepository.Update(item);
                }
                else
                {
                    item.ClinicId = ClinicID;
                    item.MedicineId = int.Parse(cboMedicine.SelectedValue.ToString());                    
                    item.MinAllowed = minAllowed;
                    whRepository.Insert(item);
                }

                IsOK = true;

                this.Close();
            }
        }

        private void txtMinAllowed_TextChanged(object sender, System.EventArgs e)
        {
            int tmp = 0;
            if (!int.TryParse(txtMinAllowed.Text, out tmp))
            {
                txtMinAllowed.Text = "";
            }
        }
    }
}
