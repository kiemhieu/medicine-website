using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            loadData();
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            // this.Enabled = false;
            try
            {
                loadData();
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

        private void loadData()
        {
            List<Prescription> prescriptions = _prescriptionRepo.GetAll(this.txtDate.Value);
            prescriptions = prescriptions.OrderBy(x => x.LastUpdatedDate).ToList();
            int index = 1;
            foreach (var prescription in prescriptions) {
                prescription.No = index++;
            }
            this.bdsPrescriptionHistory.DataSource = prescriptions;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var item = (Prescription) this.bdsPrescriptionHistory.Current;
            if (item == null) return;
            
        }

        private void btnDetail_Click(object sender, EventArgs e) {

        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Prescription prescription = (Prescription)this.bdsPrescriptionHistory.Current;
            if (prescription == null) return;

            HistoryDetail historyDetail = new HistoryDetail(prescription.Id);
            historyDetail.ShowDialog(this);

            loadData();
        }

        
    }
}
