using System;
using System.Collections.Generic;
using Medical.Data.Entities;
namespace Medical.Data
{
    public interface IWareHouseExportAllocateRepository
    {
        void Delete(long id);
        Medical.Data.Entities.WareHouseExportAllocate Get(int id);
        System.Collections.Generic.List<Medical.Data.Entities.WareHouseExportAllocate> GetAll();
        Medical.Data.Entities.WareHouseExportAllocate GetById(int id);
        void Insert(Medical.Data.Entities.WareHouseExportAllocate WareHouseExportAllocate);
        void Update(Medical.Data.Entities.WareHouseExportAllocate WareHouseExportAllocate);
        List<WareHouseExportAllocate> GetByPaperDetailId(int id);
    }
}
