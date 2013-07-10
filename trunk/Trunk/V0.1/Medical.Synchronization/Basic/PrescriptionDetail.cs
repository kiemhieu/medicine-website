///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'PrescriptionDetail' 
/////////////////////////////////////////////////////////////////////////// 
namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'PrescriptionDetail'.
	/// </summary>
	public class PrescriptionDetail
	{ 
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public PrescriptionDetail()
		{
			// Nothing for now.
		}
         
		#region Class Property Declarations
        public long Id { get; set; }

        public long PrescriptionId { get; set; }

        public int FigureDetailId { get; set; }

        public int MedicineId { get; set; }

        public int Day { get; set; }

        public int VolumnPerDay { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
