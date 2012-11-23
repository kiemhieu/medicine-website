using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities {
    [Table("Patient")]
    public class Patient {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public String Sexual { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }

        public virtual Clinic Clinic { get; set; }

        [NotMapped]
        public String Sex
        {
            get
            {
                if (string.IsNullOrEmpty(this.Sexual)) return null;
                switch (this.Sexual)
                {
                    case "F":
                        return "Nữ";
                    case "M":
                        return "Nam";
                }
                return null;
            }
        }

        [NotMapped]
        public string ClinicName
        {
            get { return this.Clinic == null ? string.Empty: this.Clinic.Name;  }
        }
    }
}
