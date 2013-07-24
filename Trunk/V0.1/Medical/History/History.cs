using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.History
{
    public partial class History : DockContent
    {
        private IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="History"/> class.
        /// </summary>
        public History()
        {
            InitializeComponent();
            this.Activated += History_Activated;
        }

        void History_Activated(object sender, EventArgs e)
        {
            LoadData();
        }

        private void HistoryLoad(object sender, EventArgs e)
        {
            this.txtDate.Value = DateTime.Today;
            LoadData();
        }

        /// <summary>
        /// TXTs the date text changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TxtDateTextChanged(object sender, EventArgs e)
        {
            // this.Enabled = false;
            try
            {
                LoadData();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // this.Enabled = true;
            }
            
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            List<Prescription> prescriptions = _prescriptionRepo.GetAll(this.txtDate.Value);
            prescriptions = prescriptions.OrderBy(x => x.LastUpdatedDate).ToList();
            int index = 1;
            foreach (var prescription in prescriptions) {
                prescription.No = index++;
            }
            this.bdsPrescriptionHistory.DataSource = prescriptions;
        }

        /// <summary>
        /// BTNs the delete click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnDeleteClick(object sender, EventArgs e)
        {
            var item = (Prescription) this.bdsPrescriptionHistory.Current;
            if (item == null) return;
            
        }

        /// <summary>
        /// BTNs the detail click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnDetailClick(object sender, EventArgs e) {

        }

        /// <summary>
        /// Datas the grid view x1 cell double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var prescription = (Prescription)this.bdsPrescriptionHistory.Current;
            if (prescription == null) return;

            var historyDetail = new HistoryDetail(prescription.Id);
            historyDetail.ShowDialog(this);

            LoadData();
        }

        /// <summary>
        /// Datas the grid view x1 data binding complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewBindingCompleteEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F5) return;
            LoadData();
        }
        
    }
}
