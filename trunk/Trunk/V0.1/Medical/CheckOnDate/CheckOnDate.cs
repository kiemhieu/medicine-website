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
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.CheckOnDate {
    public partial class CheckOnDate : DockContent {

        private readonly IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();

        public CheckOnDate() {
            InitializeComponent();
        }

        private void CheckOnDateLoad(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            var patientList = _prescriptionRepo.GetAllOnLate(this.txtPatientName.Text);
            var index = 1;
            foreach (var item in patientList)
            {
                item.No = index++;
            }
            this.bdsCheckOnDate.DataSource = patientList;
            this.bdsCheckOnDate.ResetBindings(true);
            this.dataGridViewX1.Refresh();
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
