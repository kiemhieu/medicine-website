using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Repositories;
using Medical.Forms.Implements;

namespace Medical.Forms.UI {
    public partial class Login : Form {

        private IUserRepository userRepo = new UserRepository();

        public Login() {
            InitializeComponent();
        }

        private void BtnLoginClick(object sender, System.EventArgs e) {
            try {
                DoLoggingIn();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancalClick(object sender, System.EventArgs e) {
            Environment.Exit(0);
        }

        private void TxtPassKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)

                try
                {
                    DoLoggingIn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }

        private void DoLoggingIn()
        {
            this.err.Clear();
            userRepo = new UserRepository();
            var isValid = userRepo.Login(this.txtUser.Text, this.txtPass.Text, AppContext.CurrentClinicId);
            isValid = true;
            if (isValid)
            {
                AppContext.Authenticated = true;
                AppContext.LoggedInUser = userRepo.Get(this.txtUser.Text, AppContext.CurrentClinicId);
                IClinicRepository clinicRepository = new ClinicRepository();
                AppContext.CurrentClinic = clinicRepository.Get(AppContext.CurrentClinicId);
                this.Close();
            }
            else
            {
                this.err.SetError(txtPass, "Tài khoản không hợp lệ");
                this.err.SetError(txtUser, "Tài khoản không hợp lệ");
            }
        }

        private void BtnChangeServerLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var serverForm = new Database();
            serverForm.ShowDialog();
        } 
    }
}
