using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineRepository
    {
        void Insert(Medicine user);
        void Update(Medicine user);
        void Delete(int id);
        List<Medicine> GetAll();
    }
}
