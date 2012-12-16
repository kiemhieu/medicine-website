using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views
{
    [Table("VMedicineDeliveryDetailList")]
    public class VMedicineDeliveryDetailList
    {
        public long Id { get; set; }
        public long PrescriptionId { get; set; }
        public String Name { get; set; }
        public int RequiredVol { get; set; }
        public int AllocateVol { get; set; }
        public long MedicineDeliveryDetailId { get; set; }
        public long MedicineDeliveryId { get; set; }
        public String Unit { get; set; }
        public int InStockVol { get; set; }
        public int MinAlloewsVol { get; set; }
    }
}
