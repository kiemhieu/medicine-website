using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicinePlanDetailRepository
    {
        void Delete(int id);
        MedicinePlanDetail Get(int id);
        List<MedicinePlanDetail> GetAll();
        MedicinePlanDetail GetById(int id);
        void Insert(MedicinePlanDetail MedicinePlanDetail);
        void Update(MedicinePlanDetail medicinePlanDetail);
    }
}
