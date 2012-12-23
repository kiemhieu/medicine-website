using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("MedicinePlan")]
    public class MedicinePlan
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public int? ApproveId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }

        public virtual Clinic Clinic { get; set; }

        [NotMapped]
        public string ClinicName
        {
            get
            {
                if (Clinic != null)
                    return Clinic.Name;
                else
                    return string.Empty;
            }
        }
    }
}
