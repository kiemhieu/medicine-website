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
        private readonly WareHouseIODetailRepository _repwhIoDetail = new WareHouseIODetailRepository();

        public WareHouseExport()
        {
            InitializeComponent();
            bdsMedicine.DataSource = repwh.GetByClinicId(AppContext.CurrentClinic.Id);
            txtClinic.Text = AppContext.CurrentClinic.Name;
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
                //wareHouseIo.Recipient = txtRecipient.Text;
                wareHouseIo.Phone = txtPhone.Text;
                wareHouseIo.Type = "1";
                wareHouseIo.Version = 0;
                wareHouseIo.No = txtNo.Text;
                wareHouseIo.Note = txtNote.Text;
                WareHouseIORepository wareHouseIoRepository = new WareHouseIORepository();
                wareHouseIoRepository.Insert(wareHouseIo);

                foreach (DataGridViewRow row in grd.Rows)
                {
                    if (row.Cells["Volumn"].Value != null)
                    {
                        int medicineId = int.Parse(row.Cells["MedicineIdHidden"].Value.ToString());
                        int export = int.Parse(row.Cells["Export"].Value.ToString());
                        //update data to WareHouse
                        var wareHouse = repwh.GetByIdMedicine(medicineId, AppContext.CurrentClinic.Id);
                        if (wareHouse != null)
                        {
                            wareHouse.Volumn -= export;
                            repwh.Update(wareHouse);
                        }

                        var list = repwhDetail.GetMeicineExport(wareHouse.Id, medicineId);

                        foreach (var obj in list)
                        {
                            if (obj.CurrentVolumn >= export)
                            {
                                //Update whDetail
                                obj.CurrentVolumn -= export;
                                repwhDetail.Update(obj);

                                //Insert data to WareHousePaperDetail
                                WareHouseIODetail item = new WareHouseIODetail();
                                //item.WareHousePaperId = wareHouseIo.Id;
                                item.LotNo = obj.LotNo;
                                //item.Type = 1;
                                item.MedicineId = obj.MedicineId;
                                //item.Volumn = export;
                                //item.Unit = obj.Unit;
                                item.UnitPrice = obj.UnitPrice;
                                item.ExpireDate = obj.ExpiredDate;
                                _repwhIoDetail.Insert(item);

                                //Insert whExportAllocate
                                WareHouseExportAllocate wareHouseExportAllocate = new WareHouseExportAllocate();
                                wareHouseExportAllocate.WareHouseDetailId = obj.Id;
                                wareHouseExportAllocate.WareHoudePaperDetailId = item.Id;
                                wareHouseExportAllocate.Volumn = export;
                                wareHouseExportAllocate.Unit = obj.Unit;
                                // whExport.Insert(wareHouseExportAllocate);
                                break;
                            }
                            else
                            {
                                //Insert data to WareHousePaperDetail
                                WareHouseIODetail item = new WareHouseIODetail();
                                //item.WareHousePaperId = wareHouseIo.Id;
                                item.LotNo = obj.LotNo;
                                //item.Type = 1;
                                item.MedicineId = obj.MedicineId;
                                //item.Volumn = obj.CurrentVolumn;
                                //item.Unit = obj.Unit;
                                item.UnitPrice = obj.UnitPrice;
                                item.ExpireDate = obj.ExpiredDate;
                                _repwhIoDetail.Insert(item);

                                export -= obj.CurrentVolumn;

                                //Update whDetail
                                obj.CurrentVolumn = 0;
                                repwhDetail.Update(obj);

                                //Insert whExportAllocate
                                WareHouseExportAllocate wareHouseExportAllocate = new WareHouseExportAllocate();
                                wareHouseExportAllocate.WareHouseDetailId = obj.Id;
                                wareHouseExportAllocate.WareHoudePaperDetailId = item.Id;
                                wareHouseExportAllocate.Volumn = obj.CurrentVolumn;
                                wareHouseExportAllocate.Unit = obj.Unit;
                                // whExport.Insert(wareHouseExportAllocate);
                            }
                        }
                    }
                }

                MessageBox.Show("Xuất kho thành công!");
                dateExport.Value = DateTime.Now;
                txtDeliverer.Text = string.Empty;
                txtNo.Text = string.Empty;
                txtNote.Text = string.Empty;
                txtRecipient.Text = string.Empty;
                grd.Rows.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void grd_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grd.Columns[e.ColumnIndex].Name == "btnExportAllocate")
            {
                WareHouse item = bdsWareHouse[e.RowIndex] as WareHouse;
                ExportAllocateDetail frm = new ExportAllocateDetail(item.Id, item.MedicineId, int.Parse(grd.Rows[e.RowIndex].Cells["Export"].Value.ToString()));
                frm.ShowDialog();
            }
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
    }
}
