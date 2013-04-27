using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Entities;
using Medical.Data.Repositories;

namespace Medical.Test
{
    public partial class Add : Form
    {
        private UserRepository userRepository = new UserRepository();

        public Add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.Name = this.TxtName.Text;
                user.UserName = this.TxtUserName.Text;
                user.Password = this.TxtPassword.Text;
                user.Active = CboActive.Checked;
                userRepository.Insert(user);
                MessageBox.Show("Inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
