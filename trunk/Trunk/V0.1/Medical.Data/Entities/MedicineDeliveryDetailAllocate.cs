using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("MedicineDeliveryDetailAllocate")]
    public class MedicineDeliveryDetailAllocate
    {
        public long Id { get; set; }
        public long MedicineDeliveryDetailId { get; set; }
        public int WareHouseDetailId { get; set; }
        public int Volumn { get; set; }
        public int Unit { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Version { get; set; }
    }
}
