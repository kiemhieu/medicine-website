using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities.Views {

    [Table("VWareHouseDetail")]
    public class VWareHouseDetail : EntityBase {
        [Key, Column(Order = 1)]
        public int MedicineId { get; set; }

        [Key, Column(Order = 3)]
        public String LotNo { get; set; }

        [Key, Column(Order = 2)]
        public DateTime ExpiredDate { get; set; }

        public int Qty { get; set; }
        public int Id { get; set; }
        public int InStockQty { get; set; }
        public int ClinicId { get; set; }

        private int _allocatedQty;
        [NotMapped]
        public int AllocatedQty
        {
            get { return _allocatedQty; }
            set { if (value == this._allocatedQty) return;
                _allocatedQty = value;
                this.OnPropertyChanged("AllocatedQty");
            }
        }

        public override void Validate() {
            base.Validate();
            if (this.AllocatedQty > this.Qty) this.AddError("AllocatedQty", "Số lượng chọn xuất không thể lớn hơn số lượng hiện có");
        }

        [NotMapped]
        public int No { get; set; }
    }
}


