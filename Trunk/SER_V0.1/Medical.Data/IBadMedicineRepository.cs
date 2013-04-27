using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IBadMedicineRepository
    {
        void Insert(BadMedicine user);
        void Update(BadMedicine user);
        void Delete(int id);
        List<BadMedicine> GetAll();
        BadMedicine Get(int id);
    }
}
