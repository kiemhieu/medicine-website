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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsbDate.SelectedValue == null) return;
            var value = Convert.ToInt32(this.lsbDate.SelectedValue);
            var prescription = _precriptionRepo.Get(value);
            this.bdsPrescription.DataSource = prescription;

            var prescriptionDetails = prescription.PrescriptionDetails;
            for (var i = 0; i < prescriptionDetails.Count; i++) prescriptionDetails[i].No = i + 1;
            this.bdsPrescriptionDetail.DataSource = prescriptionDetails;
        }

    }
}
