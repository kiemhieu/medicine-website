///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'MedicinePlan'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'MedicinePlan'.
	/// </summary>
	public class MedicinePlan
	{
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public MedicinePlan()
		{
			// Nothing for now.
		}

		#region Class Property Declarations
        public int Id { get; set; }

        public int ClinicId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public int Status { get; set; }

        public int ApproveId { get; set; }

        public DateTime ApproveDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUser { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdatedUser { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
