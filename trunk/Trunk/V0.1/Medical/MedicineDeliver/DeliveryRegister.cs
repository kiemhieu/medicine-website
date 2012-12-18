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
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using Medical.Forms.Enums;

namespace Medical.MedicineDeliver
{
    public partial class DeliveryRegister : Form
    {
        private List<MedicineDeliveryAllocationEntity> medDeliveryAllocationList;
        // Repositpry
        private IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();
        private IPrescriptionDetailRepository _prescriptionDetailRepo = new PrescriptionDetailRepository();
        private IMedicineDeliveryRepository _medicineDeliveryRepo = new MedicineDeliveryRepository();
        private IMedicineDeliveryDetailRepository _medicineDeliveryDetailRepo = new MedicineDeliveryDetailRepository();
        private IMedicineDeliveryDetailAllocateRepository _medicineDeliveryDetailAllocateRepo = new MedicineDeliveryDetailAllocateRepository();
        private IWareHouseDetailRepository _warehouseDetailAllocateRepo = new WareHouseDetailRepository();
        private IWareHouseRepository _warehouseRepo = new WareHouseRepository();
        private IWareHouseDetailRepository _warehouseDetailRepo = new WareHouseDetailRepository();

        // Entity & List
        private Prescription _prescription;
        private List<PrescriptionDetail> _prescriptionDetailList;
        private MedicineDelivery _medicineDelivery;
        private List<MedicineDeliveryDetail> _medicineDeliveryDetailList;
        private List<MedicineDeliveryDetailAllocate> _mdecidineDeliveryDetailAllocate;
        private List<WareHouse> _warehouseList;
        private List<WareHouseDetail> _warehouseDetailList;

        private long _prescriptionId;
        private ViewModes _formMode;

        public DeliveryRegister(long prescriptionId)
        {
            InitializeComponent();
            this._prescriptionId = prescriptionId;
            Initialize();
            this.bindingSource1.DataSource = this.medDeliveryAllocationList;
        }

        private void Initialize()
        {
            medDeliveryAllocationList = new List<MedicineDeliveryAllocationEntity>();

            this._prescription = _prescriptionRepo.Get(this._prescriptionId);
            this._prescriptionDetailList = _prescriptionDetailRepo.GetByPrescription(this._prescriptionId);
            if (_prescription == null || this._prescriptionDetailList == null) throw new Exception("Data dosenot existed");

            this._medicineDelivery = this._medicineDeliveryRepo.GetByPrescriptionId(this._prescriptionId);
            this._formMode = this._medicineDelivery == null ? ViewModes.Add : ViewModes.View;

            if (this._formMode == ViewModes.Add)
            {
                // Createe MachineDelivery
                // Create MachineDeliveryDetail
                // Craete MedicindeDeliveryDetailAllocate
                // Get WareHouseDetail
                // Get WareHouse;
                // this._warehouseDetailList  = this._warehouseDetailRepo
                var medincineIdList = this._prescriptionDetailList.Select(item => item.MedicineId).ToList();
                this._warehouseList = this._warehouseRepo.GetByMedicineId(medincineIdList, AppContext.CurrentClinic.Id);
                this._warehouseDetailList = this._warehouseDetailRepo.GetByMedicine(medincineIdList);

                this._medicineDelivery = CreatePrescription(this._prescription);
                this._medicineDeliveryDetailList = CreateMedicineDeliveryDetail(this._prescriptionDetailList);
                this._mdecidineDeliveryDetailAllocate = AutoAllocate(this._medicineDeliveryDetailList, this._warehouseDetailList);

                foreach(var deliveryItem in this._medicineDeliveryDetailList)
                {
                    var allocatedList = this._mdecidineDeliveryDetailAllocate.Where(x => x.MedicineDeliveryDetailId == deliveryItem.Id).ToList();
                    var warehouse = this._warehouseList.FirstOrDefault(x => x.MedicineId == deliveryItem.MedicineId);
                    var warehouseDetailList = this._warehouseDetailList.Where(x => x.MedicineId == deliveryItem.MedicineId).ToList();
                    var displayItem = new MedicineDeliveryAllocationEntity(allocatedList, deliveryItem, warehouseDetailList, warehouse);
                    medDeliveryAllocationList.Add(displayItem);
                }

            }
        }

