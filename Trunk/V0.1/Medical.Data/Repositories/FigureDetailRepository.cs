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
        public void Update(Figure figure)
        {
            throw new NotImplementedException();
            //try
            //{

            //    var originalFigure = this.Context.Figures.FirstOrDefault(x => x.Id == figure.Id);
            //    if (originalFigure == null) throw new Exception("Không tồn tại dữ liệu trong CSDL.");

            //    var figureList = this.Context.FigureDetails.Where(x => x.FigureId == figure.Id).ToList();

            //    originalFigure.Name = figure.Name;
            //    originalFigure.Description = figure.Description;
            //    originalFigure.Version++;


            //    foreach (var orginItem in figureList)
            //    {
            //        var item = figure.FigureDetail.FirstOrDefault(x => x.Id == orginItem.Id);
            //        if (item == null)
            //        {
            //            this.Context.FigureDetails.Remove(orginItem);
            //        }
            //        else
            //        {
            //            orginItem.MedicineId = item.MedicineId;
            //            orginItem.FigureId = item.FigureId;
            //            orginItem.Volumn = item.Volumn;
            //            orginItem.Version++;
            //        }

            //    }

            //    foreach (var orginItem in figure.FigureDetail)
            //    {
            //        var item = originalFigure.FigureDetail.FirstOrDefault(x => x.Id == orginItem.Id);
            //        if (item != null) continue;
            //        var newItem = new FigureDetail
            //        {
            //            Volumn = orginItem.Volumn,
            //            FigureId = orginItem.FigureId,
            //            MedicineId = orginItem.MedicineId,
            //            Version = 0
            //        };
            //        originalFigure.FigureDetail.Add(newItem);
            //    }

            //    originalFigure.LastUpdatedDate = DateTime.Now;


            //    this.Context.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
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
