///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'MedicineUnitPrice'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'MedicineUnitPrice'.
    /// </summary>
    public class MedicineUnitPrice
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public MedicineUnitPrice()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public int Id { get; set; }

        public int MedicineId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UnitPrice { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdatedUser { get; set; }

        public int Version { get; set; }
        #endregion
    }
}
