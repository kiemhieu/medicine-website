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
        private readonly IMedicineRepository _medicineRepo = new MedicineRepository();
        private readonly IFigureDetailRepository _figureDetailRepo = new FigureDetailRepository();
        private readonly IPrescriptionRepository _precriptionRepo = new PrescriptionRepository();

        private bool _isSkipUpdatingFigure = false;
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
            this._isSkipUpdatingFigure = true;

            try
            {
                this._patient = patient;

                // Initialize combobox
                var figures = _figureRepo.GetAll();
                this.cboFigure.DataSource = figures;
                // Get Doctor Name
                this.txtDoctor.Text = AppContext.LoggedInUser.Name;
                var medicines = _medicineRepo.GetAll();
                medicines.Insert(0, new Medicine() {Id = 0, Name = "..."});
                this.bdsMedicine.DataSource = medicines;

                // Get existing prescription
                this._prescription = _precriptionRepo.GetCurrent(patient.Id);
                var lastPrescription = _precriptionRepo.GetLastByPatient(patient.Id);

                // Binding data
                if (this._prescription == null)
                {
                    this._isUpdate = false;
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
                        // this._prescription.Note = lastPrescription.Note;
                        // this._prescription.FigureId = lastPrescription.FigureId;

                        // Create FigureId
                        //var figureDetails = this._figureDetailRepo.GetByFigure(lastPrescription.FigureId);
                        //foreach (var figureDetail in figureDetails)
                        //{
                        //    var prescriptionDetail = new PrescriptionDetail
                        //                                 {
                        //                                     No = this._prescriptionDetailList.Count + 1,
                        //                                     FigureDetailId = figureDetail.Id,
                        //                                     MedicineId = figureDetail.MedicineId,
                        //                                     Medicine = figureDetail.Medicine,
                        //                                     VolumnPerDay = figureDetail.Volumn,
                        //                                     Day = DefaultVolumn,
                        //                                     Amount = DefaultVolumn*figureDetail.Volumn,
                        //                                     Version = 0
                        //                                 };
                        //    this._prescriptionDetailList.Add(prescriptionDetail);
                        //}
                    }

                    this._prescription.PrescriptionDetails = this._prescriptionDetailList;
                }
                else
                {
                    this._isUpdate = true;
                    this._prescription.DoctorId = AppContext.LoggedInUser.Id;
                    this._prescription.Doctor = AppContext.LoggedInUser;
                }

                Initialize(this._prescription);
            } 
            finally
            {
                this._isSkipUpdatingFigure = false;
            }
        }

        /// <summary>
        /// Initializes the specified prescription.
        /// </summary>
        /// <param name="prescription">The prescription.</param>
        private void Initialize(Prescription prescription)
        {
            this.bdsPrescription.DataSource = prescription;
            this.bdsPrescriptionDetail.DataSource = prescription.PrescriptionDetails;
            ReupdateNo();
        }

        /// <summary>
        /// Reupdates the no.
        /// </summary>
        private void ReupdateNo()
        {
            var prescriptionList = (List<PrescriptionDetail>)this.bdsPrescriptionDetail.List;
            if (prescriptionList == null || prescriptionList.Count == 0) return;
            for (var i= 0; i<prescriptionList.Count; i++)
            {
                prescriptionList[i].No = i + 1;
            }
            this.bdsPrescriptionDetail.ResetBindings(true);
        }

        /// <summary>
        /// Gets the day.
        /// </summary>
        private int Day
        {
            get { return (this.txtReCheckDate.Value - this.txtCheckDate.Value).Days; }
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            bool result = true;
            if (this.Day <= 0)
            {
                this.errPro.SetError(txtReCheckDate, "Ngày tái khám không hợp lệ");
                result = false;
            }

            if (String.IsNullOrEmpty(txtStatus.Text))
            {
                this.errPro.SetError(txtStatus, "Chưa ghi lại trình trạng bệnh nhân");
                result = false;
            }

            var prescriptionList = (List<PrescriptionDetail>)this.bdsPrescriptionDetail.List;
            foreach (var item in prescriptionList)
            {
                item.Validate();
                if (!CheckDuplicate(item.MedicineId))
                {
                    result = false;
                    item.AddError("MedicineId", "Mã thuốc bị trùng nhau");
                }
                
                if (!item.IsValid) result = false;
                
            }

            return result;
        }

        /// <summary>
        /// Checks the duplicate.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private bool CheckDuplicate(int id)
        {
            var prescriptionList = (List<PrescriptionDetail>)this.bdsPrescriptionDetail.List;
            if (prescriptionList == null || prescriptionList.Count == 0) return true;
            if (prescriptionList.Count(x => x.MedicineId == id) > 1) return false;
            return true;
        }

        /// <summary>
        /// Handles the CellBeginEdit event of the dataGridViewX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellCancelEventArgs"/> instance containing the event data.</param>
        private void dataGridViewX1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var prescriptionDetail = (PrescriptionDetail) this.bdsPrescriptionDetail.Current;
            if (prescriptionDetail == null) e.Cancel = true;
            if (prescriptionDetail.FigureDetailId.HasValue && prescriptionDetail.FigureDetailId.Value > 0 && (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)) e.Cancel = true;
        }

        /// <summary>
        /// Handles the Click event of the buttonX4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDeleteMedicine_Click(object sender, EventArgs e)
        {
            // Delete selected row
            if (this.dataGridViewX1.SelectedRows.Count == 0) return;
            var prescriptionList = (List<PrescriptionDetail>)this.bdsPrescriptionDetail.List;
            var row = this.dataGridViewX1.SelectedRows[0];
            var item = prescriptionList[row.Index];
            if (item.FigureDetailId.HasValue && item.FigureDetailId > 0)
            {
                MessageBox.Show(this, 
                                "Thuốc theo phác đồ nên không thể xóa.", 
                                "Thông báo", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            this.dataGridViewX1.Rows.Remove(this.dataGridViewX1.SelectedRows[0]);
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.dataGridViewX1.EndEdit();
            if (!this.ValidateData()) return;
            this._prescription.CreatedUser = AppContext.LoggedInUser.Id;
            this._prescription.LastUpdatedUser = AppContext.LoggedInUser.Id;
            // this._prescription.PrescriptionDetails = this._prescriptionDetailList;

            var message = !this._isUpdate ? "Ghi lại dữ liệu vừa tạo ?" : "Cập nhập dữ liệu vừa thay đổi ?";
            var result = MessageBox.Show(this, message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (this._isUpdate)
            {
                this._precriptionRepo.Update(this._prescription);
            } else
            {
                
                this._precriptionRepo.Insert(this._prescription);
            }
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboFigure control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSkipUpdatingFigure) return;

            var removeList = _prescriptionDetailList.Where(x => x.FigureDetailId != null).ToList();
            foreach (var item in removeList) _prescriptionDetailList.Remove(item);


            var comboboxEx = (ComboBoxEx)sender;
            var figureId = (int)comboboxEx.SelectedValue;
            var figureDetails = this._figureDetailRepo.GetByFigure(figureId);
            foreach (var figureDetail in figureDetails)
            {
                var prescriptionDetail = new PrescriptionDetail()
                {
                    FigureDetailId = figureDetail.Id,
                    MedicineId = figureDetail.MedicineId,
                    Medicine = figureDetail.Medicine,
                    VolumnPerDay = figureDetail.Volumn,
                    Day = this.Day,
                    Amount = DefaultVolumn * figureDetail.Volumn,
                    Version = 0
                };
                _prescriptionDetailList.Insert(0, prescriptionDetail);
            }

            this.bdsPrescriptionDetail.DataSource = _prescriptionDetailList;
            // this.bdsPrescriptionDetail.EndEdit();
            ReupdateNo();
        }

        /// <summary>
        /// Handles the ListChanged event of the bdsPrescriptionDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ListChangedEventArgs"/> instance containing the event data.</param>
        private void bdsPrescriptionDetail_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                var source = (BindingSource)sender;
                var item = source.List[e.NewIndex] as PrescriptionDetail;
                item.No = source.List.Count;
                item.Day = this.Day;
            }
        }

        /// <summary>
        /// Handles the CellEndEdit event of the dataGridViewX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var prescriptionDetail = (PrescriptionDetail)this.bdsPrescriptionDetail.Current;
            if (prescriptionDetail == null) return;
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) prescriptionDetail.Calculate();
            prescriptionDetail.Validate();
            if (CheckDuplicate(prescriptionDetail.MedicineId)) prescriptionDetail.AddError("MedicineId", "Thuốc đã tồn tại");
        }

        /// <summary>
        /// Handles the ValueObjectChanged event of the txtReCheckDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtReCheckDate_ValueObjectChanged(object sender, EventArgs e)
        {
            var prescriptionList = (List<PrescriptionDetail>)this.bdsPrescriptionDetail.List;
            if (prescriptionList == null) return;
            foreach (var item in prescriptionList)
            {
                item.Day = this.Day;
                item.Calculate();
            }

            this.bdsPrescriptionDetail.ResetBindings(true);
        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }
    }
}
