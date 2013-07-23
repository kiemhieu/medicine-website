using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data.Repositories {
    public class UserRepository : RepositoryBase, IUserRepository {

        public UserRepository() : base()
        {
        }

        public UserRepository(bool serverContext) : base(serverContext)
        {
            
        }

        public User Get(string username)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName.Equals(username));
            return user;
        }

        public User Get(string username, int clinicId)
        {
            var user = this.Context.Users.FirstOrDefault(x => x.UserName.Equals(username) && x.ClinicId == clinicId);
            return user;
        }

        public List<User> Get(int clinic)
        {
            var user = this.Context.Users.Where(x => x.ClinicId == clinic).OrderBy(x=>x.CreatedDate).ToList();
            return user;
        }


        public bool Login(string username, string password, int clinic) {
            var user =
                this.Context.Users.FirstOrDefault(
                    x =>
                    x.UserName.Equals(username) && x.Password.Equals(password) && x.Active == true &&
                    x.ClinicId == clinic);
            return user != null;
        }

        public void Insert(User user) {
            user.CreatedDate = DateTime.Now;
            user.LastUpdatedDate = DateTime.Now;
            user.Version = 0;
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public void Update(User user) {
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

        public void Delete(int id) {
            var oldUsr = this.Context.Users.FirstOrDefault(x => x.Id == id);
            this.Context.Users.Remove(oldUsr);
            this.Context.SaveChanges();
        }

        public List<User> GetAll() {
            return this.Context.Users.ToList();
        }
    }
}
