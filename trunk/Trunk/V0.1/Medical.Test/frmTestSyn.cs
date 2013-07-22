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
        //    string connectiongstring = Config.ConnectionString;
        //    bool b1= SynDBCore<Figure>.SendAllToSV("1", "Id");
        //     bool b2= SynDBCore<FigureDetail>.SendAllToSV("1", "Id");
        //    //List<Figure> figures = SynDBCore<Figure>.GetAll();
        //    MessageBox.Show(connectiongstring + ":" + (b1 && b2).ToString());
        //    //SynDBCore<Figure>.SaveToDB("1", 

            Synchronize synservice = new Synchronize();
            synservice.SendingCompleted += synservice_SendingCompleted;
            synservice.SendAll("1");

        }

        void synservice_SendingCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Sending to server completed");
        }
    }
}
