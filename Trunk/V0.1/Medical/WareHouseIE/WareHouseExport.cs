using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        private Dictionary<string, List<WareHouseDetail>> dic = new Dictionary<string, List<WareHouseDetail>>();
        public WareHouseExport()
        {
            InitializeComponent();
            bdsMedicine.DataSource = repwh.GetByClinicId(AppContext.CurrentClinic.Id);
            txtClinic.Text = AppContext.CurrentClinic.Name;
            dateExport.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data to WareHouseIO
                WareHouseIO wareHouseIo = new WareHouseIO();
                wareHouseIo.ClinicId = AppContext.CurrentClinic.Id;
                wareHouseIo.Date = dateExport.Value.Date;
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
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            dateExport.Value = DateTime.Now;
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

        private void grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
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

        private void grd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (grd.Columns[e.ColumnIndex].Name == "Export")
            {
                MessageBox.Show("Số lượng xuất kho phải là số và lớn hơn 0");
            }
        }
    }
}
