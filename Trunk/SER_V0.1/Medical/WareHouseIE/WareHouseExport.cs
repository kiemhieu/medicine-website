using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Forms.UI;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;
using Medical.Data;
using Medical.Data.Entities;

namespace Medical.WareHouseIE
{
    public partial class WareHouseExport : DockContent
    {
        private readonly ClinicRepository _repClinic = new ClinicRepository();
        private readonly DefineRepository _repDefine = new DefineRepository();
        private readonly MedicineRepository _repMedicine = new MedicineRepository();
        private readonly WareHouseDetailRepository _repwhDetail = new WareHouseDetailRepository();
        private readonly WareHouseRepository _repwh = new WareHouseRepository();
        private readonly WareHouseIORepository _repwhIo = new WareHouseIORepository();
        private readonly WareHouseExportAllocateRepository _whExport = new WareHouseExportAllocateRepository();
        private readonly WareHouseIODetailRepository _repwhIoDetail = new WareHouseIODetailRepository();
        private readonly IVWareHouseDetailRespository _vwarehouseDetailRep = new VWareHouseDetailRepository();
        private readonly VWareHouseDetailRepository vwarehouseDetailRepo = new VWareHouseDetailRepository();

        private readonly Dictionary<string, List<WareHouseDetail>> dic = new Dictionary<string, List<WareHouseDetail>>();

        private WareHouseIO _warehouseIo;
        private List<WareHouseIODetail> _warehouseIoDetail;

        
        public WareHouseExport()
        {
            InitializeComponent();

            // init medicine list
            var medicineList = _repMedicine.GetAll();
            medicineList.Insert(0, new Medicine(){ Id = 0, Name = ""});
            bdsMedicine.DataSource = medicineList;
            bdsUnit.DataSource = _repDefine.GetUnit();

            var column = (DataGridViewTextBoxDropDownColumn) grd.Columns["LotNo"];
            if (column != null) column.ButtonCustomClick += ColumnButtonCustomClick;

            //bdsMedicine.DataSource = repwh.GetByClinicId(AppContext.CurrentClinic.Id);
            //txtClinic.Text = AppContext.CurrentClinic.Name;
            //txtDate.Value = DateTime.Now;

            Initialize();

            this.txtDate.ForeColor = Color.Black;
        }

        private void Initialize()
        {
            txtClinic.Text = AppContext.CurrentClinic.Name;
            txtDeliverer.Text = AppContext.LoggedInUser.Name;

            // Init warehouse
            _warehouseIo = new WareHouseIO
                               {
                                   ClinicId = AppContext.CurrentClinic.Id,
                                   Date = DateTime.Today,
                                   Type = WarehouseIOType.Output
                               };
            bdsWareHouseIO.DataSource = _warehouseIo;
            
            // Init WarehouseIODetail
            _warehouseIoDetail = new List<WareHouseIODetail>();
            bdsWarehouseIODetail.DataSource = _warehouseIoDetail;

            this.grd.EndEdit();
            this.grd.ResetBindings();
            this.grd.Refresh();
        }

