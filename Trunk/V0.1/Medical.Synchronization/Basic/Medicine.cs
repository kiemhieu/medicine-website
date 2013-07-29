using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Synchronization.Basic
{
    /// <summary>
    /// Purpose: Mapping class for the table 'Medicine'.
    /// </summary>
    public class Medicine
    {
        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public Medicine()
        {
            // Nothing for now.
        }

        #region Class Property Declarations
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string ContentUnit { get; set; }
        public string Unit { get; set; }
        public string TradeName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public int Version { get; set; }
        #endregion
    }
}
