///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'WareHouseMinimumAllow'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'WareHouseMinimumAllow'.
	/// </summary>
	public class WareHouseMinimumAllow
	{ 
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public WareHouseMinimumAllow()
		{
			// Nothing for now.
		} 

		#region Class Property Declarations
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public int MedicineId { get; set; }

        public int Amount { get; set; }

        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUser { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdateUser { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
