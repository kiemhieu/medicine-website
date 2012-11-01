using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IFigureDetailRepository
    {
        void Insert(FigureDetail user);
        void Update(FigureDetail user);
        void Delete(int id);
        List<FigureDetail> GetAll();
    }
}
