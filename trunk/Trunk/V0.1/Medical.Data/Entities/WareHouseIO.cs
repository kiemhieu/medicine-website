using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Medical.Common;

namespace Medical.Data.Entities
{
    [Table("WareHouseIO")]
    public class WareHouseIO : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public String Type { get; set; }
        public DateTime Date { get; set; }
        public String No { get; set; }
        public String Person { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Note { get; set; }
        public String AttachmentNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public int Version { get; set; }
        public ICollection<WareHouseIODetail> WareHouseIODetails { get; set; }

        [NotMapped]
        public string TypeName
        {
            get { return this.Type.Equals(WarehouseIO.Input) ? "Nhập kho" : "Xuất kho";}
        }

        public override void Validate()
        {
            base.Validate();
            if (!Validation.CheckNulOrEmpty(this.No)) this.AddError("No", "Chưa nhập số phiếu");
            else if (!Validation.CheckAlphaNumeric(this.No)) this.AddError("No", "Số phiếu không chứa kí tự lạ");

            if (!Validation.CheckNulOrEmpty(this.Person)) this.AddError("Person", "Chưa nhập tên người");

            if (!Validation.CheckNulOrEmpty(this.Phone)) this.AddError("Phone", "Chưa nhập số điện thoại");
            else  if (this.Phone.Length < 9) this.AddError("Phone", "Số điện thoại nhập không đúng");

            if (!Validation.CheckNulOrEmpty(this.AttachmentNo)) this.AddError("AttachmentNo", "Chưa nhập số chứng từ gốc");
            else if (!Validation.CheckAlphaNumeric(this.AttachmentNo)) this.AddError("AttachmentNo", "Số chứng từ gốc không được chứa kí tự lạ");
        }
    }
}
