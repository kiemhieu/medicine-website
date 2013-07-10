///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'WareHouseIODetail' 
///////////////////////////////////////////////////////////////////////////
using System; 

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'WareHouseIODetail'.
	/// </summary>
	public class WareHouseIODetail
	{ 
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public WareHouseIODetail()
		{
			// Nothing for now.
		}
         
		#region Class Property Declarations
        public int Id { get; set; }

        public int WareHouseIOId { get; set; }

        public int MedicineId { get; set; }

        public string LotNo { get; set; }

        public DateTime ExpireDate { get; set; }

        public int Qty { get; set; }

        public int UnitPrice { get; set; }

        public int Unit { get; set; }

        public int Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Version { get; set; }

        public string Type { get; set; }
		#endregion
	}
}
