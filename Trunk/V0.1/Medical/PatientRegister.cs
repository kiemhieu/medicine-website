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
        private readonly Patient patient;
        private IPatientRepository patientRepository;

        public PatientRegister() {
            InitializeComponent();

            this.patient = new Patient();
            this.bdsPatient.DataSource = patient;
            this._isAddNew = true;
            this.patientRepository = new PatientRepository();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

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

        private void btnSave_Click(object sender, EventArgs e) {
            this.bdsPatient.EndEdit();
            this.patient.Sexual = rdaMale.Checked ? "M" : "F";

            if (!this.ValidateForm()) return;

            DialogResult result = MessageBox.Show(this, "Đăng kí bệnh nhân mới, tiếp tục ?", "Xác nhận đăng ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            patientRepository.Insert(this.patient);
        }
    }
}
