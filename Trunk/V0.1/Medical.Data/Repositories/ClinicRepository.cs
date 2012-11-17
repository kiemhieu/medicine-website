﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;
using Medical.Forms.Implements;


namespace Medical.Data.Repositories {
    public class ClinicRepository : RepositoryBase, IClinicRepository
    {

        public Clinic Get(int id)
        {
            var clinic = this.Context.Clinics.FirstOrDefault(x => x.Id.Equals(id));
            return clinic;
        }
        public Clinic GetById(int id)
        {
            var clinic = this.Context.Clinics.FirstOrDefault(x => x.Id.Equals(id));
            return clinic;
        }

     

        public void Insert(Clinic clinic)
        {
            clinic.CreatedDate = DateTime.Now;
            clinic.CreatedUser = AppContext.LoggedInUser.Id;
            clinic.LastUpdatedUser = AppContext.LoggedInUser.Id;
            clinic.LastUpdatedDate = DateTime.Now;
            clinic.Version = 0;
            this.Context.Clinics.Add(clinic);
            this.Context.SaveChanges();
        }

        public void Update(Clinic clinic)
        {
            try
            {
                var oldClinic = this.Context.Clinics.FirstOrDefault(x => x.Id == clinic.Id);
                if (oldClinic == null) return;
                oldClinic.Name = clinic.Name;
                oldClinic.Address = clinic.Address;
                
                oldClinic.Description = clinic.Description;
                oldClinic.CreatedDate = clinic.CreatedDate;
                oldClinic.CreatedUser = clinic.CreatedUser;
                oldClinic.LastSyncTime = clinic.LastSyncTime;
                oldClinic.Type = clinic.Type;
                oldClinic.LastUpdatedUser = AppContext.LoggedInUser.Id;
                oldClinic.LastUpdatedDate = DateTime.Now;
                oldClinic.Version++;
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
                var oldClinic = this.Context.Clinics.FirstOrDefault(x => x.Id == id);
                this.Context.Clinics.Remove(oldClinic);
                this.Context.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        List<Clinic> IClinicRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Clinic> GetAll() {
            try
            {
                List<Clinic> lst = this.Context.Clinics.ToList();
                return lst;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}