///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'WareHouse'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'WareHouse'.
	/// </summary>
	public class WareHouse
	{
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public WareHouse()
		{
			// Nothing for now.
		}
        
		#region Class Property Declarations
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public int MedicineId { get; set; }

        public int Volumn { get; set; }

        public int MinAllowed { get; set; }

        public int LastUpdatedUser { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
