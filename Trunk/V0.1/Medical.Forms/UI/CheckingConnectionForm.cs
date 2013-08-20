using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical.Forms.UI
{
    public partial class CheckingConnectionForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingConnectionForm"/> class.
        /// </summary>
        public CheckingConnectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checkings the connection form load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckingConnectionFormLoad(object sender, System.EventArgs e)
        {
            
        }

        /// <summary>
        /// Checkings the connection form shown.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckingConnectionFormShown(object sender, System.EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();

        }

        /// <summary>
        /// Backgrounds the worker1 do work.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            var sync = new Sync.Sync();
            String message;
            bool result = sync.TestConnection(out message);
            e.Result = new Object[] { result, message };
        }

        /// <summary>
        /// Backgrounds the worker1 progress changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void BackgroundWorker1ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        /// <summary>
        /// Backgrounds the worker1 run worker completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var results = (object[])e.Result;
                var result = (bool)results[0];
                if (result)
                {
                    MessageDialog.Instance.ShowMessage(this, "MSG0005", "Kết nối thành công");
                    return;
                }

                var message = (string)results[1];
                MessageDialog.Instance.ShowMessage(this, "MSG0005", "Kết nối không thành công\n" + message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
