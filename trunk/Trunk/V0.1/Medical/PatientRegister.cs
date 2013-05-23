using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using Medical.Forms.Implements;
using Medical.Forms.UI;

namespace Medical
{
    public partial class PatientRegister : Form
    {
        private bool _isAddNew = false;
        private readonly IPatientRepository _patientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRegister"/> class.
        /// </summary>
        public PatientRegister()
        {
            InitializeComponent();

            this.Patient = new Patient();
            this.bdsPatient.DataSource = Patient;
            this._isAddNew = true;
            this._patientRepository = new PatientRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRegister"/> class.
        /// </summary>
        public PatientRegister(Patient patient)
        {
            InitializeComponent();

            this.Patient = patient;
            this.bdsPatient.DataSource = Patient;
            this._isAddNew = false;
            this._patientRepository = new PatientRepository();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.No;
        }

        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            this.errPatient.Clear();
            bool result = true;

            if (string.IsNullOrEmpty(this.Patient.Code))
            {
                SetError(txtCode, "Chưa nhập mã quản lý bệnh nhân");
                result = false;
            } else if (this._patientRepository.IsDuplicateCode(Patient.Code)) 
            {
                SetError(txtCode, "Mã bệnh nhân đã tồn tại");
                result = false;
            }

            if (string.IsNullOrEmpty(this.Patient.Name))
            {
                SetError(txtName, "Chưa nhập tên bệnh nhân");
                result = false;
            }
            else if (this.Patient.Name.Length < 3)
            {
                SetError(txtName, "Tên phải ít nhất 3 kí tự trở lên");
                result = false;
            }

            if (this.Patient.BirthYear == null || this.Patient.BirthYear == 0)
            {
                SetError(txtYear, "Chưa nhập năm sinh");
                result = false;
            }

            if (string.IsNullOrEmpty(this.Patient.Phone))
            {
                SetError(txtPhone, "Chưa nhập số điện thoại");
                result = false;
            }
            else if (this.Patient.Phone.Length < 8)
            {
                SetError(txtPhone, "Số điện thoại không hợp lệ");
                result = false;
            }

            
            if (string.IsNullOrEmpty(this.Patient.Address))
            {
                SetError(txtAddress, "Chưa nhập địa chỉ");
                result = false;
            }

            return result;
        }

        public void SetError(Control control, String messsage)
        {
            this.errPatient.SetIconAlignment(control, ErrorIconAlignment.TopRight);
            this.errPatient.SetIconPadding(control, -8);
            this.errPatient.SetError(control, messsage);
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnSaveClick(object sender, EventArgs e)
        {
            try
            {
                this.bdsPatient.EndEdit();
                this.Patient.Sexual = rdaMale.Checked ? "M" : "F";

                if (!this.ValidateForm()) return;

                var result = MessageDialog.Instance.ShowMessage(this, "Q011");
                if (result == DialogResult.No) return;

                if (_isAddNew)
                {
                    this._patientRepository.Insert(this.Patient);
                }
                else
                {
                    this._patientRepository.Update(this.Patient);
                }
                DialogResult = DialogResult.Yes;
            }
            catch (Exception ex)
            {
                // DialogResult = DialogResult.No;
                MessageDialog.Instance.ShowMessage(this, "ERR0002", ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Gets the patient.
        /// </summary>
        public Patient Patient { get; private set; }
    }
}
