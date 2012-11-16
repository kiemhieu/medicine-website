using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Forms.Implements;


namespace Medical.Data.Repositories {
    public class FigureRepository : RepositoryBase, IFigureRepository
    {

        public Figure Get(int id)
        {
            var figure = this.Context.Figures.FirstOrDefault(x => x.Id.Equals(id));
            return figure;
        }
        public Figure GetById(int id)
        {
            var figure = this.Context.Figures.FirstOrDefault(x => x.Id.Equals(id));
            return figure;
        }

     

        public void Insert(Figure figure)
        {
            figure.LastUpdatedUser = AppContext.LoggedInUser;
            figure.LastUpdatedDate = DateTime.Now;
            figure.Version = 0;
            this.Context.Figures.Add(figure);
            this.Context.SaveChanges();
        }

        public void Update(Figure figure)
        {
            var oldFigure = this.Context.Figures.FirstOrDefault(x => x.Id == figure.Id);
            if (oldFigure == null) return;
            oldFigure.Name = figure.Name;
            oldFigure.Description = figure.Description;
            oldFigure.LastUpdatedUser =  AppContext.LoggedInUser;
            oldFigure.LastUpdatedDate = DateTime.Now;
            oldFigure.Version++;
            this.Context.SaveChanges();
        }

    
        public void Delete(int id) {
            var oldFigure = this.Context.Figures.FirstOrDefault(x => x.Id == id);
            this.Context.Figures.Remove(oldFigure);
            this.Context.SaveChanges();
        }

        List<Figure> IFigureRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Figure> GetAll() {
            return this.Context.Figures.ToList();
        }
    }
}
