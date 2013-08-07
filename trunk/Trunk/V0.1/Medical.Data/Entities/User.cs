using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Medical.Data.Entities
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public int? ClinicId { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CrearedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int? LastUpdatedUser { get; set; }
        public int Version { get; set; }

        [NotMapped]
        public String RoleName
        {
            get
            {
                switch (Role)
                {
                    case 0:
                        return "Quản trị viên";
                    case 1:
                        return "Bác sĩ";
                    case 2:
                        return "Dược sĩ";
                    case 3:
                        return "";
                }
                return "";
            }
        }
    }
}
