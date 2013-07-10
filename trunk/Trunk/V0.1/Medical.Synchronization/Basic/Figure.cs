///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'Figure'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'Figure'.
    /// </summary>
    public class Figure
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public Figure()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClinicId { get; set; } 

        public string Description { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdatedUser { get; set; }

        public int Version { get; set; }
        #endregion
    }
}
