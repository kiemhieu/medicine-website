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

namespace Medical
{
    public partial class CheckUpRegister : Form
    {
        private readonly IFigureRepository _figureRepo = new FigureRepository();
        private readonly IFigureDetailRepository _figureDetailRepo = new FigureDetailRepository();
        private readonly IPrescriptionRepository _precriptionRepo = new PrescriptionRepository();

        private const int DefaultVolumn = 7;
        private bool _isUpdate = false;
        private Patient _patient;
        private List<Figure> _figureList;
        private Prescription _prescription;
        private List<PrescriptionDetail> _prescriptionDetailList;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckUpRegister"/> class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public CheckUpRegister(Patient patient)
            : this()
        {
            Initialize(patient);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckUpRegister"/> class.
        /// </summary>
        public CheckUpRegister()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Initializes the specified patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        private void Initialize(Patient patient)
        {
            this._patient = patient;

            // Initialize combobox
            var figures = _figureRepo.GetAll();
            this.cboFigure.DataSource = figures;
            // Get Doctor Name
            this.txtDoctor.Text = AppContext.LoggedInUser.Name;

            this._prescription = _precriptionRepo.GetCurrent(patient.Id);
            var lastPrescription = _precriptionRepo.GetLastByPatient(patient.Id);
            if (this._prescription == null)
            {
                this._prescription = new Prescription
                                         {
                                             Date = DateTime.Today,
                                             RecheckDate = DateTime.Today.AddDays(DefaultVolumn),
                                             DoctorId = AppContext.LoggedInUser.Id,
                                             Doctor = AppContext.LoggedInUser,
                                             PatientId = patient.Id
                                         };

                this._prescriptionDetailList = new List<PrescriptionDetail>();

                if (lastPrescription != null)
                {
                    this._prescription.Note = lastPrescription.Note;
                    this._prescription.FigureId = lastPrescription.FigureId;

                    // Create FigureId
                    var figureDetails = this._figureDetailRepo.GetByFigure(lastPrescription.FigureId);
                    foreach (var figureDetail in figureDetails)
                    {
                        var prescriptionDetail = new PrescriptionDetail
                                                     {
                                                         FigureDetailId = figureDetail.Id,
                                                         MedicineId = figureDetail.MedicineId,
                                                         Medicine = figureDetail.Medicine,
                                                         VolumnPerDay = figureDetail.Volumn,
                                                         Day = DefaultVolumn,
                                                         Amount = DefaultVolumn * figureDetail.Volumn,
                                                         Version = 0
                                                     };
                        this._prescriptionDetailList.Add(prescriptionDetail);
                    }
                }

                this._prescription.PrescriptionDetails = this._prescriptionDetailList;
            }
            else
            {
                this._prescription.DoctorId = AppContext.LoggedInUser.Id;
                this._prescription.Doctor = AppContext.LoggedInUser;
            }

            Initialize(this._prescription);
        }

        /// <summary>
        /// Initializes the specified prescription.
        /// </summary>
        /// <param name="prescription">The prescription.</param>
        private void Initialize(Prescription prescription)
        {
            this.bdsPrescription.DataSource = prescription;
            this.bdsPrescriptionDetail.DataSource = prescription.PrescriptionDetails;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            var removeList = _prescriptionDetailList.Where(x => x.FigureDetailId != null).ToList();
            foreach (var item in removeList) _prescriptionDetailList.Remove(item);

            var comboboxEx = (ComboBoxEx) sender;
            var figureId = (int) comboboxEx.SelectedValue;
            var figureDetails = this._figureDetailRepo.GetByFigure(figureId);
            foreach (var figureDetail in figureDetails)
            {
                var prescriptionDetail = new PrescriptionDetail()
                                                            {
                                                                FigureDetailId = figureDetail.Id,
                                                                MedicineId = figureDetail.MedicineId,
                                                                Medicine = figureDetail.Medicine,
                                                                VolumnPerDay = figureDetail.Volumn,
                                                                Day = DefaultVolumn,
                                                                Amount = DefaultVolumn*figureDetail.Volumn,
                                                                Version = 0
                                                            };
                _prescriptionDetailList.Insert(0, prescriptionDetail);
            }

            this.bdsPrescriptionDetail.DataSource = _prescriptionDetailList;
        }
    }
}
