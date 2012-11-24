using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;


namespace Medical.Data.Repositories {
    public class FigureRepository : RepositoryBase, IFigureRepository {

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Figure Get(int id) {
            var figure = this.Context.Figures.FirstOrDefault(x => x.Id.Equals(id));
            return figure;
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Figure GetById(int id) {
            var figure = this.Context.Figures.FirstOrDefault(x => x.Id.Equals(id));
            return figure;
        }



        /// <summary>
        /// Inserts the specified figure.
        /// </summary>
        /// <param name="figure">The figure.</param>
        public void Insert(Figure figure) {
            // figure.LastUpdatedUser = AppContext.LoggedInUser.Id;
            figure.LastUpdatedDate = DateTime.Now;
            figure.Version = 0;
            this.Context.Figures.Add(figure);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified figure.
        /// </summary>
        /// <param name="figure">The figure.</param>
        public void Update(Figure figure) {
            var oldFigure = this.Context.Figures.FirstOrDefault(x => x.Id == figure.Id);
            if (oldFigure == null) return;
            oldFigure.Name = figure.Name;
            oldFigure.Description = figure.Description;
            // oldFigure.LastUpdatedUser = AppContext.LoggedInUser.Id;
            oldFigure.LastUpdatedDate = DateTime.Now;
            oldFigure.Version++;
            this.Context.SaveChanges();
        }


        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id) {
            var oldFigure = this.Context.Figures.FirstOrDefault(x => x.Id == id);
            this.Context.Figures.Remove(oldFigure);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetAll() {

            return this.Context.Figures.ToList();

        }

        public Prescription GetCurrent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
