using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views {

    [Table("VMedicineDeliveryDetailAllocated")]
    public class VMedicineDeliveryDetailAllocated {
        [Key, Column(Order = 1)]
        public long MedicineDeliveryDetailId { get; set; }

        [Key, Column(Order = 2)]
        public int MedicineId { get; set; }

        [Key, Column(Order = 3)]
        public String LotNo { get; set; }

        [Key, Column(Order = 4)]
        public DateTime ExpiredDate { get; set; }

        public int AllocatedQty { get; set; }
    }
}
