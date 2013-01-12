using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IWareHousePaperDetailRepository
    {
        void Insert(WareHouseIODetail user);
        void Update(WareHouseIODetail user);
        void Delete(int id);
        List<WareHouseIODetail> GetAll();
    }
}
