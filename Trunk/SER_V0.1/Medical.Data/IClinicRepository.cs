using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IClinicRepository
    {
        void Insert(Clinic user);
        void Update(Clinic user);
        void Delete(int id);
        List<Clinic> GetAll();
        Clinic Get(int id);
    }
}
