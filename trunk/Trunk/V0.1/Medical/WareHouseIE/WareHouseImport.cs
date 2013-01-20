using System;
using Medical.Forms.Enums;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;
using System.Windows.Forms;
using Medical.Data.Entities;

namespace Medical.WareHouseIE
{
    public partial class WareHouseImport : DockContent
    {
        private readonly MedicineRepository _medicineRepository = new MedicineRepository();
        private readonly ClinicRepository _clinicRepository = new ClinicRepository();
        private readonly DefineRepository _defineRepository;
        private readonly WareHouseDetailRepository _wareHowDetailRepository;
        private readonly WareHouseRepository _wareHouseRepository;
        private readonly WareHouseIORepository _wareHouseIoRepository;
        private readonly WareHouseIODetailRepository _wareHouseIoDetailRepository;
        public WareHouseImport()
        {
            InitializeComponent();
            FillToGrid();
        }

        private void FillToGrid()
        {
            this.bdsMeidcine.DataSource = _medicineRepository.GetAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {

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
                //Insert data to WareHousePaper
                WareHouseIO wareHouseIo = new WareHouseIO();
                wareHouseIo.ClinicId = 0;
                wareHouseIo.Date = dateImport.Value.Date;
                wareHouseIo.Person = txtDeliverer.Text;
                //wareHouseIo.Recipient = txtRecipient.Text;
                wareHouseIo.Type = "0";
                wareHouseIo.Version = 0;
                wareHouseIo.No = txtNo.Text;
                wareHouseIo.Note = txtNote.Text;
                WareHouseIORepository wareHouseIoRepository = new WareHouseIORepository();
                wareHouseIoRepository.Insert(wareHouseIo);

                //Insert data to WareHousePaperDetail
                foreach (WareHouseIODetail row in bdsWareHouseIODetail)
                {
                    //if (ValidateRowData(row))
                    //{
                    WareHouseIODetail item = new WareHouseIODetail();
                    //item.WareHousePaperId = wareHouseIo.Id;
                    item.LotNo = row.LotNo;
                    //item.Type = 0;
                    item.MedicineId = row.MedicineId;
                    item.Qty = row.Qty;
                    item.Unit = row.Unit;
                    item.UnitPrice = row.UnitPrice;
                    item.Amount = row.Amount;
                    item.ExpireDate = row.ExpireDate;
                    item.CreatedDate = wareHouseIo.CreatedDate;
                    _wareHouseIoDetailRepository.Insert(item);

                    //Insert data to WareHouse
                    var wareHouse = _wareHouseRepository.GetByIdMedicine(item.MedicineId, wareHouseIo.ClinicId);
                    if (wareHouse != null)
                    {
                        //wareHouse.Volumn += item.Volumn;
                        _wareHouseRepository.Update(wareHouse);
                    }
                    else
                    {
                        wareHouse = new WareHouse();
                        wareHouse.MedicineId = item.MedicineId;
                        wareHouse.ClinicId = wareHouseIo.ClinicId;
                        //wareHouse.Volumn = item.Volumn;
                        wareHouse.MinAllowed = 0;
                        _wareHouseRepository.Insert(wareHouse);
                    }

                    //Insert data to WareHouseDetail
                    WareHouseDetail wareHouseDetail = new WareHouseDetail();
                    wareHouseDetail.MedicineId = item.MedicineId;
                    wareHouseDetail.WareHouseId = wareHouse.Id;
                    wareHouseDetail.WareHousePaperDetailId = item.Id;
                    wareHouseDetail.LotNo = item.LotNo;
                    wareHouseDetail.ExpiredDate = item.ExpireDate;
                    //wareHouseDetail.OriginalVolumn = item.Volumn;
                    //wareHouseDetail.CurrentVolumn = item.Volumn;
                    wareHouseDetail.BadVolumn = 0;
                    //wareHouseDetail.Unit = item.Unit;
                    wareHouseDetail.UnitPrice = item.UnitPrice.Value;
                    wareHouseDetail.CreatedDate = DateTime.Now;
                    wareHouseDetail.LastUpdatedDate = DateTime.Now;
                    _wareHowDetailRepository.Insert(wareHouseDetail);
                    //}
                }

                MessageBox.Show("Nhập kho thành công!");
                dateImport.Value = DateTime.Now;
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
    }
}
