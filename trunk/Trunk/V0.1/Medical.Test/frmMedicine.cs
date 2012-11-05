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
        private UserRepository userRepository = new UserRepository();
        private MedicineRepository medicineRepository = new MedicineRepository();
        public frmMedicine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //Add add = new Add();
            //add.ShowDialog(this);

            //List<User> users = userRepository.GetAll();
            //this.grd.DataSource = users;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<Medicine> medicines = medicineRepository.GetAll();
            this.grd.DataSource = medicines;
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
        }
        private Medicine FillToEntity()
        {
            Medicine medicine ;
            if (lblID.Text.Trim() == "")
            {
                medicine = new Medicine();
                medicine.Id = 0;
            }
            else
            {
                medicine = medicineRepository.GetById(int.Parse(lblID.Text));
            }

            medicine.Content = int.Parse(txtContent.Text.Trim());
            medicine.ContentUnit = int.Parse(txtContentUnit.Text.Trim());
            medicine.Description = txtDescription.Text.Trim();
            medicine.MedicineCode = txtMaThuoc.Text.Trim();
            medicine.Name = txtTenThuoc.Text.Trim();
            medicine.TradeName = txtTradeName.Text.Trim();
            

            return medicine; 
        }
        private  void FillToItem()
        {
            if(lblID.Text.Trim()=="")
                return;
            Medicine medicine = medicineRepository.GetById(int.Parse(lblID.Text.Trim()));

            this.txtContent.Text = medicine.Content.ToString();
            this.txtContentUnit.Text = medicine.ContentUnit.ToString();
            this.txtMaThuoc.Text = medicine.MedicineCode;
            this.txtTenThuoc.Text = medicine.Name;
            this.txtTradeName.Text = medicine.TradeName;
            this.txtUnit.Text = medicine.Unit.ToString();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            lblAction.Text = "Insert";
            cleanItems();
            ReadOnlyItems(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblAction.Text = "Delete";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lblAction.Text = "Edit";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (lblAction.Text.Trim())
            {
                case "Insert":

                    break;
                case "Edit":
                    break;
                case "Delete":
                    break;

            }
        }
    }
}
