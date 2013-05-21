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

namespace Medical {
    public partial class CheckUpHistory : Form
    {
        private int patientId;
        private List<Prescription> prescriptions;

        private readonly IFigureRepository figureRepo = new FigureRepository();
        private readonly IPrescriptionRepository _precriptionRepo = new PrescriptionRepository();

        public CheckUpHistory(int patientId) {
            InitializeComponent();
            this.patientId = patientId;
            Initialize();
        }

        private void Initialize()
        {
            prescriptions = this._precriptionRepo.GetAll(this.patientId);
            prescriptions = prescriptions.OrderByDescending(x => x.Date).ToList();
            this.lsbDate.DataSource = prescriptions;
            //this.lsbDate.DisplayMember = "Date";
            //this.lsbDate.ValueMember = "Id";

            this.cboFigure.DataSource = figureRepo.GetAll();
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LsbDateSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsbDate.SelectedValue == null) return;
            var value = Convert.ToInt32(this.lsbDate.SelectedValue);
            var prescription = _precriptionRepo.Get(value);
            this.bdsPrescription.DataSource = prescription;

            var prescriptionDetails = prescription.PrescriptionDetails;
            foreach (var item in prescriptionDetails)
            {
                item.MedicineName = item.Medicine.Name;
                item.TradeName= item.Medicine.TradeName;
                item.UnitName= item.Medicine.Define.Name;
            }
                
            this.bdsPrescriptionDetail.DataSource = prescriptionDetails;
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
