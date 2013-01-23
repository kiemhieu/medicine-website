using System;
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
        public int LastMonthUsage { get; set; }
        public int CurrentMonthUsage { get; set; }
        public int Required { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }
        public int Version { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual Medicine Medicine { get; set; }

        [NotMapped]
        public string UnitName { get; set; }

        [NotMapped]
        public int Remaining
        {
            get
            {
                return InStock - CurrentMonthUsage;
            }
        }
        [NotMapped]
        public string MedicineName
        {
            get
            {
                if (!string.IsNullOrEmpty(medicineName)) return medicineName;
                else if (Medicine != null) return Medicine.Name;
                return string.Empty;
            }
            set
            {
                medicineName = value;
            }
        }

        private string medicineName;
    }
}
