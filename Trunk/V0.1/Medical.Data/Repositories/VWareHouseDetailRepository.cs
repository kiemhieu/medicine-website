using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities.Views;

namespace Medical.Data.Repositories {
    public class VWareHouseDetailRepository : RepositoryBase, IVWareHouseDetailRespository{

        public List<VWareHouseDetail> GetByMedicine(List<int> medicineId)
        {
            // TODO: Remove try catch
            try
            {
                var vWareHouseDetails =
                    this.Context.VWareHouseDetails.Where(x => medicineId.Contains(x.MedicineId) && x.ClinicId == AppContext.CurrentClinic.Id && x.Qty > 0).ToList();
                return vWareHouseDetails;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<VWareHouseDetail> GetByMedicine(int medicineId) {
            List<VWareHouseDetail> vWareHouseDetails = this.Context.VWareHouseDetails.Where(x => x.MedicineId == medicineId && x.ClinicId == AppContext.CurrentClinic.Id ).ToList();
            return vWareHouseDetails;
        }

        public List<VWareHouseDetail> GetByMedicine(int medicineId, int clinicId)
        {
            return this.Context.VWareHouseDetails.Where(x => x.MedicineId == medicineId && x.ClinicId == clinicId && x.Qty > 0).ToList();
        }

        public VWareHouseDetail Get(int medicineId, int clinicId, String lotNo)
        {
            return
                this.Context.VWareHouseDetails.FirstOrDefault(
                    x => x.MedicineId == medicineId && x.ClinicId == clinicId && x.LotNo.Equals(lotNo));
        }
    }
}
