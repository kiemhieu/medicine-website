
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using Medical.Forms.Common;

namespace Medical.MedicineForm
{

    public partial class FrmMedicinEdit : Form
    {
        private int _medicineId;
        private bool _isAddnew = true;
        private Medicine _medicine;

        // private UserRepository userRepository = new UserRepository();
        private readonly MedicineRepository _medicineRepository = new MedicineRepository();
        private readonly IDefineRepository _defineRepository = new DefineRepository();


        public FrmMedicinEdit()
        {
            InitializeComponent();
        }

        public FrmMedicinEdit(int id)
            : this()
        {
            this._medicineId = id;
            this._isAddnew = false;
            this.initialize();
        }

        private void initialize()
        {
            InitializeCombobox(this.cboUnit);
            InitializeCombobox(this.cboContentUnit);

            // Load Medicine
            this._medicine = this._isAddnew ? new Medicine() : this._medicineRepository.GetById(this._medicineId);
            this.bdsMedicine.DataSource = this._medicine;
            if (!_isAddnew)
            {
                this.rdoArv.Checked = this._medicine.Type;
                this.rdoNTCh.Checked = !this._medicine.Type;
            }
        }

        private void InitializeCombobox(ComboBoxEx cbo)
        {
            // Load unit
            var defines = _defineRepository.GetUnit();
            defines.Insert(0, new Define() { Id = 0, Name = "" });
            cbo.DataSource = defines;
        }

        private bool ValidateForm()
        {
            var result = true;
            if (!Validator.MandatoryChecking(new RadioButton[] { rdoArv, rdoNTCh }))
            {
                result = false;
                this.err.SetError(rdoArv, "Chọn loại thuốc");
                this.err.SetError(rdoNTCh, "Chọn loại thuốc");
            }

            if (!Validator.MandatoryChecking(txtName))
            {
                result = false;
                this.err.SetError(txtName, "Chưa nhập tên thuốc");
            }

            if (!Validator.MandatoryChecking(txtName))
            {
                result = false;
                this.err.SetError(txtName, "Chưa nhập tên thuốc");
            }
            result = true;
        }

        private void cleanItems()
        {
            /*
            this.txtContent.Text = "";
            this.txtContentUnit.Text = "";
            //this.txtMaThuoc.Text = "";
            this.txtTenThuoc.Text = "";
            this.txtTradeName.Text = "";
            this.txtUnit.Text = "";
             */
        }
        private void ReadOnlyItems(bool isTrue)
        {
            /*
            this.txtContent.ReadOnly = isTrue;
            this.txtContentUnit.ReadOnly = isTrue;
            //this.txtMaThuoc.ReadOnly = isTrue;
            this.txtTenThuoc.ReadOnly = isTrue;
            this.txtTradeName.ReadOnly = isTrue;
            this.txtUnit.ReadOnly = isTrue;
            this.txtDescription.ReadOnly = isTrue;
             */
        }

        private Medicine FillToEntity()
        {
            /*
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
            medicine.Unit = Convert.ToInt32((txtUnit.Text.Trim()));
            medicine.ContentUnit = Convert.ToInt32(txtContentUnit.Text.Trim());
            medicine.Description = txtDescription.Text.Trim();
           // medicine.MedicineCode = txtMaThuoc.Text.Trim();
            medicine.Name = txtTenThuoc.Text.Trim();
            medicine.TradeName = txtTradeName.Text.Trim();
            medicine.Type = rdARV.Checked;

            return medicine;
             */
            return null;
        }


        private void FillToItemByID()
        {
            /*
            if (IdMedicineEdit <= 0)
                return;
            Medicine medicine = medicineRepository.GetById(IdMedicineEdit);

            this.txtContent.Text = medicine.Content.ToString();
            this.txtContentUnit.Text = medicine.ContentUnit.ToString();
           //this.txtMaThuoc.Text = medicine.MedicineCode;
            this.txtTenThuoc.Text = medicine.Name;
            this.txtTradeName.Text = medicine.TradeName;
            this.txtUnit.Text = medicine.Unit.ToString();
            this.txtDescription.Text = medicine.Description;
            if (medicine.Type) {rdARV.Checked = true;
                rdNTCH.Checked = false;
            }
            else
            {
                rdARV.Checked = false;
                rdNTCH.Checked = true;
            }
             */
        }


        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn cập nhật không?", "Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (dr == DialogResult.OK)
            {
                Medicine medicine = FillToEntity();
                if (medicine.Id == 0) _medicineRepository.Insert(medicine);
                else _medicineRepository.Update(medicine);

                this.Close();
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            // FrmMedicinEdit.IdMedicineEdit = -1;
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ()
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn cập nhật không?", "Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            if (dr == DialogResult.OK)
            {
                Medicine medicine = FillToEntity();
                if (medicine.Id == 0) _medicineRepository.Insert(medicine);
                else _medicineRepository.Update(medicine);

                this.Close();
            }
        }

        private void FrmMedicinEdit_Load(object sender, EventArgs e)
        {
            initialize();
        }
    }

}
