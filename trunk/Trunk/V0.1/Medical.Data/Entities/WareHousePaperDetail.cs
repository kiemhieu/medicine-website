using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("WareHousePaperDetail")]
    public class WareHousePaperDetail
    {
        public int Id { get; set; }
        public int PaperId { get; set; }
        public int MedicineId { get; set; }
        public string LotNo { get; set; }
        public int TotalVolumn { get; set; }
        public int BadVolumn { get; set; }
        public int RealityVolumn { get; set; }
        public int Unit { get; set; }
        public int? UnitPrice { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public int Version { get; set; }

        private Medicine Medicine { get; set; }
        private Clinic Clinic { get; set; }
        private WareHousePaper WareHousePaper { get; set; }
        public string MedicineName { get { return this.Medicine.Name; } }
        public string ClinicName { get { return this.Clinic.Name; } }
        public string WareHousePaperNo { get { return this.WareHousePaper.No; } }
  }
}
