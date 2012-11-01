using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("MedicineDeliveryDetail")]
    public class MedicineDeliveryDetail
    {
        public long Id { get; set; }
        public long MedicineDeliveryId { get; set; }
        public int MedicineId { get; set; }
        public long PrescriptionDetailId { get; set; }
        public int Volumn { get; set; }
        public int Unit { get; set; }
        public int? UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int? StockId { get; set; }
        public int Version { get; set; }
  }
}
