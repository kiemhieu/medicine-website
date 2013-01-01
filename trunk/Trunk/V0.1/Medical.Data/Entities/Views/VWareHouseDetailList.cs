using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views {

    [Table("VWareHouseDetailList")]
    public class VWareHouseDetailList {
        // public int Id { get; set; }
        //public int WareHouseId { get; set; }
        //public int? WareHousePaperDetailId { get; set; }
        //public int MedicineId { get; set; }
        [Key]
        public string LotNo { get; set; }
        //public DateTime ExpiredDate { get; set; }
        //public int? OriginalVolumn { get; set; }
        //public int CurrentVolumn { get; set; }
        //public int BadVolumn { get; set; }
        //public int Unit { get; set; }
        //public int UnitPrice { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int CreatedUser { get; set; }
        //public DateTime LastUpdatedDate { get; set; }
        //public int LastUpdatedUser { get; set; }
        //public int Version { get; set; }
        public int Qty { get; set; }
    }
}
