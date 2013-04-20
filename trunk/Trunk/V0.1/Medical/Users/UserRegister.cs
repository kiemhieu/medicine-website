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

namespace Medical.Users
{
    public partial class UserRegister : Form
    {
        private IClinicRepository _clinicRepo = new ClinicRepository();

        private bool _isAddNew = false;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRegister"/> class.
        /// </summary>
        public UserRegister()
        {
            InitializeComponent();

            if (AppContext.LoggedInUser.Role > MedicineRoles.SupperManager)
            {
                cboClinic.DataSource = new List<Medical.Data.Entities.Clinic> { AppContext.CurrentClinic };
            }
            else
                cboClinic.DataSource = _clinicRepo.GetAll();
            this.User = new User();
            this.bdsUser.DataSource = User;
            this._isAddNew = true;
            this._userRepository = new UserRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRegister"/> class.
        /// </summary>
        public UserRegister(User patient)
        {
            InitializeComponent();
          

            this.User = patient;
            this.bdsUser.DataSource = User;
            this._isAddNew = false;
            this._userRepository = new UserRepository();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                this.errPatient.SetError(txtCode, "Chưa nhập mã quản lý bệnh nhân");
                return false;
            }

            if (!ValidationUtil.IsAlphanumeric(txtCode.Text))
            {
                this.errPatient.SetError(txtCode, "Mã bệnh nhân chỉ chấp nhận số hoặc chữ");
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                this.errPatient.SetError(txtName, "Chưa nhập tên bệnh nhân");
                return false;
            }

            if (txtName.Text.Length < 3)
            {
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.bdsUser.EndEdit();
                //this.User.Sexual = rdaMale.Checked ? "M" : "F";

                if (!this.ValidateForm()) return;
                if (_isAddNew)
                {
                    var result = MessageBox.Show(this, "Đăng kí bệnh nhân mới, tiếp tục ?", "Xác nhận đăng ký", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) return;
                    this._userRepository.Insert(this.User);
                }
                else
                {
                    var result = MessageBox.Show(this, "Thay đổi thông tin bệnh nhân mới, tiếp tục ?", "Xác nhận thay đổi", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) return;
                    this._userRepository.Update(this.User);
                }
                DialogResult = DialogResult.Yes;
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.No;
            }
        }

        /// <summary>
        /// Gets the patient.
        /// </summary>
        public User User { get; private set; }
    }
}
