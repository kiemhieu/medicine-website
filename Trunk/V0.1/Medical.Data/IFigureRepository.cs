using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IFigureRepository
    {
        void Insert(Figure user);
        void Update(Figure user);
        void Delete(int id);
        List<Figure> GetAll();
        Figure GetCurrent(int id);
        List<Figure> GetByClinicId(int clinicId);
    }
}
