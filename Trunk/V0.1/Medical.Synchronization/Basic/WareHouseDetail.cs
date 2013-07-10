///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'WareHouseDetail'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'WareHouseDetail'.
    /// </summary>
    public class WareHouseDetail
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public WareHouseDetail()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public int Id { get; set; }

        public int WareHouseId { get; set; }

        public int MedicineId { get; set; }

        public string LotNo { get; set; }

        public DateTime ExpiredDate { get; set; }

        public int OriginalVolumn { get; set; }

        public int CurrentVolumn { get; set; }

        public int BadVolumn { get; set; }

        public int Unit { get; set; }

        public int UnitPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUser { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdatedUser { get; set; }

        public int Version { get; set; }
        #endregion
    }
}
