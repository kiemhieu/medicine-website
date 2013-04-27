using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("FigureDetail")]
    public class FigureDetail : EntityBase
    {
        public int Id { get; set; }
        public int FigureId { get; set; }
        public int MedicineId { get; set; }
        public int Volumn { get; set; }
        public int Version { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Figure Figure { get; set; }

        [NotMapped]
        public String MedicineName
        {
            get { return this.Medicine == null ? string.Empty : this.Medicine.Name; }
        }

        [NotMapped]
        public String MedicineContentString
        {
            get { return this.Medicine == null ? string.Empty : this.Medicine.ContentString; }
        }
    }
}
