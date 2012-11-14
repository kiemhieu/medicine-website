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

    public partial class frmMedicinEdit : Form
    {
        private UserRepository userRepository = new UserRepository();
        private MedicineRepository medicineRepository = new MedicineRepository();
        public static int IdMedicineEdit;
        public frmMedicinEdit()
        {
            //IdMedicineEdit = frmMedicine.IdMedicine;
            InitializeComponent();
            if (IdMedicineEdit <= 0)
            {
                cleanItems();
                ReadOnlyItems(false);

            }
            else
            {
                //Medicine medicine = medicineRepository.GetById(IdMedicineEdit);
                FillToItemByID();
                ReadOnlyItems(false);
            }
        }
        
      

        private void cleanItems()
        {
            this.txtContent.Text = "";
            this.txtContentUnit.Text = "";
            this.txtMaThuoc.Text = "";
            this.txtTenThuoc.Text = "";
            this.txtTradeName.Text = "";
            this.txtUnit.Text = "";
        }
        private void ReadOnlyItems(bool isTrue)
        {
            this.txtContent.ReadOnly = isTrue;
            this.txtContentUnit.ReadOnly = isTrue;
            this.txtMaThuoc.ReadOnly = isTrue;
            this.txtTenThuoc.ReadOnly = isTrue;
            this.txtTradeName.ReadOnly = isTrue;
            this.txtUnit.ReadOnly = isTrue;
            this.txtDescription.ReadOnly = isTrue;
        }
        private Medicine FillToEntity()
        {
            Medicine medicine;
            if (IdMedicineEdit <=0)
            {
                medicine = new Medicine();
                //medicine.Id = 0;
            }
            else
            {
                medicine = medicineRepository.GetById(IdMedicineEdit);
            }

            medicine.Content = Convert.ToInt32(txtContent.Text.Trim());
            medicine.ContentUnit = Convert.ToInt32(txtContentUnit.Text.Trim());
            medicine.Description = txtDescription.Text.Trim();
            medicine.MedicineCode = txtMaThuoc.Text.Trim();
            medicine.Name = txtTenThuoc.Text.Trim();
            medicine.TradeName = txtTradeName.Text.Trim();
            medicine.Type = rdARV.Checked;

            return medicine;
        }

     
        private void FillToItemByID()
        {
            if (IdMedicineEdit <= 0)
                return;
            Medicine medicine = medicineRepository.GetById(IdMedicineEdit);

            this.txtContent.Text = medicine.Content.ToString();
            this.txtContentUnit.Text = medicine.ContentUnit.ToString();
            this.txtMaThuoc.Text = medicine.MedicineCode;
            this.txtTenThuoc.Text = medicine.Name;
            this.txtTradeName.Text = medicine.TradeName;
            this.txtUnit.Text = medicine.Unit.ToString();
        }

       
        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            DialogResult dr =MessageBox.Show("Bạn có muốn cập nhật khônsdfasdfdsafsdag?", "Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            

            if(dr == DialogResult.OK)
            {
                Medicine medicine = FillToEntity();
                if(medicine.Id == 0) medicineRepository.Insert(medicine);
                else medicineRepository.Update(medicine);

                this.Close();
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            frmMedicinEdit.IdMedicineEdit = -1;
            this.Close(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn cập nhật không?", "Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (dr == DialogResult.OK)
            {
                Medicine medicine = FillToEntity();
                if (medicine.Id == 0) medicineRepository.Insert(medicine);
                else medicineRepository.Update(medicine);

                this.Close();
            }
        }
    }

}
