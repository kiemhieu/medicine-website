using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;

namespace Medical.MedicineDeliver
{
    public partial class DeliveryAllocateDetail : Form
    {
        private Point cellInError = new Point(-2, -2);
        private ToolTip errorTooltip;

        private IWareHouseRepository _warehouseRepo = new WareHouseRepository();
        private IWareHouseDetailRepository _warehouseDetailRepo = new WareHouseDetailRepository();
        private IMedicineRepository _medicineRepo = new MedicineRepository();
        private IDefineRepository _defineRepository = new DefineRepository();
        private IVWareHouseDetailRespository _vWareHouseDetailRepo = new VWareHouseDetailRepository();

        private MedicineDeliveryDetail _medicineDeliverDetail;
        private WareHouse _warehouse;
        private List<WareHouseDetail> _warehouseDetail;
        private List<VWareHouseDetail> _vWarehouseDetail;
        private List<MedicineDeliveryDetailAllocate> _allocateDetails;

        public DeliveryAllocateDetail(MedicineDeliveryDetail medicineDeliverDetail)
        {
            InitializeComponent();
            this._medicineDeliverDetail = medicineDeliverDetail;
        //    this._allocateDetails = allocateDetails;
            this.Initialize();
            this.bdsDelivery.DataSource = this._medicineDeliverDetail;
        }

        private void Initialize()
        {
            this._medicineDeliverDetail.PropertyChanged += new PropertyChangedEventHandler(_medicineDeliverDetail_PropertyChanged);
            // Init Value
            this.bdsDefine.DataSource = this._defineRepository.GetUnit();
            this.bdsMedicine.DataSource = this._medicineRepo.GetAll();
            
            this._warehouse = this._warehouseRepo.GetByIdMedicine(this._medicineDeliverDetail.MedicineId, AppContext.CurrentClinic.Id);
            this.bdsWareHouse.DataSource = this._warehouse;

            this._vWarehouseDetail = this._vWareHouseDetailRepo.GetByMedicine(this._medicineDeliverDetail.MedicineId);
            foreach (var item in _vWarehouseDetail) {
                item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
            }

            foreach (var item in this._medicineDeliverDetail.AllocatedWareHouseDetail)
            {
                foreach (var original in this._vWarehouseDetail) {
                    if (item.LotNo != original.LotNo) continue;
                    if (item.ExpiredDate != original.ExpiredDate) continue;
                    original.AllocatedQty = item.AllocatedQty;
                }
            }
            this.bdsVWareHouseDetail.DataSource = this._vWarehouseDetail;
            this._warehouse.RemainQty = this._warehouse.Volumn - this._medicineDeliverDetail.AllocatedQty;

        }

        void _medicineDeliverDetail_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (!e.PropertyName.Equals("AllocatedQty")) return;
            this._warehouse.RemainQty = this._warehouse.Volumn - this._medicineDeliverDetail.AllocatedQty;
        }

        private bool ValidateForm()
        {
            this.errorProvider1.Clear();
            var list = (List<VWareHouseDetail>) this.bdsVWareHouseDetail.List;
            var validateResult = true;

            foreach (var item  in list)
            {
                item.Validate();
                if (!item.IsValid) validateResult = false;
            }

            if (this._medicineDeliverDetail.NotAllocatedQty < 0)
            {
                this.errorProvider1.SetError(txtNotAllocatedQty, "Chọn quá số lượng cần thiết.");
                validateResult = false;
            }

            if (this._warehouse.RemainQty < 0) {
                this.errorProvider1.SetError(txtWareHouseRemainQty, "Chọn quá số lượng có trong kho.");
                validateResult = false;
            }
            return validateResult;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!this.ValidateForm()) return;
            var list = (List<VWareHouseDetail>)this.bdsVWareHouseDetail.List;
            this.Result = list.Where(x => x.AllocatedQty > 0).ToList();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        public List<VWareHouseDetail> Result { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            
            /*// if (String.IsNullOrEmpty(e.ErrorText)) {

                // paint everything except error icon

                e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~(DataGridViewPaintParts.ErrorIcon));



                // now move error icon over to fill in the padding space
                Rectangle iconRect = new Rectangle(e.CellBounds.Left + 5, e.CellBounds.Top + e.CellBounds.Height/2 - 8, 16, 16);
                GraphicsContainer container = e.Graphics.BeginContainer();

                e.Graphics.TranslateTransform(18, 0);

                e.Paint(iconRect, DataGridViewPaintParts.ErrorIcon);

                e.Graphics.EndContainer(container);



                e.Handled = true;

            //}
             */
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            /*
            if (dataGridViewX1[e.ColumnIndex, e.RowIndex].ErrorText != String.Empty) {

                DataGridViewCell cell = dataGridViewX1[e.ColumnIndex, e.RowIndex];

                cell.ErrorText = String.Empty;

                cellInError = new Point(-2, -2);



                // restore padding for cell. This moves the editing control

                cell.Style.Padding = (Padding)cell.Tag;



                // hide and dispose tooltip 

                if (errorTooltip != null) {

                    errorTooltip.Hide(dataGridViewX1);

                    errorTooltip.Dispose();

                    errorTooltip = null;

                }

            }
             */
        }

        private void dataGridViewX1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 1)
            {
                
            }
        }

        private void bdsVWareHouseDetail_BindingComplete(object sender, BindingCompleteEventArgs e) {
            var list = (List<VWareHouseDetail>)this.bdsVWareHouseDetail.List;
            foreach (var item in list)
            {
                item.PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
            }
        }

        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (!e.PropertyName.Equals("AllocatedQty")) return;
            ReCalculateAllocated();
        }

        private void ReCalculateAllocated()
        {
            this._medicineDeliverDetail.AllocatedQty = this._vWarehouseDetail.Sum(x => x.AllocatedQty);
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            this._warehouse.RemainQty = this._warehouse.Volumn - this._medicineDeliverDetail.AllocatedQty;
        }
   }
}
