using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;


namespace Medical.Data.Repositories
{
    public class FigureRepository : RepositoryBase, IFigureRepository
    {

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Figure Get(int id)
        {
            var figure = this.Context.Figures.FirstOrDefault(x => x.Id.Equals(id));
            return figure;
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Figure GetById(int id)
        {
            var figure = this.Context.Figures.FirstOrDefault(x => x.Id.Equals(id));
            return figure;
        }



        /// <summary>
        /// Inserts the specified figure.
        /// </summary>
        /// <param name="figure">The figure.</param>
        public void Insert(Figure figure)
        {
            figure.SetInfo(false);
            figure.Version = 0;
            foreach (var item in figure.FigureDetail)
            {
                item.SetInfo(false); // Version = 0);
            }
            this.Context.Figures.Add(figure);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified figure.
        /// </summary>
        /// <param name="figure">The figure.</param>
        public void Update(Figure figure)
        {
            //var oldFigure = this.Context.Figures.FirstOrDefault(x => x.Id == figure.Id);
            //if (oldFigure == null) return;
            //oldFigure.Name = figure.Name;
            //oldFigure.Description = figure.Description;
            //// oldFigure.LastUpdatedUser = AppContext.LoggedInUser.Id;
            //oldFigure.LastUpdatedDate = DateTime.Now;
            //oldFigure.Version++;
            //this.Context.SaveChanges();

            try
            {

                var originalFigure = this.Context.Figures.FirstOrDefault(x => x.Id == figure.Id);
                if (originalFigure == null) throw new Exception("Không tồn tại dữ liệu trong CSDL.");

                var figureList = this.Context.FigureDetails.Where(x => x.FigureId == figure.Id).ToList();

                originalFigure.Name = figure.Name;
                originalFigure.Description = figure.Description;
                originalFigure.Version++;


                foreach (var orginItem in figureList)
                {
                    var item = figure.FigureDetail.FirstOrDefault(x => x.Id == orginItem.Id);
                    if (item == null)
                    {
                        this.Context.FigureDetails.Remove(orginItem);
                    }
                    else
                    {
                        orginItem.MedicineId = item.MedicineId;
                        orginItem.FigureId = item.FigureId;
                        orginItem.Volumn = item.Volumn;
                        orginItem.Version++;
                    }

                }

                foreach (var orginItem in figure.FigureDetail)
                {
                    var item = originalFigure.FigureDetail.FirstOrDefault(x => x.Id == orginItem.Id);
                    if (item != null) continue;
                    var newItem = new FigureDetail
                    {
                        Volumn = orginItem.Volumn,
                        FigureId = orginItem.FigureId,
                        MedicineId = orginItem.MedicineId,
                        Version = 0
                    };
                    originalFigure.FigureDetail.Add(newItem);
                }

                originalFigure.LastUpdatedDate = DateTime.Now;


                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(int id)
        {
            var oldFigure = this.Context.Figures.FirstOrDefault(x => x.Id == id);

            var figureDetails = this.Context.FigureDetails.Where(x => x.FigureId == oldFigure.Id).ToList();
            foreach (var figureDetail in figureDetails)
            {
                this.Context.FigureDetails.Remove(figureDetail);
            }
            this.Context.Figures.Remove(oldFigure);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Figure> GetAll()
        {

            return this.Context.Figures.ToList();

        }

        public Prescription GetCurrent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
