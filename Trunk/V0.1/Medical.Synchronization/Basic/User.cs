using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'User'.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public User()
        {
            // Nothing for now.
        }

        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CrearedUser { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedUser { get; set; }
        public int Version { get; set; }
    }
}
