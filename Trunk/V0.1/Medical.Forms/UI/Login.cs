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

        private void btnLogin_Click(object sender, System.EventArgs e) {
            bool isValid = userRepo.Login(this.txtUser.Text, this.txtPass.Text, AppContext.CurrentClinic.Id);
            if (isValid) {
                AppContext.Authenticated = true;
                AppContext.LoggedInUser = userRepo.Get(this.txtUser.Text);
                this.Close();
            }
        }

        private void btnCancal_Click(object sender, System.EventArgs e) {

        }


    }
}
