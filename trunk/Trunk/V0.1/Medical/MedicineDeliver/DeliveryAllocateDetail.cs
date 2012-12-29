using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void Initialize()
        {
            // Init Value
            this.bdsDefine.DataSource = this._defineRepository.GetUnit();
            this.bdsMedicine.DataSource = this._medicineRepo.GetAll();
            
            this._warehouse = this._warehouseRepo.GetByIdMedicine(this._medicineDeliverDetail.MedicineId, AppContext.CurrentClinic.Id);
            this.bdsWareHouse.DataSource = this._warehouse;

            this._vWarehouseDetail = this._vWareHouseDetailRepo.GetByMedicine(this._medicineDeliverDetail.MedicineId);
            foreach (var item in this._medicineDeliverDetail.AllocatedWareHouseDetail)
            {
                foreach (var original in this._vWarehouseDetail) {
                    if (item.LotNo != original.LotNo) continue;
                    if (item.ExpiredDate != original.ExpiredDate) continue;
                    original.AllocatedQty = item.AllocatedQty;
                }
            }
            this.bdsVWareHouseDetail.DataSource = this._vWarehouseDetail;
            /*
            foreach (var dele arehouseDetail)
            {
                
            }
             */

        }

   }
}
