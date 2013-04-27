using Medical.Forms.Enums;

namespace Medical.Forms.EventArgs
{
    public class ProgressiveUpdateArgs : System.EventArgs
    {
        public ProgressUpdateMode Mode { get; set; }
        public int Maximum { get; set; }
        public int Value { get; set; }
        public string Status { get; set; }

    }
}
