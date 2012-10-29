using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Insert(User user)
        {
            user.CreatedDate = DateTime.Now;
            user.LastUpdatedDate = DateTime.Now;
            user.Version = 0;
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public void Update(User user)
        {
            var oldUsr = this.Context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (oldUsr == null) return;
            oldUsr.Name = user.Name;
            oldUsr.UserName = user.UserName;
            oldUsr.Password = user.Password;
            oldUsr.Active = user.Active;
            oldUsr.Role = user.Role;
            oldUsr.ClinicId = user.ClinicId;
            oldUsr.LastUpdatedDate = DateTime.Now;
            oldUsr.Version++;
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var oldUsr = this.Context.Users.FirstOrDefault(x => x.Id == id);
            this.Context.Users.Remove(oldUsr);
            this.Context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return this.Context.Users.ToList();
        }
    }
}
