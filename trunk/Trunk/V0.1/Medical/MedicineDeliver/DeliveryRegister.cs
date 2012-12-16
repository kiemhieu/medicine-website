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
using Medical.Data.Repositories;
using Medical.Forms.Enums;

namespace Medical.MedicineDeliver
{
    public partial class DeliveryRegister : Form
    {
        private IPrescriptionRepository _prescriptionRepo = new PrescriptionRepository();
        private IPrescriptionDetailRepository _prescriptionDetailRepo = new PrescriptionDetailRepository();
        private IMedicineDeliveryRepository _medicineDeliveryRepo = new MedicineDeliveryRepository();
        private IMedicineDeliveryDetailRepository _medicineDeliveryDetailRepo = new MedicineDeliveryDetailRepository();
        private IMedicineDeliveryDetailAllocateRepository _medicineDeliveryDetailAllocateRepo = new MedicineDeliveryDetailAllocateRepository();
        private IWareHouseDetailRepository _warehouseDetailAllocateRepo = new WareHouseDetailRepository();

        private int _prescriptionId;
        private ViewModes _formMode;

        public DeliveryRegister(int prescriptionId)
        {
            InitializeComponent();
            this._prescriptionId = prescriptionId;
        }

        private void Initialize()
        {
            
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
