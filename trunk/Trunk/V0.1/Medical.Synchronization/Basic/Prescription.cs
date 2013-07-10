///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'Prescription'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'Prescription'.
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public Prescription()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public long Id { get; set; }

        public int ClinicId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }

        public int FigureId { get; set; }

        public string Note { get; set; }

        public DateTime RecheckDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUser { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdatedUser { get; set; }

        public int Version { get; set; }
        #endregion
    }
}
