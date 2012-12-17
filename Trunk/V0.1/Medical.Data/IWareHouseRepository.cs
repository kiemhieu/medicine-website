using System;
using Medical.Data.Entities;
namespace Medical.Data
{
    public interface IWareHouseRepository
    {
        void Delete(int id);
        Medical.Data.Entities.WareHouse Get(int id);
        System.Collections.Generic.List<Medical.Data.Entities.WareHouse> GetAll();
        Medical.Data.Entities.WareHouse GetById(int id);
        WareHouse GetByIdMedicine(int idMedicine);
        void Insert(Medical.Data.Entities.WareHouse whDetail);
        void Update(Medical.Data.Entities.WareHouse whDetail);
        WareHouse GetByIdMedicine(int idMedicine, int clinicId);
    }
}
