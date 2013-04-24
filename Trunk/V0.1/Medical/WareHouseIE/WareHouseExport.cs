using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;
using Medical.Data;
using Medical.Data.Entities;

namespace Medical.WareHouseIE
{
    public partial class WareHouseExport : DockContent
    {
        private readonly ClinicRepository repClinic = new ClinicRepository();
        private readonly DefineRepository repDefine = new DefineRepository();
        private readonly MedicineRepository repMedicine = new MedicineRepository();
        private readonly WareHouseDetailRepository repwhDetail = new WareHouseDetailRepository();
        private readonly WareHouseRepository repwh = new WareHouseRepository();
        private readonly WareHouseIORepository _repwhIo = new WareHouseIORepository();
        private readonly WareHouseExportAllocateRepository whExport = new WareHouseExportAllocateRepository();
        private readonly WareHouseIODetailRepository _repwhIoDetail = new WareHouseIODetailRepository();
        private readonly IVWareHouseDetailRespository _vwarehouseDetailRep = new VWareHouseDetailRepository();

        private readonly Dictionary<string, List<WareHouseDetail>> dic = new Dictionary<string, List<WareHouseDetail>>();
        public WareHouseExport()
        {
            InitializeComponent();

            var medicineList = repMedicine.GetAll();
            medicineList.Insert(0, new Medicine(){ Id = 0, Name = ""});
            bdsMedicine.DataSource = medicineList;
            bdsUnit.DataSource = repDefine.GetUnit();

            var column = (DataGridViewTextBoxDropDownColumn) grd.Columns["LotNo"];
            if (column != null) column.ButtonCustomClick += ColumnButtonCustomClick;

            //bdsMedicine.DataSource = repwh.GetByClinicId(AppContext.CurrentClinic.Id);
            //txtClinic.Text = AppContext.CurrentClinic.Name;
            //txtDate.Value = DateTime.Now;
        }

        private void ColumnButtonCustomClick(object sender, EventArgs e)
        {
            var warehouseIoDetail = (WareHouseIODetail)this.bdsWarehouseIODetail.Current;
            if (warehouseIoDetail == null || warehouseIoDetail.MedicineId == 0) return;
            var chooser = new MedicineOutputChooser(warehouseIoDetail.MedicineId);
            var result = chooser.ShowDialog(this);
            if (result == DialogResult.Cancel) return;

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
            try
            {
                //Insert data to WareHouseIO
                WareHouseIO wareHouseIo = new WareHouseIO();
                wareHouseIo.ClinicId = AppContext.CurrentClinic.Id;
                wareHouseIo.Date = txtDate.Value.Date;
                wareHouseIo.Person = txtDeliverer.Text;
                wareHouseIo.Address = txtAddress.Text;
                wareHouseIo.AttachmentNo = txtOriginalNo.Text;
                //wareHouseIo.Recipient = txtRecipient.Text;
                wareHouseIo.Phone = txtPhone.Text;
                wareHouseIo.Type = "1";
                wareHouseIo.Version = 0;
                wareHouseIo.No = txtNo.Text;
                wareHouseIo.Note = txtNote.Text;
                WareHouseIORepository wareHouseIoRepository = new WareHouseIORepository();
                wareHouseIoRepository.Insert(wareHouseIo);

                foreach (WareHouse wareHouse in bdsWareHouse)
                {
                    if (wareHouse.Export > 0)
                    {
                        //update data to WareHouse                     
                        if (wareHouse != null)
                        {
                            wareHouse.Volumn -= wareHouse.Export;
                            repwh.Update(wareHouse);
                        }

                        List<WareHouseDetail> list = new List<WareHouseDetail>();
                        if (dic.Keys.Contains(wareHouse.MedicineId.ToString()))
                            list = dic[wareHouse.MedicineId.ToString()];
                        else
                            list = repwhDetail.GetMeicineExport(wareHouse.Id, wareHouse.MedicineId, wareHouse.Export);

                        foreach (var wareHouseDetail in list)
                        {
                            if (wareHouseDetail.ExportVolumn > 0)
                            {
                                //Update WareHouseDetail
                                wareHouseDetail.CurrentVolumn -= wareHouseDetail.ExportVolumn;
                                repwhDetail.Update(wareHouseDetail);

                                //Insert data to WareHouseIODetail
                                WareHouseIODetail item = new WareHouseIODetail();
                                item.WareHouseIOId = wareHouseIo.Id;
                                item.LotNo = wareHouseDetail.LotNo;
                                item.Type = "1";
                                item.MedicineId = wareHouseDetail.MedicineId;
                                item.Qty = wareHouseDetail.ExportVolumn;
                                item.Unit = wareHouseDetail.Unit;
                                item.UnitPrice = wareHouseDetail.UnitPrice;
                                item.ExpireDate = wareHouseDetail.ExpiredDate;
                                _repwhIoDetail.Insert(item);

                                //Insert whExportAllocate
                                WareHouseExportAllocate wareHouseExportAllocate = new WareHouseExportAllocate();
                                wareHouseExportAllocate.WareHouseDetailId = wareHouseDetail.Id;
                                wareHouseExportAllocate.WareHouseIODetailId = item.Id;
                                wareHouseExportAllocate.Volumn = wareHouseDetail.ExportVolumn;
                                wareHouseExportAllocate.Unit = wareHouseDetail.Unit;
                                whExport.Insert(wareHouseExportAllocate);
                            }
                        }
                    }
                }

                MessageBox.Show("Xuất kho thành công!");
                ClearData();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            txtDate.Value = DateTime.Now;
            txtDeliverer.Text = string.Empty;
            txtOriginalNo.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtNo.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtRecipient.Text = string.Empty;
            bdsWareHouse.DataSource = new List<WareHouse>();
            grd.Rows.Clear();
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
                        var medicine = repMedicine.GetById(warehouseIoDetail.MedicineId);
                        warehouseIoDetail.Unit = medicine.Unit;

                        var warehouse = repwh.GetByIdMedicine(medicine.Id, AppContext.CurrentClinic.Id);
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

        private bool ValidateRowData(string medicineId)
        {
            foreach (WareHouse item in bdsWareHouse)
            {
                if (item.MedicineId != null && item.MedicineId.ToString() == medicineId)
                {
                    return false;
                }
            }

            return true;
        }

        private void GrdCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (grd.Columns[e.ColumnIndex].Name == "btnExportAllocate")
            {
                WareHouse item = bdsWareHouse[e.RowIndex] as WareHouse;
                if (item.Export > 0)
                {
                    string key = grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString();
                    List<WareHouseDetail> listWareHouseDetail = new List<WareHouseDetail>();
                    if (item.Flag)
                        listWareHouseDetail = dic[key];
                    ExportAllocateDetail frm = new ExportAllocateDetail(item.Id, item.MedicineId, item.Export, listWareHouseDetail, item.Flag);
                    frm.Flag = item.Flag;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    if (frm.Flag)
                    {
                        item.Flag = true;
                        if (dic.Keys.Contains(key))
                            dic[key] = frm.ListWareHouseDetail;
                        else
                            dic.Add(key, frm.ListWareHouseDetail);
                    }
                }
            }
        }

        private void GrdDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (grd.Columns[e.ColumnIndex].Name == "Export")
            {
                MessageBox.Show("Số lượng xuất kho phải là số và lớn hơn 0");
            }
        }

        private void BdsWarehouseIODetailAddingNew(object sender, AddingNewEventArgs e)
        {
            
        }

        private void BdsWarehouseIODetailCurrentItemChanged(object sender, EventArgs e)
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
    }
}
