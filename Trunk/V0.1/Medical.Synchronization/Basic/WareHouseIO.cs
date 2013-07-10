///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'WareHouseIO'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'WareHouseIO'.
	/// </summary>
	public class WareHouseIO
	{
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public WareHouseIO()
		{
			// Nothing for now.
		}
        
		#region Class Property Declarations
        public int Id { get; set; }

        public string Type { get; set; }

        public int ClinicId { get; set; }

        public DateTime Date { get; set; }

        public string No { get; set; }

        public string Person { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Note { get; set; }

        public string AttachmentNo { get; set; }

        public int CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
