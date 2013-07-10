///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'WareHouseExportAllocate' 
///////////////////////////////////////////////////////////////////////////
using System; 

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'WareHouseExportAllocate'.
	/// </summary>
	public class WareHouseExportAllocate
	{ 
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public WareHouseExportAllocate()
		{
			// Nothing for now.
		}
         
		#region Class Property Declarations
        public long Id { get; set; }

        public int WareHoudeIODetailId { get; set; }

        public int WareHouseDetailId { get; set; }

        public int Volumn { get; set; }

        public int Unit { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
