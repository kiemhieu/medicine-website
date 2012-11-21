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

namespace Medical {
    public partial class PatientRegister : Form {
        private bool _isAddNew = false;
        private readonly IPatientRepository _patientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRegister"/> class.
        /// </summary>
        public PatientRegister() {
            InitializeComponent();

            this.Patient = new Patient();
            this.bdsPatient.DataSource = Patient;
            this._isAddNew = true;
            this._patientRepository = new PatientRepository();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
            DialogResult = DialogResult.No;
        }

        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm() {
            if (string.IsNullOrEmpty(txtCode.Text)) {
                this.errPatient.SetError(txtCode, "Chưa nhập mã quản lý bệnh nhân");
                return false;
            }

            if (!ValidationUtil.IsAlphanumeric(txtCode.Text)) {
                this.errPatient.SetError(txtCode, "Mã bệnh nhân chỉ chấp nhận số hoặc chữ");
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text)) {
                this.errPatient.SetError(txtName, "Chưa nhập tên bệnh nhân");
                return false;
            }

            if (txtName.Text.Length < 3) {
                this.errPatient.SetError(txtName, "Tên phải ít nhất 3 kí tự trở lên");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e) {
            try
            {
                this.bdsPatient.EndEdit();
                this.Patient.Sexual = rdaMale.Checked ? "M" : "F";

                if (!this.ValidateForm()) return;
                var result = MessageBox.Show(this, "Đăng kí bệnh nhân mới, tiếp tục ?", "Xác nhận đăng ký",MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
                this._patientRepository.Insert(this.Patient);

                DialogResult = DialogResult.Yes;
            } catch(Exception ex)
            {
                DialogResult = DialogResult.No;
            }
        }

        /// <summary>
        /// Gets the patient.
        /// </summary>
        public Patient Patient { get; private set; }
    }
}
