using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medical.Data.Entities
{
    [Table("WareHouseDetail")]
    public class WareHouseDetail
    {
        public long Id { get; set; }
        public int WareHouseId { get; set; }
        public int? WareHousePaperDetailId { get; set; }        
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int? OriginalVolumn { get; set; }
        public int CurrentVolumn { get; set; }
        public int BadVolumn { get; set; }
        public int Unit { get; set; }
        public int UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }

        public virtual List<MedicineDeliveryDetailAllocate> DeliveryAllocate { get; set; }        
        public virtual Medicine Medicine { get; set; }        
        // public virtual WareHouse WareHouse { get; set; }
        [NotMapped]
        public string MedicineName { get { return this.Medicine.Name; } }
    }
}
