///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'MedicineDeliveryDetailAllocate'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'MedicineDeliveryDetailAllocate'.
	/// </summary>
	public class MedicineDeliveryDetailAllocate
	{
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public MedicineDeliveryDetailAllocate()
		{
			// Nothing for now.
		}
        
		#region Class Property Declarations
        public long Id { get; set; }

        public long MedicineDeliveryDetailId { get; set; }

        public int WareHouseDetailId { get; set; }

        public int Volumn { get; set; }

        public int Unit { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
