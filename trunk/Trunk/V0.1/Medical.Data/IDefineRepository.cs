using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IDefineRepository
    {
        void Insert(Define user);
        void Update(Define user);
        void Delete(int id);
        List<Define> GetAll();
    }
}
