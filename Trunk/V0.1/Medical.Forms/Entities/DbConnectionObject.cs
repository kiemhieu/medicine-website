using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Forms.Entities
{
    public class DbConnectionObject
    {
        public String Server { get; set; }
        public String Db { set; get;}
        public String User { get; set; }
        public String Pass { get; set; }
        public String Name { get; set; }
        public String Provider { get; set; }
        public Boolean IsPersistSecurity { get; set; }
        public String Intergrated { get; set; }

        public DbConnectionObject()
        {
            
        }

        public DbConnectionObject(String connection)
        {
            String[] strs = connection.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (String  str in strs )
            {
                String [] items = str.Split(new string[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                switch (items[0].ToLower())
                {
                    case "data source":
                        this.Server = items[1];
                        break;
                    case "initial catalog":
                        this.Db = items[1];
                        break;
                    case "pwd":
                        this.Pass = items[1];
                        break;
                    case "user id":
                        this.User = items[1];
                        break;
                    case "persist security info":
                        this.IsPersistSecurity = Boolean.Parse(items[1]);
                        break;
                    case "integrated security":
                        this.Intergrated = items[1];
                        break;
                    default:
                        break;
                }
            }
        }

        public override String ToString()
        {
            return
                String.Format("Data Source={0};Initial Catalog={1}; User ID={2}; pwd={3};Persist Security Info = {4};Integrated Security={5};", Server, Db, User, Pass, IsPersistSecurity, Intergrated);
        }
    }
}
