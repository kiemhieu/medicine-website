using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views {

    [Table("VMedicineDeliveryDetailAllocated")]
    public class VMedicineDeliveryDetailAllocated {
        public long MedicineDeliveryDetailId { get; set; }
        public long MedicineId { get; set; }
        public String LotNo { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int AllocatedQty { get; set; }
    }
}
