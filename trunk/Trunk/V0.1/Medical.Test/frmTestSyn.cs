using Medical.Synchronization;
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

            List<Figure> figures = SynDBCore<Figure>.GetAllToSend("Id");
            List<Figure> figures2 = SynDBCore<Figure>.SendToSV("12", figures);
            SynDBCore<Figure>.SaveLog(new List<Figure>(figures2));

            //////////////////////////////////////////////////////////////////////
            ////////////////////// DUNG DE GOI WEBSERVICE ////////////////////////
            //////////////////////////////////////////////////////////////////////
            //Synchronize synservice = new Synchronize();
            //synservice.SendingCompleted += synservice_SendingCompleted;
            //synservice.SendAll("12");

        }

        void synservice_SendingCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Sending to server completed");
        }
    }
}
