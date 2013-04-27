using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Data.Entities;

namespace Medical.Data
{
    public interface IUserRepository
    {
        User Get(string username);
        bool Login(string username, string password, int clinic);
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
        List<User> GetAll();
    }
}
