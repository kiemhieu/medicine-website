﻿using Medical.Synchronization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Synchronization.Basic;

namespace Medical.Test
{
    public partial class frmTestSyn : Form
    {
        public frmTestSyn()
        {
            InitializeComponent();
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            string connectiongstring = Config.ConnectionString;

            List<Figure> figures = SynDBCore<Figure>.GetAll();
            MessageBox.Show(connectiongstring + ":" + figures.Count.ToString());

            //SynDBCore<Figure>.SaveToDB("1", 
        }
    }
}
