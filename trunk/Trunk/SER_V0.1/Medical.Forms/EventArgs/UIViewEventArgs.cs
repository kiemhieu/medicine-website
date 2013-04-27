using System;
using Medical.Forms.Enums;

namespace Medical.Forms.EventArgs
{
    public class UIViewEventArgs : System.EventArgs
    {
        public UIViewEventType EventType { get; set; }

        // View tranfet
        public String ViewId { get; set; }
        public Object ViewParameter { get; set; }
        // Message
        public String MessageId { get; set; }
        public Object[] MessageParam { get; set; }
        // Action
        public Action ActionPerform { get; set; }
        // File
        public String FileFilter { get; set; }
        // Result
        public Object Result { get; set; }
    }
}
