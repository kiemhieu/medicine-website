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
using Medical.Forms.UI;


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
        private Boolean _isWarning;

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
            InitError();
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
                // thangnn edit
                var figures = _figureRepo.GetByClinicId(AppContext.CurrentClinic.Id);
                
                this.cboFigure.DataSource = figures;
                
                // Get Doctor Name
                this.txtDoctor.Text = AppContext.LoggedInUser.Name;
                var medicines = _medicineRepo.GetAll();
                medicines.Insert(0, new Medicine() { Id = 0, Name = "..." });
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
                                                 PatientId = patient.Id,
                                                 CreatedUser = AppContext.LoggedInUser.Id,
                                                 LastUpdatedUser = AppContext.LoggedInUser.Id,
                                                 ClinicId = AppContext.CurrentClinic.Id
                                             };

                    this._prescriptionDetailList = new List<PrescriptionDetail>();
                    this._prescription.PrescriptionDetails = this._prescriptionDetailList;
                }
                else
                {
                    this._isUpdate = true;
                    this._prescription.DoctorId = AppContext.LoggedInUser.Id;
                    this._prescription.LastUpdatedUser = AppContext.LoggedInUser.Id;
                    foreach (var detailItem in this._prescription.PrescriptionDetails)
                    {
                        detailItem.MedicineName = detailItem.Medicine.Name;
                        detailItem.TradeName= detailItem.Medicine.TradeName;
                        detailItem.UnitName= detailItem.Medicine.Define.Name;
                    }
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
            this.errPro.Clear();
            InitError();
            _isWarning = false;

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
            if (prescriptionList.Count == 0)
            {
                this.errPro.SetError(dataGridViewX1, "Chưa nhập đơn thuốc");
                result = false;
            }

            foreach (var item in prescriptionList)
            {
                item.Validate();
                if (!CheckDuplicate(item.MedicineId))
                {
                    result = false;
                    item.AddError("MedicineId", "Mã thuốc bị trùng nhau");
                }

                if (!item.IsValid) result = false;
                if (item.InventoryVolumn <= 0)
                {
                    // result = false;
                    _isWarning = true;
                    item.AddError("InventoryVolumn", "Hết thuốc trong kho");
                }
            }

            this.dataGridViewX1.Refresh();
            return result;
        }

        /// <summary>
        /// Inits the error.
        /// </summary>
        private void InitError()
        {
            this.errPro.SetIconPadding(this.dataGridViewX1, -8);
            this.errPro.SetIconAlignment(this.dataGridViewX1, ErrorIconAlignment.TopRight);

            this.errPro.SetIconPadding(txtReCheckDate, -8);
            this.errPro.SetIconAlignment(txtReCheckDate, ErrorIconAlignment.TopRight);

            this.errPro.SetIconPadding(txtStatus, -8);
            this.errPro.SetIconAlignment(txtStatus, ErrorIconAlignment.TopRight);
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
        private void DataGridViewX1CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var prescriptionDetail = (PrescriptionDetail)this.bdsPrescriptionDetail.Current;
            if (prescriptionDetail == null) e.Cancel = true;
            // if (prescriptionDetail.FigureDetailId.HasValue && prescriptionDetail.FigureDetailId.Value > 0 && (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)) e.Cancel = true;
        }

        /// <summary>
        /// Handles the Click event of the buttonX4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnDeleteMedicineClick(object sender, EventArgs e)
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
        private void BtnSaveClick(object sender, EventArgs e)
        {
            this.dataGridViewX1.EndEdit();
            if (!this.ValidateData()) return;
            if (_isWarning)
            {
                var warningConfirm = MessageDialog.Instance.ShowMessage(this, "Q005", "Có loại thuốc không còn trong kho. Đồng ý tiếp tục ghi lại dữ liệu ?");
                if (warningConfirm == DialogResult.No) return;
            }

            var result = MessageDialog.Instance.ShowMessage(this, "Q011");
            if (result == DialogResult.No) return;

            try
            {
                if (this._isUpdate)
                    this._precriptionRepo.Update(this._prescription);
                else
                    this._precriptionRepo.Insert(this._prescription);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageDialog.Instance.ShowMessage(this, "ERR0002", ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboFigure control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CboFigureSelectedIndexChanged(object sender, EventArgs e)
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
                    VolumnPerDay = figureDetail.Volumn,
                    TradeName = figureDetail.Medicine.TradeName,
                    MedicineName = figureDetail.Medicine.Name,
                    UnitName = figureDetail.Medicine.Define.Name,
                    Day = this.Day,
                    Amount = DefaultVolumn * figureDetail.Volumn,
                    Version = 0
                };
                prescriptionDetail.InventoryVolumn = _medicineRepo.GetInventoryVolumeWareHouseByMedicineId(AppContext.CurrentClinic.Id, prescriptionDetail.MedicineId);
                _prescriptionDetailList.Insert(0, prescriptionDetail);
            }

            this.bdsPrescriptionDetail.DataSource = _prescriptionDetailList;
            this.bdsPrescriptionDetail.ResetBindings(false);
            this.dataGridViewX1.Update();

        }

        /// <summary>
        /// Handles the CellEndEdit event of the dataGridViewX1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var prescriptionDetail = (PrescriptionDetail)this.bdsPrescriptionDetail.Current;
            if (prescriptionDetail == null) return;

            switch (e.ColumnIndex)
            {
                case 0:
                    var medicine = _medicineRepo.GetById(prescriptionDetail.MedicineId);
                    if (medicine == null)
                    {
                        prescriptionDetail.MedicineName = String.Empty;
                        prescriptionDetail.TradeName = String.Empty;
                        prescriptionDetail.UnitName = String.Empty;
                        prescriptionDetail.InventoryVolumn = 0;
                        break;
                    }
                    prescriptionDetail.MedicineName = medicine.Name;
                    prescriptionDetail.TradeName = medicine.TradeName;
                    prescriptionDetail.UnitName = medicine.Define.Name;
                    prescriptionDetail.InventoryVolumn = _medicineRepo.GetInventoryVolumeWareHouseByMedicineId(AppContext.CurrentClinic.Id, prescriptionDetail.MedicineId);
                    break;
                case 3:
                    prescriptionDetail.Calculate();
                    break;
                case 4 :
                    prescriptionDetail.Calculate();
                    break;
                default:
                    break;
            }

            // if (e.ColumnIndex == 2 || e.ColumnIndex == 3) prescriptionDetail.Calculate();
            // prescriptionDetail.Validate();
            // prescriptionDetail.InventoryVolumn = _medicineRepo.GetInventoryVolumeWareHouseByMedicineId(AppContext.CurrentClinic.Id, prescriptionDetail.MedicineId);
            if (!CheckDuplicate(prescriptionDetail.MedicineId)) prescriptionDetail.AddError("MedicineId", "Thuốc đã tồn tại");
        }

        /// <summary>
        /// Handles the ValueObjectChanged event of the txtReCheckDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtReCheckDateValueObjectChanged(object sender, EventArgs e)
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
