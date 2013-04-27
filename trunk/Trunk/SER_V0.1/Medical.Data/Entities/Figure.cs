using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("Figure")]
    public class Figure : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClinicId { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }


        public virtual List<FigureDetail> FigureDetail { get; set; }
        public virtual Clinic Clinic { get; set; }
        [NotMapped]
        public string ClinicName
        {
            get { return this.Clinic == null ? string.Empty : this.Clinic.Name; }
        }
    }
}
