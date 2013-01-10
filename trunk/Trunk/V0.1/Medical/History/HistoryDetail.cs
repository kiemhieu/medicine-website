using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medical.Common.Exceptions;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using Medical.Forms.UI;

namespace Medical.History {
    public partial class HistoryDetail : Form {

        private long _prescriptionId;
        private Prescription _prescription;
        private List<PrescriptionDetail> _prescriptionDetails;

        private readonly IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryDetail"/> class.
        /// </summary>
        /// <param name="_prescriptionId">The _prescription id.</param>
        public HistoryDetail(long _prescriptionId) {
            this.InitializeComponent();
            this._prescriptionId = _prescriptionId;
        }

        /// <summary>
        /// Handles the Load event of the HistoryDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void HistoryDetail_Load(object sender, EventArgs e)
        {
            initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void initialize()
        {
            this._prescription = this._prescriptionRepo.Get(this._prescriptionId);
            this.bdsPrescription.DataSource = this._prescription;
            this.bdsPrescriptionDetail.DataSource = this._prescription.PrescriptionDetails;
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var parameter = String.Format("đơn thuốc ngày {0} của bệnh nhân {1}",
                                                this._prescription.Date.ToString("dd/MM/yyyy"),
                                                this._prescription.PatientName);

            if (MessageDialog.Instance.ShowMessage(this, "Q003", parameter) == DialogResult.No) return;

            try {
                this._prescriptionRepo.Delete(this._prescriptionId);
                this.Close();
            } catch (ProgramLogicalException ex) {
                MessageDialog.Instance.ShowMessage(this, "ERR0001", ex.Message);
            }
        }
    }
}
