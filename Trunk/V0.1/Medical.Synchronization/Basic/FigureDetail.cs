///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'FigureDetail'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'FigureDetail'.
    /// </summary>
    public class FigureDetail
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public FigureDetail()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public int Id { get; set; }

        public int FigureId { get; set; }

        public int MedicineId { get; set; }

        public int Volumn { get; set; }

        public int Version { get; set; }
        #endregion
    }
}
