using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views {

    [Table("VWareHouseDetail")]
    public class VWareHouseDetail {
        public int MedicineId { get; set; }

        [Column("LotNo")]
        public String LotNo { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int Qty { get; set; }
        public int Id { get; set; }
        public int InStockQty { get; set; }
        public int ClinicId { get; set; }

        [NotMapped]
        public int AllocatedQty { get; set; }
    }
}


