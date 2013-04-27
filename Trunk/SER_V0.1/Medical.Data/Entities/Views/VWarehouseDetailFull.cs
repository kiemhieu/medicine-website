using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views
{
    [Table("VWarehouseDetailFull")]
    public class VWarehouseDetailFull :WareHouseDetail
    {
        public DateTime Date { get; set; }
        public int ClinicId { get; set; }
    }
}