        private MedicineDelivery CreatePrescription(Prescription prescription)
        {
            var medicineDelivery = new MedicineDelivery();
            medicineDelivery.ClinicId = AppContext.CurrentClinic.Id;
            medicineDelivery.Date = DateTime.Today;
            medicineDelivery.PatienId = prescription.PatientId;
            medicineDelivery.PrescriptionId = prescription.Id;
            return medicineDelivery;
        }

        private List<MedicineDeliveryDetail> CreateMedicineDeliveryDetail(List<PrescriptionDetail> prescriptionDetails)
        {
            var medicineDeliveryList = new List<MedicineDeliveryDetail>();
            int index = 0;
            foreach (var prescriptionDetail in prescriptionDetails)
            {
                var medicineDeliveryDetail = new MedicineDeliveryDetail
                                                 {
                                                     Id = ++index,
                                                     MedicineId = prescriptionDetail.MedicineId,
                                                     PrescriptionDetailId = prescriptionDetail.Id,
                                                     Unit = prescriptionDetail.Medicine.Unit,
                                                     Volumn = prescriptionDetail.Amount,
                                                     NotAllocatedQty = prescriptionDetail.Amount
                                                 };
                medicineDeliveryList.Add(medicineDeliveryDetail);
            }
            return medicineDeliveryList;
        }

        private List<MedicineDeliveryDetailAllocate> AutoAllocate(List<MedicineDeliveryDetail> medicineDeliveryDetails, List<WareHouseDetail> wareHouseDetails)
        {
            var allocatedItems = new List<MedicineDeliveryDetailAllocate>();
            foreach (var deliveryDetailItem in medicineDeliveryDetails)
            {
                var warehouseDetailAllocationList =
                    wareHouseDetails.Where(x => x.MedicineId == deliveryDetailItem.MedicineId).
                                        OrderBy(x => x.ExpiredDate).
                                        OrderBy(x => x.Id).ToList();

                for (int i = 0; i < warehouseDetailAllocationList.Count; i++)
                {
                    if (deliveryDetailItem.Volumn <= warehouseDetailAllocationList[i].CurrentVolumn)
                    {
                        var allocatedItem = new MedicineDeliveryDetailAllocate
                                                {
                                                    MedicineDeliveryDetailId = deliveryDetailItem.Id,
                                                    Unit = deliveryDetailItem.Unit,
                                                    Volumn = deliveryDetailItem.Volumn,
                                                    WareHouseDetailId = warehouseDetailAllocationList[i].Id
                                                };
                        deliveryDetailItem.NotAllocatedQty = 0;
                        allocatedItems.Add(allocatedItem);
                        warehouseDetailAllocationList[i].CurrentVolumn -= deliveryDetailItem.Volumn;
                    }
                    else
                    {
                        var allocatedItem = new MedicineDeliveryDetailAllocate
                        {
                            MedicineDeliveryDetailId = deliveryDetailItem.Id,
                            Unit = deliveryDetailItem.Unit,
                            Volumn = warehouseDetailAllocationList[i].CurrentVolumn,
                            WareHouseDetailId = warehouseDetailAllocationList[i].Id
                        };
                        deliveryDetailItem.NotAllocatedQty -= allocatedItem.Volumn;
                        allocatedItems.Add(allocatedItem);
                        warehouseDetailAllocationList[i].CurrentVolumn = 0;
                    }
                }

                if (deliveryDetailItem.NotAllocatedQty == 0) break;
            }

            return allocatedItems;
        }

        private void DeliveryRegister_Load(object sender, EventArgs e)
        {
            /*
            List<MedicineDeliveryDetail> deliveryList = new List<MedicineDeliveryDetail>();
            for (int i = 0; i < 10; i++)
            {
                var item = new MedicineDeliveryDetail();
                item.Id = i;
                item.MedicineId = i;
                deliveryList.Add(item);
            }
            this.bindingSource1.DataSource = deliveryList;

            this.advTree1.Nodes[0
             */
        }
    }
}

