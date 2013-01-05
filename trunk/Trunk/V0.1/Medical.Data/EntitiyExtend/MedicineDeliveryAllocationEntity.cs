using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;

namespace Medical.Data.EntitiyExtend
{
    public class MedicineDeliveryAllocationEntity : EntityBase
    {
        private WareHouse _warehouse;

        // private List<MedicineDeliveryDetailAllocate> allocatedList;
        // private List<WareHouseDetail> _wareHouseDetails;
        public MedicineDeliveryAllocationEntity(int no, MedicineDeliveryDetail deliveryDetail, WareHouse warehouse) {
            this.No = no;
            this._warehouse = warehouse;
            this.MedicineDeliveryDetail = deliveryDetail;
            this.MedicineName = this.MedicineDeliveryDetail.Medicine == null
                                    ? String.Empty
                                    : this.MedicineDeliveryDetail.Medicine.Name;
            this.Qty= this.MedicineDeliveryDetail == null ? (int?)null : this.MedicineDeliveryDetail.Volumn;
            this.InStockQty = warehouse.Volumn;
            this.AllocatedQty = this.MedicineDeliveryDetail.AllocatedWareHouseDetail == null ? this.MedicineDeliveryDetail.Volumn : this.MedicineDeliveryDetail.AllocatedWareHouseDetail.Sum(x => x.AllocatedQty);
        }

        public MedicineDeliveryAllocationEntity(int subNo, VWareHouseDetail vWareHouseDetail) {
            this.SubNo = subNo;
            this.VWareHouseDetail = vWareHouseDetail;
            this.LotNo = this.VWareHouseDetail == null ? null : this.VWareHouseDetail.LotNo;
            this.ExpiredDate = this.VWareHouseDetail == null ? (DateTime?)null : this.VWareHouseDetail.ExpiredDate;
            this.InStockQty = VWareHouseDetail.Qty;
            this.AllocatedQty = vWareHouseDetail.AllocatedQty;
        }

        public MedicineDeliveryAllocationEntity(int subNo, VMedicineDeliveryDetailAllocated vWareHouseDetail) {
            this.SubNo = subNo;
            this.AllocatedQty = vWareHouseDetail.AllocatedQty;
            this.LotNo = vWareHouseDetail.LotNo;
            this.ExpiredDate = vWareHouseDetail.ExpiredDate;
        }

        public long? DeliverDetailId
        {
            get { return this.MedicineDeliveryDetail == null ? (long?) null : this.MedicineDeliveryDetail.Id; }
        }

        public int? No { set; get; }

        public int? SubNo { set; get; }

        public String MedicineName { get; set; }

        public String LotNo { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public int? Qty { get; set; }

        public int? RemainQty { get { return this.InStockQty - this.AllocatedQty; } }

        public int InStockQty { get; set; }

        public int AllocatedQty { get; set; }

        public MedicineDeliveryDetail MedicineDeliveryDetail { get; private set; }

        public VWareHouseDetail VWareHouseDetail { get; private set; }

        public String UnitName
        {
            get
            {
                return this.MedicineDeliveryDetail != null ? this.MedicineDeliveryDetail.Medicine.Define.Name : null;
            }
        }

        public override void Validate() {
            base.Validate();
            if (this.Qty.HasValue && this.AllocatedQty != this.Qty) this.AddError("AllocatedQty", "Số lượng chọn chưa đủ với số cần xuất");
            if (this.AllocatedQty > this.InStockQty) this.AddError("AllocatedQty", "Số lượng chọn vượt quá mức có trong kho");
        }
    }
}
