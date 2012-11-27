using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class FigureDetailRepository : RepositoryBase, IFigureDetailRepository
    {
        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Insert(FigureDetail user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(FigureDetail user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<FigureDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the by figure.
        /// </summary>
        /// <param name="figureId">The figure id.</param>
        /// <returns></returns>
        public List<FigureDetail> GetByFigure(int figureId)
        {
            return this.Context.FigureDetails.Where(x => x.FigureId == figureId).ToList();
        }
    }
}