        private void ColumnButtonCustomClick(object sender, EventArgs e)
        {
            var warehouseIoDetail = (WareHouseIODetail)this.bdsWarehouseIODetail.Current;
            if (warehouseIoDetail == null || warehouseIoDetail.MedicineId == 0) return;
            var chooser = new MedicineOutputChooser(warehouseIoDetail.MedicineId, this._warehouseIo.Date);
            var result = chooser.ShowDialog(this);
            if (result == DialogResult.No) return;

            var warehouseDetail = chooser.SelectedVWareHouseDetail;
            var item = (DataGridViewTextBoxDropDownColumn) sender;
            item.Text = warehouseDetail.LotNo;
            warehouseIoDetail.LotNo = warehouseDetail.LotNo;
            grd.CurrentCell.Value = warehouseDetail.LotNo;
            //warehouseIoDetail.ExpireDate = warehouseIoDetail.ExpireDate;
            //warehouseIoDetail.LotNo = warehouseIoDetail.LotNo;
            //warehouseIoDetail.InStockQty = warehouseIoDetail.Qty;

            this.grd.EndEdit();
            this.grd.ResetBindings();
            this.grd.Refresh();
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            if (!ValidateRowData()) return;
            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q005", "Đồng ý xuất kho lô thuốc này ?");
            if (dialogResult == DialogResult.No) return;

            try
            {
                this.Enabled = true;
                this.Cursor = Cursors.WaitCursor;
                this._repwhIo.WarehouseOutputRegister(this._warehouseIo, this._warehouseIoDetail);
                MessageDialog.Instance.ShowMessage(this, "MSG0005", "Tạo phiếu nhập kho thành công.");
                this.ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            Initialize();
        }

        private void ClearData()
        {
            Initialize();
        }

        private void GrdCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var warehouseIoDetail = (WareHouseIODetail)this.bdsWarehouseIODetail.Current;

            switch (e.ColumnIndex)
            {
                case 0:

                    // Get medicine
                    if (warehouseIoDetail != null)
                    {
                        var medicine = _repMedicine.GetById(warehouseIoDetail.MedicineId);
                        warehouseIoDetail.Unit = medicine.Unit;

                        var warehouse = _repwh.GetByIdMedicine(medicine.Id, AppContext.CurrentClinic.Id);
                        warehouseIoDetail.TotalQty = (warehouse == null ? 0 : warehouse.Volumn);
                        warehouseIoDetail.LotNo = String.Empty;
                        warehouseIoDetail.InStockQty = 0;
                        warehouseIoDetail.Qty = 0;
                    }
                    break;

                case 4:

                    if (warehouseIoDetail != null)
                    {
                        // lotNo
                        var vwarehouseDetail = _vwarehouseDetailRep.Get(warehouseIoDetail.MedicineId, AppContext.CurrentClinic.Id, warehouseIoDetail.LotNo);
                        warehouseIoDetail.InStockQty = vwarehouseDetail == null ? 0 : vwarehouseDetail.Qty;
                        if (vwarehouseDetail != null) warehouseIoDetail.ExpireDate = vwarehouseDetail.ExpiredDate;
                        warehouseIoDetail.Qty = 0;
                    }
                    break;

                case 7:
                   
                    break;

            }
            

            /*
            if (grd.Columns[e.ColumnIndex].Name == "cboMedicine")
            {
                if (grd.Rows[e.RowIndex].Cells["cboMedicine"].Value != null)
                {
                    if (ValidateRowData(grd.Rows[e.RowIndex].Cells["cboMedicine"].Value.ToString()))
                    {
                        var warehouseItem = repwh.GetByIdMedicine(int.Parse(grd.Rows[e.RowIndex].Cells["cboMedicine"].Value.ToString()), AppContext.CurrentClinic.Id);
                        grd.Rows[e.RowIndex].Cells["Volumn"].Value = warehouseItem.Volumn;
                        grd.Rows[e.RowIndex].Cells["MinAllowed"].Value = warehouseItem.MinAllowed;
                        grd.Rows[e.RowIndex].Cells["MedicineId"].Value = warehouseItem.MedicineId;
                        grd.Rows[e.RowIndex].Cells["Id"].Value = warehouseItem.Id;
                        grd.Rows[e.RowIndex].Cells["ClinicId"].Value = warehouseItem.ClinicId;
                        grd.Rows[e.RowIndex].Cells["Export"].ReadOnly = false;
                    }
                    else
                    {
                        MessageBox.Show("Loại thuốc này đã tồn tại trong danh sách xuất kho");
                        grd.Rows[e.RowIndex].Cells["Export"].ReadOnly = true;
                    }
                }
            }
            else if (grd.Columns[e.ColumnIndex].Name == "Export")
            {
                int export = 0;
                if (grd.Rows[e.RowIndex].Cells["Export"].Value != null && !int.TryParse(grd.Rows[e.RowIndex].Cells["Export"].Value.ToString(), out export))
                {
                    grd.Rows[e.RowIndex].Cells["Export"].Value = 0;
                }
                else if (export > int.Parse(grd.Rows[e.RowIndex].Cells["Volumn"].Value.ToString()))
                {
                    grd.Rows[e.RowIndex].Cells["Export"].Value = grd.Rows[e.RowIndex].Cells["Volumn"].Value;
                }
            }
             */

            this.grd.ResetBindings();
            this.grd.Refresh();
        }

        private bool ValidateRowData()
        {

            this.errorProvider1.Clear();
            var result = true;

            this._warehouseIo.Validate();

            if (!this._warehouseIo.IsValid) result = false;
            if (this._warehouseIoDetail.Count == 0) result = false;

            foreach (var item in this._warehouseIoDetail)
            {
                item.ValidateOutput();
                if (!item.IsValid) result = false;
            }

            if (!result) MessageDialog.Instance.ShowMessage(this, "MSG0004");
            this.errorProvider1.UpdateBinding();
            return result;
            return true;
        }

        private void GrdCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (grd.Columns[e.ColumnIndex].Name == "btnExportAllocate")
            //{
            //    WareHouse item = bdsWareHouse[e.RowIndex] as WareHouse;
            //    if (item.Export > 0)
            //    {
            //        string key = grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString();
            //        List<WareHouseDetail> listWareHouseDetail = new List<WareHouseDetail>();
            //        if (item.Flag)
            //            listWareHouseDetail = dic[key];
            //        ExportAllocateDetail frm = new ExportAllocateDetail(item.Id, item.MedicineId, item.Export, listWareHouseDetail, item.Flag);
            //        frm.Flag = item.Flag;
            //        frm.StartPosition = FormStartPosition.CenterScreen;
            //        frm.ShowDialog();
            //        if (frm.Flag)
            //        {
            //            item.Flag = true;
            //            if (dic.Keys.Contains(key))
            //                dic[key] = frm.ListWareHouseDetail;
            //            else
            //                dic.Add(key, frm.ListWareHouseDetail);
            //        }
            //    }
            //}
        }

        private void GrdDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (grd.Columns[e.ColumnIndex].Name == "Export")
            //{
            //    MessageBox.Show("Số lượng xuất kho phải là số và lớn hơn 0");
            //}
        }

        private void BdsWarehouseIODetailAddingNew(object sender, AddingNewEventArgs e)
        {
            
        }

        private void BdsWarehouseIODetailListChanged(object sender, ListChangedEventArgs e)
        {
            /*
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                MessageBox.Show("Xin chào");
            }
            */
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

        private void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
        {
            if (this.bdsWarehouseIODetail.Current == null) e.Cancel = true;
        }
    }
}
