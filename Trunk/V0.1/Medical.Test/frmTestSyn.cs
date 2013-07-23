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

            ////////////////////////////////////////////////////////////////////
            //////////////////// DUNG DE GOI TrUC TIEP K THONG QUA WEBSERVICE///
            ////////////////////////////////////////////////////////////////////
            List<Figure> figures = SynDBCore<Figure>.GetAllToSend("Id");
            List<Figure> figures2 = SynDBCore<Figure>.SendToSV("12", figures);
            SynDBCore<Figure>.SaveLog(new List<Figure>(figures2));
            //return

            ////////////////////////////////////////////////////////////////////
            ////// DUNG DE KHAI BAO FIGURE CO ID=6 VUA MOI THAY DOI(SUA, XOA)///
            ////////////////////////////////////////////////////////////////////
            if (SynDBCore<Figure>.SaveChange(6)) MessageBox.Show("Change data completed");
            return;

            ////////////////////////////////////////////////////////////////////
            //////////////////// DUNG DE GOI WEBSERVICE ////////////////////////
            ////////////////////////////////////////////////////////////////////
            Synchronize synservice = new Synchronize();
            synservice.SendingCompleted += synservice_SendingCompleted;
            synservice.SendAll("12");

        }

        void synservice_SendingCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Sending to server completed");
        }
    }
}
