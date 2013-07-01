using System;

namespace Medical.Synchronization
{
    /// <summary>
    /// Creator: HieuNK
    /// Date   : 2013.07.01
    /// Purpose: Fire event when syn completed
    /// </summary>
    public class SynEvents:EventArgs
    {
        public string Message { get; set; }
    }
}
