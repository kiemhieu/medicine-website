using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;


namespace Medical.Data.Repositories {
    public class WareHousePaperDetailRepository : RepositoryBase, IWareHousePaperDetailRepository
    {

        public WareHousePaperDetail Get(int id)
        {
            var whPaperDetail = this.Context.WareHousePaperDetails.FirstOrDefault(x => x.Id.Equals(id));
            return whPaperDetail;
        }
        public WareHousePaperDetail GetById(int id)
        {
            var whPaperDetail = this.Context.WareHousePaperDetails.FirstOrDefault(x => x.Id.Equals(id));
            return whPaperDetail;
        }



        public void Insert(WareHousePaperDetail whPaperDetail)
        {
            try
            {
                whPaperDetail.CreatedDate = DateTime.Now;
                whPaperDetail.Version = 0;
                this.Context.WareHousePaperDetails.Add(whPaperDetail);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            { 
                
            }
        }

        public void Update(WareHousePaperDetail whPaperDetail)
        {
            try
            {
                var oldwhPaperDetail = this.Context.WareHousePaperDetails.FirstOrDefault(x => x.Id == whPaperDetail.Id);
                if (oldwhPaperDetail == null) return;
                oldwhPaperDetail.WareHousePaperId = whPaperDetail.WareHousePaperId;
                oldwhPaperDetail.MedicineId = whPaperDetail.MedicineId;                                
                oldwhPaperDetail.ExpireDate = whPaperDetail.ExpireDate;
                oldwhPaperDetail.LotNo = whPaperDetail.LotNo;
                oldwhPaperDetail.Unit = whPaperDetail.Unit;
                oldwhPaperDetail.UnitPrice = whPaperDetail.UnitPrice;
                oldwhPaperDetail.Volumn = whPaperDetail.Volumn;              
                // oldwhPaperDetail.LastUpdatedUser = AppContext.LoggedInUser.Id;                
                oldwhPaperDetail.Version++;
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

    
        public void Delete(int id) {
            try
            {
                var oldwhPaper = this.Context.WareHousePaperDetails.FirstOrDefault(x => x.Id == id);
                this.Context.WareHousePaperDetails.Remove(oldwhPaper);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

 
        public List<WareHousePaperDetail> GetAll() {
            try
            {
                List<WareHousePaperDetail> lst = this.Context.WareHousePaperDetails.ToList();
                return lst;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<WareHousePaperDetail> GetByPaperId(int idPaper)
        {
            try
            {
                List<WareHousePaperDetail> lst =
                    this.Context.WareHousePaperDetails.Where(x => x.WareHousePaperId.Equals(idPaper)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
