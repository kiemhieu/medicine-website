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

namespace Medical.History {
    public partial class HistoryDetail : Form {

        private long _prescriptionId;
        private Prescription _prescription;
        private List<PrescriptionDetail> _prescriptionDetails;

        private IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();


        public HistoryDetail(long _prescriptionId) {
            InitializeComponent();
            this._prescriptionId = _prescriptionId;
        }

        private void HistoryDetail_Load(object sender, EventArgs e)
        {
            initialize();
        }

        private void initialize()
        {
            this._prescription = this._prescriptionRepo.Get(this._prescriptionId);
            this.bdsPrescription.DataSource = this._prescription;
            this.bdsPrescriptionDetail.DataSource = this._prescription.PrescriptionDetails;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this._prescriptionRepo.Delete(this._prescriptionId);
        }
    }
}
