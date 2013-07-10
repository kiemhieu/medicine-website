///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'MedicinePlanDetail'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'MedicinePlanDetail'.
	/// </summary>
	public class MedicinePlanDetail
	{ 
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public MedicinePlanDetail()
		{
			// Nothing for now.
		}
         
		#region Class Property Declarations
        public int Id { get; set; }

        public int PlanId { get; set; }

        public int MedicineId { get; set; }

        public int InStock { get; set; }

        public int LastMonthUsage { get; set; }

        public int CurrentMonthUsage { get; set; }

        public int Required { get; set; }

        public int UnitPrice { get; set; }

        public int Amount { get; set; }

        public int Version { get; set; }

        public DateTime LastUpdatedDate { get; set; }
		#endregion
	}
}
