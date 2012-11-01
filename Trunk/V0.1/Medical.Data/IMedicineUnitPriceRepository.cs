using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IMedicineUnitPriceRepository
    {
        void Insert(MedicineUnitPrice user);
        void Update(MedicineUnitPrice user);
        void Delete(int id);
        List<MedicineUnitPrice> GetAll();
    }
}
