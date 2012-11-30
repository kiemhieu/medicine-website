using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("PrescriptionDetail")]
    public class PrescriptionDetail : EntityBase
    {

        #region Mapping property
        public long Id { get; set; }
        public long PrescriptionId { get; set; }
        public int? FigureDetailId { get; set; }
        public int MedicineId { get; set; }
        public int Day { get; set; }
        public int VolumnPerDay { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual FigureDetail FigureDetail { get; set; }

        #endregion

        [NotMapped]
        public int No { get; set; }

        [NotMapped]
        public String MedicineName
        {
            get { return this.Medicine == null ? string.Empty : this.Medicine.Name; }
        }

        public override void Validate()
        {
            base.Validate();
            if (this.MedicineId == 0) this.AddError("MedicineId", "Chưa chọn thuốc");
            if (this.Day == 0) this.AddError("Day", "Chưa chọn thuốc");
            if (this.VolumnPerDay == 0) this.AddError("VolumnPerDay", "Chưa chọn thuốc");
        }

        public void Calculate()
        {
            this.Amount = this.Day*this.VolumnPerDay;
        }
    }
}
