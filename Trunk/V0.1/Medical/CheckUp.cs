using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical {
    public partial class CheckUp : DockContent {
        public CheckUp() {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            PatientRegister registerform = new PatientRegister();
            registerform.ShowDialog();
        }
    }
}
