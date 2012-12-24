using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHouseExportAllocate")]
    public class WareHouseExportAllocate
    {
        public long Id { get; set; }
        public int WareHoudePaperDetailId { get; set; }
        public int WareHouseDetailId { get; set; }
        public int Volumn { get; set; }
        public int Unit { get; set; }
        public int Version { get; set; }
    }
}
