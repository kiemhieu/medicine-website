using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicinePlanRepository
    {
        void Insert(MedicinePlan user);
        void Update(MedicinePlan user);
        void Delete(int id);
        List<MedicinePlan> GetAll();
    }
}
