﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
//using Medical.Forms.Implements;


namespace Medical.Data.Repositories {
    public class WareHouseIODetailRepository : RepositoryBase, IWareHouseIODetailRepository
    {

        public WareHouseIODetail Get(int id)
        {
            var whPaperDetail = this.Context.WareHouseIODetail.FirstOrDefault(x => x.Id.Equals(id));
            return whPaperDetail;
        }
        public WareHouseIODetail GetById(int id)
        {
            var whPaperDetail = this.Context.WareHouseIODetail.FirstOrDefault(x => x.Id.Equals(id));
            return whPaperDetail;
        }



        public void Insert(WareHouseIODetail whIoDetail)
        {
            try
            {
                whIoDetail.CreatedDate = DateTime.Now;
                whIoDetail.Version = 0;
                this.Context.WareHouseIODetail.Add(whIoDetail);
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            { 
                
            }
        }

        public void Update(WareHouseIODetail whIoDetail)
        {
            try
            {
                var oldwhPaperDetail = this.Context.WareHouseIODetail.FirstOrDefault(x => x.Id == whIoDetail.Id);
                if (oldwhPaperDetail == null) return;
                // oldwhPaperDetail.WareHousePaperId = whIoDetail.WareHousePaperId;
                oldwhPaperDetail.MedicineId = whIoDetail.MedicineId;                                
                oldwhPaperDetail.ExpireDate = whIoDetail.ExpireDate;
                oldwhPaperDetail.LotNo = whIoDetail.LotNo;
                // oldwhPaperDetail.Unit = whIoDetail.Unit;
                oldwhPaperDetail.UnitPrice = whIoDetail.UnitPrice;
                // oldwhPaperDetail.Volumn = whIoDetail.Volumn;              
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
                var oldwhPaper = this.Context.WareHouseIODetail.FirstOrDefault(x => x.Id == id);
                this.Context.WareHouseIODetail.Remove(oldwhPaper);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

 
        public List<WareHouseIODetail> GetAll() {
            try
            {
                List<WareHouseIODetail> lst = this.Context.WareHouseIODetail.ToList();
                return lst;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<WareHouseIODetail> GetByIOId(int id)
        {
            try
            {
                List<WareHouseIODetail> lst =
                    this.Context.WareHouseIODetail.Where(x => x.WareHouseIOId.Equals(id)).ToList();
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
