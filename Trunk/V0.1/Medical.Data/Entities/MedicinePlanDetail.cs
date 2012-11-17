﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("MedicinePlanDetail")]
    public class MedicinePlanDetail
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int MedicineId { get; set; }
        public int InStock { get; set; }
        public int Usage { get; set; }
        public int Required { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }
        public int Version { get; set; }
  }
}