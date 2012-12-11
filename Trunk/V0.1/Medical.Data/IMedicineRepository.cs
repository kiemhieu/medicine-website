using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineRepository
    {
        void Insert(Medicine medicine);
        void Update(Medicine medicine);
        void Delete(int id);
        List<Medicine> Get(int type);
        Medicine GetById(int id);
        List<Medicine> GetAll();
        
    }
}
