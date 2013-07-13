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
using Medical.Data.Entities.Views;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.CheckOnDate {
    public partial class CheckOnDate : DockContent {

        private readonly IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();
        private readonly IPatientRepository _patientRepo = new PatientRepository();

        public CheckOnDate() {
            InitializeComponent();
        }

        private void CheckOnDateLoad(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
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

        private void DataGridViewX1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selected = (VPatientLastPrescription) this.bdsCheckOnDate.Current;
            if (selected == null) return;

            var patient = this._patientRepo.GetById(selected.Id);
            var checkUpRegister = new CheckUpRegister(patient);
            var result = checkUpRegister.ShowDialog(this);
            if (result == DialogResult.Cancel) return;
            Initialize();
            
        }
    }
}
