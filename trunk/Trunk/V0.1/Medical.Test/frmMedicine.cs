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
            ReadOnlyItems(true);
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
            List<Medicine> medicines = medicineRepository.GetAll();
            this.grd.DataSource = medicines;

            if (grd.Rows.Count == 0)
            { }
            else
            {

                grd.Rows[0].Selected = true;
                lblID.Text = grd.Rows[0].Cells["ID"].Value.ToString();

                FillToItemByID();

            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblAction.Text = "Select";
            ReadOnlyItems(true);

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
            this.txtDescription.ReadOnly = isTrue;
        }
        private Medicine FillToEntity()
        {
            Medicine medicine;
            if (lblID.Text.Trim() == "")
            {
                medicine = new Medicine();
                //medicine.Id = 0;
            }
            else
            {
                medicine = medicineRepository.GetById(int.Parse(lblID.Text));
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

        private void FillToItemByGridIndex(int iRow)
        {
            if (iRow < 0) { return; }
            this.txtContent.Text = grd.Rows[iRow].Cells["Content"].Value == null ? "" : grd.Rows[iRow].Cells["Content"].Value.ToString();
            this.txtContentUnit.Text = grd.Rows[iRow].Cells["ContentUnit"].Value == null ? "" : grd.Rows[iRow].Cells["ContentUnit"].Value.ToString();
            this.txtMaThuoc.Text = grd.Rows[iRow].Cells["MedicineCode"].Value == null ? "" : grd.Rows[iRow].Cells["MedicineCode"].Value.ToString();
            this.txtTenThuoc.Text = grd.Rows[iRow].Cells["Name"].Value == null ? "" : grd.Rows[iRow].Cells["Name"].Value.ToString();
            this.txtTradeName.Text = grd.Rows[iRow].Cells["TradeName"].Value == null ? "" : grd.Rows[iRow].Cells["TradeName"].Value.ToString();
            this.txtUnit.Text = grd.Rows[iRow].Cells["Unit"].Value == null ? "" : grd.Rows[iRow].Cells["Unit"].Value.ToString();
            this.txtDescription.Text = grd.Rows[iRow].Cells["Description"].Value == null ? "" : grd.Rows[iRow].Cells["Description"].Value.ToString();
            this.rdARV.Checked = grd.Rows[iRow].Cells["Type"].Value.ToString() == "1" ? true : false;
            this.rdNTCH.Checked = grd.Rows[iRow].Cells["Type"].Value.ToString() == "1" ? false : true;
        }
        private void FillToItemByID()
        {
            if (lblID.Text.Trim() == "" || lblID.Text.Trim() == "0")
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
            ButtonEnable(false);
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblAction.Text = "Delete";
            ButtonEnable(false);
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lblAction.Text = "Edit";
            ReadOnlyItems(false);
            ButtonEnable(false);
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;

        }
        private void ButtonEnable(bool isTrue)
        {
            this.btnCancel.Enabled = !isTrue;
            this.btnDelete.Enabled = isTrue;
            this.btnEdit.Enabled = isTrue;
            this.btnUpdate.Enabled = isTrue;
            this.btnInsert.Enabled = isTrue;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (lblAction.Text.Trim())
            {
                case "Insert":
                    MessageBox.Show("Bạn có muốn thêm thuốc này không?");
                    Medicine newEnt = FillToEntity();
                    try
                    {
                        medicineRepository.Insert(newEnt);
                    }
                    catch (Exception ex)
                    {

                        string s = ex.Message;
                    }

                    break;
                case "Edit":
                    MessageBox.Show("Bạn có muốn sửa thông tin thuốc này không?");
                    Medicine curEnt = FillToEntity();
                    try
                    {
                        medicineRepository.Update(curEnt);
                    }
                    catch (Exception ex)
                    {

                        string s = ex.Message;
                    }
                    break;
                case "Delete":
                    medicineRepository.Delete(int.Parse(lblID.Text.Trim()));
                    break;

            }
            lblAction.Text = "Select";
            ReadOnlyItems(true);
            ButtonEnable(true);
            FillToGrid();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ReadOnlyItems(true);
        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text = grd.Rows[e.RowIndex].Cells["ID"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            FillToItemByGridIndex(e.RowIndex);
        }

    }
}
