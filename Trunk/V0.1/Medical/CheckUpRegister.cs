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
    public partial class CheckUpRegister : Form {

        private readonly IFigureRepository _figureRepo = new FigureRepository();

        private Patient _patient;
        private List<Figure> _figureList;
        private bool _isUpdate = false;
        private Prescription _prescription;
        private List<PrescriptionDetail> _prescriptionDetailList;

        public CheckUpRegister(Patient patient) : this() {
            InitializeComponent();
        }

        public CheckUpRegister()
        {
            InitializeComponent();
        }


        private void Initialize(Patient patient) {
            this._patient = patient;

            // Initialize combobox
            var figures = _figureRepo.GetAll();
            this.cboFigure.DataSource = figures;

        }

        private void Initialize(Prescription prescription)
        {
            this.bdsPrescription.DataSource = prescription;
            this.bdsPrescriptionDetail.DataSource = prescription.PrescriptionDetails;

        }
    }
}
