using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DevComponents.DotNetBar.Controls;
using Medical.Forms.Enums;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;
using System.Windows.Forms;
using Medical.Data.Entities;
using Medical.Data;
using Medical.Forms.UI;

namespace Medical.WareHouseIE
{
    public partial class WareHouseImport : DockContent
    {
        private readonly MedicineRepository _medicineRepository = new MedicineRepository();
        private readonly ClinicRepository _clinicRepository = new ClinicRepository();
        private readonly DefineRepository _defineRepository = new DefineRepository();
        private readonly WareHouseDetailRepository _wareHowDetailRepository = new WareHouseDetailRepository();
        private readonly WareHouseRepository _wareHouseRepository = new WareHouseRepository();
        private readonly WareHouseIORepository _wareHouseIoRepository = new WareHouseIORepository();
        private readonly WareHouseIODetailRepository _wareHouseIoDetailRepository = new WareHouseIODetailRepository();

        private WareHouseIO _wareHouseIO;
        private List<WareHouseIODetail> _warehouseIODetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="WareHouseImport"/> class.
        /// </summary>
        public WareHouseImport()
        {
            InitializeComponent();

            Initialize();

            InitializeWareHouseIO();

        }

        private void Initialize()
        {
            List<Medicine> medicines = this._medicineRepository.GetAll();
            medicines.Insert(0, new Medicine() { Id = 0, Name = "..." });

            List<Define> units = this._defineRepository.GetUnit();
            units.Insert(0, new Define() { Id = 0, Name = "..." });

            this.bdsUnit.DataSource = units;
            this.bdsMeidcine.DataSource = medicines;
        }

        /// <summary>
        /// Fills to grid.
        /// </summary>
        private void InitializeWareHouseIO()
        {
            // Create warehouse input
            this._wareHouseIO = new WareHouseIO
            {
                ClinicId = AppContext.CurrentClinic.Id,
                Type = WarehouseIO.Input,
                Date = DateTime.Now,
                CreatedUser = AppContext.LoggedInUser.Id
            };

            this.txtClinic.Text = AppContext.CurrentClinic.Name;
            this.txtRecipient.Text = AppContext.LoggedInUser.Name;

            // Create warehouse Output
            this._warehouseIODetails = new List<WareHouseIODetail>();

            this.bdsWareHouse.DataSource = this._wareHouseIO;
            this.bdsWareHouse.ResetBindings(true);

            this.bdsWareHouseIODetail.DataSource = this._warehouseIODetails;
            this.bdsWareHouseIODetail.ResetBindings(true);
            this.grd.ResetBindings();
            
            
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            ClearData();
        }      

        private void GrdCellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && this.grd[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    var warehouseIODetail = (WareHouseIODetail)this.bdsWareHouseIODetail.Current;
                    var medicineId = (int)this.grd[e.ColumnIndex, e.RowIndex].Value;
                    var medicine = _medicineRepository.GetById(medicineId);

                    if (medicine == null)
                    {
                        grd.Rows[e.RowIndex].Cells[1].Value = "";
                        warehouseIODetail.Unit = 0;
                    }
                    else
                    {
                        grd.Rows[e.RowIndex].Cells[1].Value = medicine.TradeName;
                        warehouseIODetail.Unit = medicine.Unit;
                    }

                }

                /*
                int volumn = 0;
                int unitPrice = 0;

                if (grd.Columns[e.ColumnIndex].Name == "cboMedicine")
                {
                    if (grd.Rows[e.RowIndex].Cells["cboMedicine"].Value != null)
                    {
                        var medicine = _medicineRepository.GetById(int.Parse(grd.Rows[e.RowIndex].Cells["cboMedicine"].Value.ToString()));
                        grd.Rows[e.RowIndex].Cells["MedicineId"].Value = medicine.Id;
                        grd.Rows[e.RowIndex].Cells["Unit"].Value = medicine.Define.Id;
                        grd.Rows[e.RowIndex].Cells["UnitName"].Value = medicine.Define.Name;
                    }
                }
                */
                if (grd.Columns[e.ColumnIndex].Name == "Qty" || grd.Columns[e.ColumnIndex].Name == "UnitPrice")
                {
                    var volumn = 0;
                    var unitPrice = 0;
                    if (grd.Rows[e.RowIndex].Cells["Qty"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["Qty"].Value.ToString(), out volumn) && grd.Rows[e.RowIndex].Cells["UnitPrice"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString(), out unitPrice))
                    {
                        grd.Rows[e.RowIndex].Cells["Amount"].Value = unitPrice * volumn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void GrdDataError(object sender, DataGridViewDataErrorEventArgs e)
        {

         }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (!ValidateItemData()) return;

            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q005", "Nhập kho lô thuốc mới ?");
            if (dialogResult == DialogResult.No) return;

            try
            {
                this.Enabled = true;
                this.Cursor = Cursors.WaitCursor;
                this._wareHouseIoRepository.WarehouseInputRegister(this._wareHouseIO, this._warehouseIODetails);
                MessageDialog.Instance.ShowMessage(this, "MSG0005", "Tạo phiếu nhập kho thành công.");
                this.ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }}

        private void ClearData()
        {
            InitializeWareHouseIO();
        }

        /// <summary>
        /// Validates the item data.
        /// </summary>
        /// <returns></returns>
        private bool ValidateItemData()
        {
            this.errorProvider1.Clear();
            var result = true;

            this._wareHouseIO.Validate();

            if (!this._wareHouseIO.IsValid) result = false;
            if (this._warehouseIODetails.Count == 0) result = false;

            foreach ( var item in this._warehouseIODetails)
            {
                item.Validate();
                if (!item.IsValid) result = false;
            }

            if (!result) MessageDialog.Instance.ShowMessage(this, "MSG0004");
            this.errorProvider1.UpdateBinding();
            return result;
        }

        private void GrdDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void BdsWareHouseIODetailDataMemberChanged(object sender, EventArgs e)
        {

        }

        private void BdsWareHouseIODetailCurrentItemChanged(object sender, EventArgs e)
        {

        }

        private void BdsWareHouseIODetailListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                
            }
        }
    }
}
