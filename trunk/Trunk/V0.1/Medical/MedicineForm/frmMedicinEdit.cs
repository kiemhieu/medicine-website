
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using Medical.Forms.Common;
using Medical.Forms.UI;

namespace Medical.MedicineForm
{

    public partial class FrmMedicinEdit : Form
    {
        private const String REGISTER_MESSAGE_ID = "Q001";
        private const String UPDATE_MESSAGE_ID = "Q002";

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
            // this.initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            InitializeCombobox(this.cboUnit);
            InitializeContentCombobox(this.cboContentUnit);

            // Load Medicine
            this._medicine = this._isAddnew ? new Medicine() : this._medicineRepository.GetById(this._medicineId);
            this.bdsMedicine.DataSource = this._medicine;
            if (_isAddnew) return;
            this.rdoArv.Checked = this._medicine.Type;
            this.rdoNTCh.Checked = !this._medicine.Type;
        }

        /// <summary>
        /// Initializes the combobox.
        /// </summary>
        /// <param name="cbo">The cbo.</param>
        private void InitializeCombobox(ComboBoxEx cbo)
        {
            // Load unit
            var defines = _defineRepository.GetUnit();
            defines.Insert(0, new Define() { Id = 0, Name = "" });
            cbo.DataSource = defines;
        }

        private void InitializeContentCombobox(ComboBoxEx cbo)
        {
            // Load unit
            var defines = _defineRepository.GetContentUnit();
            defines.Insert(0, new Define() { Id = 0, Name = "" });
            cbo.DataSource = defines;
        }

        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            this.err.Clear();

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

            if (!Validator.MandatoryChecking(cboUnit))
            {
                result = false;
                this.err.SetError(cboUnit, "Chưa nhập đơn vị");
            }

            if (txtContent.ValueObject != null && !Validator.MandatoryChecking(cboContentUnit))
            {
                result = false;
                this.err.SetError(cboContentUnit, "Chưa nhập đơn vị cho hàm lượng");
            }
            return result;
        }

        /// <summary>
        /// Handles the Click event of the btnCancle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!this.ValidateForm()) return;
            var messageId = this._isAddnew ? REGISTER_MESSAGE_ID : UPDATE_MESSAGE_ID;
            var dr = MessageDialog.Instance.ShowMessage(this, messageId, "loại thuốc");
            if (dr == DialogResult.No) return;

            this._medicine.Type = rdoArv.Checked;
            if (this._isAddnew)
                this._medicineRepository.Insert(this._medicine);
            else
                this._medicineRepository.Update(this._medicine);
            this.Close();
        }

        /// <summary>
        /// Handles the Load event of the FrmMedicinEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmMedicinEdit_Load(object sender, EventArgs e)
        {
            Initialize();
        }
    }

}
