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
    }
}
