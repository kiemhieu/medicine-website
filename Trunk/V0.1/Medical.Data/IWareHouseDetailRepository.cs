using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHouseDetailRepository
    {
        List<WareHouseDetail> GetInstockProduct(int pdtId);
        void Insert(WareHouseDetail user);
        void Update(WareHouseDetail user);
        void Delete(int id);
        List<WareHouseDetail> GetAll();
    }
}
