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
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Test
{
    public partial class Form1 : DockContent
    {
        private UserRepository userRepository = new UserRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog(this);

            List<User> users = userRepository.GetAll();
            this.dataGridView1.DataSource = users;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<User> users = userRepository.GetAll();
            this.dataGridView1.DataSource = users;
        }

        private void Form1_DockStateChanged(object sender, EventArgs e)
        {

        }

        private void Form1_DockChanged(object sender, EventArgs e)
        {

        }

        private void Form1_PaddingChanged(object sender, EventArgs e)
        {

        }
    }
}
