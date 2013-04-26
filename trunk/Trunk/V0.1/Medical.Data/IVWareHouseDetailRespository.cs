using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities.Views;

namespace Medical.Data {

    public interface IVWareHouseDetailRespository
    {
        List<VWareHouseDetail> GetByMedicine(List<int> medicineId);
        List<VWareHouseDetail> GetByMedicine(int medicineId);
        List<VWareHouseDetail> GetByMedicine(int medicineId, int clinicId);
        VWareHouseDetail Get(int medicineId, int clinicId, String lotNo);
        List<VWareHouseDetail> GetWarehouseDetailForOutput(DateTime date, int medicineId, int clinicId);
    }
}
