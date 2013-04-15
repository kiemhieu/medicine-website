using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.EntitiyExtend
{
    [Table("_ReportMedicineIOByMonth")]
    public class ReportMedicineIOByMonth
    {
        public int ClinicId { get; set; }
        public int MedicineId { get; set; }
        public int YearMonth { get; set; }
        public string MedicineName { get; set; }
        public string TradeName { get; set; }
	    public DateTime MonthYear  { get; set; }
	    public string MedicineUnit  { get; set; }
	    public int? MedicineUnitPriceId { get; set; }
	    public int?MedicineUnitPrice  { get; set; }
	    public int? MedicineInputVolumn { get; set; }
	    public int? MedicineInputPrice  { get; set; }
	    public int? SumVolumnInputOpeningStock { get; set; }
	    public int? OpeningStock { get; set; }
	    public int? MedicineOutputVolumn { get; set; }
	    public int? MedicineOutputPrice { get; set; }
	    public int? SumVolumnOutputOpeningStock { get; set; }
	    public int? ClosingStock { get; set; }
	    public int? MedicineVolumn { get; set; }
	    public int? MedicinePrice { get; set; }
        public string ClinicName { get; set; }
        public int? STT { get; set; }
    }
}
