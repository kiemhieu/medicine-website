using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHouseIODetail")]
    public class WareHouseIODetail : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int WareHouseIOId { get; set; }
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public string Type { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Qty { get; set; }
        public int? UnitPrice { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Version { get; set; }
        public int Unit { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual WareHouseIO WareHouseIO { get; set; }

        [NotMapped]
        public string MedicineName { get { return this.Medicine != null ? this.Medicine.Name : string.Empty; }
        }

        [NotMapped]
        public string MedicineTradeName { get { return this.Medicine != null ? this.Medicine.TradeName : string.Empty; }
        }

        [NotMapped]
        public string UnitName { get { if (this.Medicine != null) return this.Medicine.Define.Name; else return string.Empty; } }

        [NotMapped]
        public int InStockQty { get; set; }

        [NotMapped]
        public int TotalQty { get; set; }

        public override void Validate()
        {
            base.Validate();
            if (MedicineId == 0) this.AddError("MedicineId", "Chưa chọn thuốc");
            if (ExpireDate < DateTime.Now) this.AddError("ExpireDate", "Ngày hết hạn phải lớn hơn ngày hiện tại");
            if (Qty <= 0) this.AddError("Qty", "Số lượng thuốc phải lớn hơn 0");
        } 
    }
}
