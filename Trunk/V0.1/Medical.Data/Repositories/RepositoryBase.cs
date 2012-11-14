using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly MedicalContext Context = new MedicalContext();
        //protected readonly FigureContext Context = new FigureContext();
    }
}
