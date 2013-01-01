using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Medical.Data.Entities.Views;

namespace Medical.Data.Entities
{
    [Table("MedicineDeliveryDetail")]
    public class MedicineDeliveryDetail : EntityBase
    {
        public long Id { get; set; }
        public long MedicineDeliveryId { get; set; }
        public long PrescriptionDetailId { get; set; }
        public int MedicineId { get; set; }
        public int Volumn { get; set; }
        public int Unit { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Version { get; set; }

        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }

        public virtual List<MedicineDeliveryDetailAllocate> Allocated { get; set; }
        
        [NotMapped]
        public int NotAllocatedQty { get; set; }

        private int _allocatedQty;
        [NotMapped]
        public int AllocatedQty {
            get { return _allocatedQty; }
            set {
                if (value == _allocatedQty) return;
                _allocatedQty = value;
                this.NotAllocatedQty = this.Volumn - _allocatedQty;
                this.OnPropertyChanged("AllocatedQty");
            }
        }

        [NotMapped]
        public List<VWareHouseDetail> AllocatedWareHouseDetail { get; set; }
  }
}
