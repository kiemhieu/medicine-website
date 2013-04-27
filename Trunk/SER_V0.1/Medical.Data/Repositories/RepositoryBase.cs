using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly MedicalContext Context ; //= new MedicalContext();
        //protected readonly FigureContext FigureContext = new FigureContext();

        public RepositoryBase(Boolean serverContext)
        {
            this.Context = serverContext ? new Medical2Context() : new MedicalContext();
        }

        public RepositoryBase() : this(false)
        {
            
        }
    }
}
