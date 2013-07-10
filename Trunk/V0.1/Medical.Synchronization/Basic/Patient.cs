///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'Patient'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'Patient'.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public Patient()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int BirthYear { get; set; }

        public string Sexual { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUser { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdatedUser { get; set; }

        public int Version { get; set; }
        #endregion
    }
}
