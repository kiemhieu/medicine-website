﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHousePaperDetail")]
    public class WareHousePaperDetail
    {
        public int Id { get; set; }
        public int PaperId { get; set; }
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public int TotalVolumn { get; set; }
        public int BadVolumn { get; set; }
        public int RealityVolumn { get; set; }
        public int Unit { get; set; }
        public int? UnitPrice { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public int Version { get; set; }
  }
}
