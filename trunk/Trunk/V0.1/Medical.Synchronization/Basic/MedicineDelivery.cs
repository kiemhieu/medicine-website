///////////////////////////////////////////////////////////////////////////
// Description: Mapping class for the table 'MedicineDelivery'
///////////////////////////////////////////////////////////////////////////
using System;

namespace Medical.Synchronization.Basic
{
	/// <summary>
	/// Purpose: Mapping class for the table 'MedicineDelivery'.
	/// </summary>
	public class MedicineDelivery
	{
		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public MedicineDelivery()
		{
			// Nothing for now.
		}
        
		#region Class Property Declarations
        public long Id { get; set; }

        public int ClinicId { get; set; }

        public int PatientId { get; set; }

        public long PrescriptionId { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedUser { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public int LastUpdatedUser { get; set; }

        public int Version { get; set; }
		#endregion
	}
}
