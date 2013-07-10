///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'PatientFigure'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'PatientFigure'.
    /// </summary>
    public class PatientFigure
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public PatientFigure()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public long Id { get; set; }

        public int PatientId { get; set; }

        public int FigureId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FromDate { get; set; }

        public string Description { get; set; }

        public DateTime LastUpdatedDate { get; set; }
        #endregion
    }
}
