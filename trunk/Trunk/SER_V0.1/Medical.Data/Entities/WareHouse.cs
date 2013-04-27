using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHouse")]
    public class WareHouse : EntityBase
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int MedicineId { get; set; }
        public int Volumn { get; set; }
        public int? MinAllowed { get; set; }
        public int? Version { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int? LastUpdatedUser { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Clinic Clinic { get; set; }

        // public virtual ICollection<WareHouseDetail> WareHouseDetails { get; set; }
        [NotMapped]
        public string Unit { get { return this.Medicine.Define.Name; } }

        [NotMapped]
        public string MedicineName { get { return this.Medicine.Name; } }

        [NotMapped]
        public string TradeName { get { return this.Medicine.TradeName; } }

        [NotMapped]
        public string ClinicName { get { return this.Clinic.Name; } }

        [NotMapped]
        public bool Flag { get; set; }

        [NotMapped]
        public int Export { get; set; }

        private int _remainQty;

        [NotMapped]
        public int RemainQty
        {
            set
            {
                if (value == _remainQty) return;
                _remainQty = value;
                this.OnPropertyChanged("RemainQty");
            }
            get { return _remainQty; }
        }

        public void ValidateMinimumAllowedQty()
        {
            base.Validate();
            if (this.MinAllowed >= this.Volumn) this.AddError("Volumn", "Số lượng tồn kho nhỏ hơn mức cho phép tối thiểu");
        }
    }
}
