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

        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            this.txtDate.Value = DateTime.Today;
            LoadData();
        }

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

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            var item = (Prescription) this.bdsPrescriptionHistory.Current;
            if (item == null) return;
            
        }

        private void BtnDetailClick(object sender, EventArgs e) {

        }

        private void DataGridViewX1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var prescription = (Prescription)this.bdsPrescriptionHistory.Current;
            if (prescription == null) return;

            var historyDetail = new HistoryDetail(prescription.Id);
            historyDetail.ShowDialog(this);

            LoadData();
        }

        private void DataGridViewX1DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }
        
    }
}
