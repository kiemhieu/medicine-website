using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicinePlanDetailRepository
    {
        void Insert(MedicinePlanDetail user);
        void Update(MedicinePlanDetail user);
        void Delete(int id);
        List<MedicinePlanDetail> GetAll();
    }
}
