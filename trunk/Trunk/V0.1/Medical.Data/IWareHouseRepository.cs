using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHouseRepository
    {
        void Delete(int id);
        WareHouse Get(int id);
        List<WareHouse> GetAll();
        List<WareHouse> GetAll(int clinicId);
        Medical.Data.Entities.WareHouse GetById(int id);
        WareHouse GetByIdMedicine(int idMedicine);
        void Insert(WareHouse whDetail);
        void Update(WareHouse whDetail);
        WareHouse GetByIdMedicine(int idMedicine, int clinicId);
        List<WareHouse> GetByMedicineId(List<int> medicineId, int clinicId);

    }
}
