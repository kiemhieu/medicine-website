using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;


namespace Medical.Data.Repositories
{
    public class WareHouseDetailRepository : RepositoryBase, IWareHouseDetailRepository
    {
        public List<WareHouseDetail> GetByMedicine(List<int> medicineIdList, int clinicId)
        {
            return this.Context.WareHouseDetails.Where(x => medicineIdList.Contains(x.MedicineId)).ToList();
        }

        public WareHouseDetail Get(int id)
        {
            var whDetail = this.Context.WareHouseDetails.FirstOrDefault(x => x.Id.Equals(id));
            return whDetail;
        }

        public WareHouseDetail GetById(int id)
        {
            var whDetail = this.Context.WareHouseDetails.FirstOrDefault(x => x.Id.Equals(id));
            return whDetail;
        }

        public List<WareHouseDetail> GetInstockProduct(int pdtId)
        {
            throw new NotImplementedException();
        }

        public void Insert(WareHouseDetail whDetail)
        {
            try
            {
                whDetail.CreatedUser = AppContext.LoggedInUser.Id;
                whDetail.CreatedDate = DateTime.Now;
                whDetail.LastUpdatedDate = DateTime.Now;
                whDetail.Version = 0;
                this.Context.WareHouseDetails.Add(whDetail);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void Update(WareHouseDetail whDetail)
        {
            try
            {
                var oldWhDetail = this.Context.WareHouseDetails.FirstOrDefault(x => x.Id == whDetail.Id);
                if (oldWhDetail == null) return;
                // oldWhDetail.WareHouseId = whDetail.WareHouseId;
                oldWhDetail.MedicineId = whDetail.MedicineId;
                oldWhDetail.WareHousePaperDetailId = whDetail.WareHousePaperDetailId;
                oldWhDetail.CreatedUser = whDetail.CreatedUser;
                oldWhDetail.CreatedDate = whDetail.CreatedDate;
                oldWhDetail.ExpiredDate = whDetail.ExpiredDate;
                oldWhDetail.LotNo = whDetail.LotNo;
                oldWhDetail.Unit = whDetail.Unit;
                oldWhDetail.UnitPrice = whDetail.UnitPrice;
                oldWhDetail.OriginalVolumn = whDetail.OriginalVolumn;
                oldWhDetail.CurrentVolumn = whDetail.CurrentVolumn;
                oldWhDetail.BadVolumn = whDetail.BadVolumn;
                oldWhDetail.LastUpdatedUser = AppContext.LoggedInUser.Id;
                oldWhDetail.LastUpdatedDate = DateTime.Now;
                oldWhDetail.Version++;
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Delete(int id)
        {
            try
            {
                var oldWHDetail = this.Context.WareHouseDetails.FirstOrDefault(x => x.Id == id);
                this.Context.WareHouseDetails.Remove(oldWHDetail);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<WareHouseDetail> GetAll()
        {
            try
            {
                List<WareHouseDetail> lst = this.Context.WareHouseDetails.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<WareHouseDetail> GetByIdMedicine(int idMedicine)
        {
            try
            {
                List<WareHouseDetail> lst =
                    this.Context.WareHouseDetails.Where(x => x.MedicineId.Equals(idMedicine)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<WareHouseDetail> GetMeicineExport(int wareHouseId, int medicineId)
        {
            try
            {
                List<WareHouseDetail> lst =
                    this.Context.WareHouseDetails.Where(x => x.MedicineId.Equals(medicineId) && x.WareHouseId == wareHouseId).OrderBy(c => c.ExpiredDate).ToList();
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
