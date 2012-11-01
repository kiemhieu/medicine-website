using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHouseDetailRepository
    {
        void Insert(WareHouseDetail user);
        void Update(WareHouseDetail user);
        void Delete(int id);
        List<WareHouseDetail> GetAll();
    }
}
