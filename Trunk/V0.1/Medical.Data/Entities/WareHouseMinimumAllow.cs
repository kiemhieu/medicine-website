﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHouseMinimumAllow")]
    public class WareHouseMinimumAllow
    {
        public long Id { get; set; }
        public int ClinicId { get; set; }
        public int MedicineId { get; set; }
        public int? Amount { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CrearedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }
    }
}
