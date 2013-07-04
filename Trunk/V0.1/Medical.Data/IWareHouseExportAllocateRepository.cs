using System;
using System.Collections.Generic;
using Medical.Data.Entities;
namespace Medical.Data
{
    public interface IWareHouseExportAllocateRepository
    {
        void Delete(long id);
        WareHouseExportAllocate Get(int id);
        List<Medical.Data.Entities.WareHouseExportAllocate> GetAll();
        WareHouseExportAllocate GetById(int id);
        void Insert(WareHouseExportAllocate WareHouseExportAllocate);
        void Update(WareHouseExportAllocate WareHouseExportAllocate);
        List<WareHouseExportAllocate> GetByPaperDetailId(int id);
    }
}
