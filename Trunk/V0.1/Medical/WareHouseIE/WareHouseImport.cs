using System;
using Medical.Forms.Enums;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;
using System.Windows.Forms;
using Medical.Data.Entities;
using Medical.Data;

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
        public WareHouseImport()
        {
            InitializeComponent();
            var id = AppContext.CurrentClinic.Id;
            txtClinic.Text = AppContext.CurrentClinic.Name;
            FillToGrid();
        }

        private void FillToGrid()
        {
            this.bdsMeidcine.DataSource = _medicineRepository.GetAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ClearData();
        }      

        private void grd_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
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

            if (grd.Columns[e.ColumnIndex].Name == "Qty" || grd.Columns[e.ColumnIndex].Name == "UnitPrice")
            {
                if (grd.Rows[e.RowIndex].Cells["Qty"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["Qty"].Value.ToString(), out volumn) && grd.Rows[e.RowIndex].Cells["UnitPrice"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString(), out unitPrice))
                {
                    grd.Rows[e.RowIndex].Cells["Amount"].Value = unitPrice * volumn;
                }
            }
        }

        private void grd_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateItemData())
                {
                    //Insert data to WareHouseIO
                    WareHouseIO wareHouseIo = new WareHouseIO();
                    wareHouseIo.ClinicId = AppContext.CurrentClinic.Id;
                    wareHouseIo.Date = dateImport.Value.Date;
                    wareHouseIo.Person = txtDeliverer.Text;
                    //wareHouseIo.Recipient = txtRecipient.Text;
                    wareHouseIo.Phone = txtPhone.Text;
                    wareHouseIo.Address = txtAddress.Text;
                    wareHouseIo.Type = "0";
                    wareHouseIo.Version = 0;
                    wareHouseIo.No = txtNo.Text;
                    wareHouseIo.AttachmentNo = txtOriginalNo.Text;
                    wareHouseIo.Note = txtNote.Text;
                    WareHouseIORepository wareHouseIoRepository = new WareHouseIORepository();
                    wareHouseIoRepository.Insert(wareHouseIo);

                    //Insert data to WareHouseIODetail
                    foreach (WareHouseIODetail obj in bdsWareHouseIODetail)
                    {
                        WareHouseIODetail item = new WareHouseIODetail();
                        item.WareHouseIOId = wareHouseIo.Id;
                        item.LotNo = obj.LotNo;
                        item.Type = "0";
                        item.MedicineId = obj.MedicineId;
                        item.Qty = obj.Qty;
                        item.Unit = obj.Unit;
                        item.UnitPrice = obj.UnitPrice;
                        item.Amount = obj.Amount;
                        item.ExpireDate = obj.ExpireDate;
                        item.CreatedDate = wareHouseIo.CreatedDate;
                        _wareHouseIoDetailRepository.Insert(item);

                        //Insert data to WareHouse
                        var wareHouse = _wareHouseRepository.GetByIdMedicine(item.MedicineId, wareHouseIo.ClinicId);
                        if (wareHouse != null)
                        {
                            wareHouse.Volumn += item.Qty;
                            _wareHouseRepository.Update(wareHouse);
                        }
                        else
                        {
                            wareHouse = new WareHouse();
                            wareHouse.MedicineId = item.MedicineId;
                            wareHouse.ClinicId = wareHouseIo.ClinicId;
                            wareHouse.Volumn = item.Qty;
                            wareHouse.MinAllowed = 0;
                            _wareHouseRepository.Insert(wareHouse);
                        }

                        //Insert data to WareHouseDetail
                        WareHouseDetail wareHouseDetail = new WareHouseDetail();
                        wareHouseDetail.MedicineId = item.MedicineId;
                        wareHouseDetail.WareHouseId = wareHouse.Id;
                        wareHouseDetail.WareHouseIODetailId = item.Id;
                        wareHouseDetail.LotNo = item.LotNo;
                        wareHouseDetail.ExpiredDate = item.ExpireDate;
                        wareHouseDetail.OriginalVolumn = item.Qty;
                        wareHouseDetail.CurrentVolumn = item.Qty;
                        wareHouseDetail.BadVolumn = 0;
                        //wareHouseDetail.Unit = item.Unit;
                        wareHouseDetail.UnitPrice = item.UnitPrice.Value;
                        wareHouseDetail.CreatedDate = DateTime.Now;
                        wareHouseDetail.LastUpdatedDate = DateTime.Now;
                        _wareHowDetailRepository.Insert(wareHouseDetail);
                    }

                    MessageBox.Show("Nhập kho thành công!");
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi nhập kho");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ClearData()
        {
            dateImport.Value = DateTime.Now;
            txtDeliverer.Text = string.Empty;
            txtNo.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtRecipient.Text = string.Empty;
            grd.Rows.Clear();
        }

        private bool ValidateItemData()
        {
            if (bdsWareHouseIODetail.Count == 0) return false;

            foreach (WareHouseIODetail item in bdsWareHouseIODetail)
            {
                if (item.LotNo == null || item.MedicineId == null || item.Qty == null
                    || item.ExpireDate == null || item.Unit == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
