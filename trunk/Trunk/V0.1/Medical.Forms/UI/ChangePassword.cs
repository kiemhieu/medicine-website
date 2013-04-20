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

namespace Medical.Forms.UI
{
    public partial class ChangePassword : Form
    {
        private IClinicRepository _clinicRepo = new ClinicRepository();

        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePassword"/> class.
        /// </summary>
        public ChangePassword()
        {
            InitializeComponent();

            this.User = new User();
            this.bdsUser.DataSource = User;
            this._userRepository = new UserRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePassword"/> class.
        /// </summary>
        public ChangePassword(User user)
        {
            InitializeComponent();
            this.User = user;
            this.bdsUser.DataSource = User;
            this.txtUser.Text = User.UserName;
            this._userRepository = new UserRepository();
        }



        /// <summary>
        /// Validates the form.
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {
            this.err.Clear();
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                this.err.SetError(txtUser, "Chưa nhập tên đăng nhập");
                return false;
            }

            if (!ValidationUtil.IsAlphanumeric(txtUser.Text))
            {
                this.err.SetError(txtUser, "Tên đăng nhập chỉ chấp nhận số hoặc chữ");
                return false;
            }

            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                this.err.SetError(txtNewPassword, "Chưa nhập nhập khẩu");
                return false;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                this.err.SetError(txtNewPassword, "Mật khẩu phải ít nhất 6 kí tự trở lên");
                return false;
            }

            if (string.IsNullOrEmpty(txtNewPasswordConfirm.Text))
            {
                this.err.SetError(txtNewPasswordConfirm, "Chưa nhập nhập khẩu");
                return false;
            }

            if (txtNewPasswordConfirm.Text.Length < 6)
            {
                this.err.SetError(txtNewPasswordConfirm, "Mật khẩu phải ít nhất 6 kí tự trở lên");
                return false;
            }

            if (!txtNewPasswordConfirm.Text.Trim().Equals(txtNewPassword.Text.Trim()) )
            {
                this.err.SetError(txtNewPasswordConfirm, "Xác nhận Mật khẩu không đúng. Hãy nhập lại!");
                return false;
            }

            try
            {
                
                var isValid = _userRepository.Login(this.txtUser.Text, this.txtOldPassword.Text, AppContext.CurrentClinic.Id);
                if (isValid)
                {
                    AppContext.Authenticated = true;
                    AppContext.LoggedInUser = _userRepository.Get(this.txtUser.Text);
                    this.Close();
                }
                else
                {
                    this.err.SetError(txtOldPassword, "Mật khẩu cũ đúng");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            return true;
        }

       


        /// <summary>
        /// Gets the ChangePassword.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.bdsUser.EndEdit();
                if (!this.ValidateForm()) return;
                {
                    var result = MessageBox.Show(this, "Thay đổi mật khẩu mới, tiếp tục ?", "Xác nhận thay đổi", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No) return;
                    this.User.Password = txtNewPassword.Text.Trim();
                    this._userRepository.Update(this.User);
                }
                DialogResult = DialogResult.Yes;


                var result2 = MessageBox.Show(this, "Thay đổi mật khẩu mới thành công! Kết thúc thay đổi mật khẩu ?", "Xác nhận kết thúc", MessageBoxButtons.YesNo);
                if (result2 == DialogResult.No) return;
                else
                {
                    this.Close();
                    
                }
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.No;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.No;
        }
    }
}
