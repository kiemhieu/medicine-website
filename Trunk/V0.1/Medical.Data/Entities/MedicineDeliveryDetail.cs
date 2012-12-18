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
        public long PrescriptionDetailId { get; set; }
        public int MedicineId { get; set; }
        public int Volumn { get; set; }
        public int Unit { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Version { get; set; }

        [NotMapped]
        public int NotAllocatedQty { get; set; }
  }
}
