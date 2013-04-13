using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.EntitiyExtend
{
    [Table("_ReportTotalMedicineDeliveryByMonth")]
    public class ReportTotalMedicineDeliveryByMonth
    {
        public int ClinicId { get; set; }
        public int MedicineId { get; set; }
        public int YearMonth { get; set; }
        public string MedicineName { get; set; }
        public int? Qty1 { get; set; }
        public int? Qty2 { get; set; }
        public int? Qty3 { get; set; }
        public int? Qty4 { get; set; }
        public int? Qty5 { get; set; }
        public int? Qty6 { get; set; }
        public int? Qty7 { get; set; }
        public int? Qty8 { get; set; }
        public int? Qty9 { get; set; }
        public int? Qty10 { get; set; }
        public int? Qty11 { get; set; }
        public int? Qty12 { get; set; }
        public int? Qty13 { get; set; }
        public int? Qty14 { get; set; }
        public int? Qty15 { get; set; }
        public int? Qty16 { get; set; }
        public int? Qty17 { get; set; }
        public int? Qty18 { get; set; }
        public int? Qty19 { get; set; }
        public int? Qty20 { get; set; }
        public int? Qty21 { get; set; }
        public int? Qty22 { get; set; }
        public int? Qty23 { get; set; }
        public int? Qty24 { get; set; }
        public int? Qty25 { get; set; }
        public int? Qty26 { get; set; }
        public int? Qty27 { get; set; }
        public int? Qty28 { get; set; }
        public int? Qty29 { get; set; }
        public int? Qty30 { get; set; }
        public int? Qty31 { get; set; }
        public int? QtyTC { get; set; }
        public string ClinicName { get; set; }
        public int? STT { get; set; }
    }
}
