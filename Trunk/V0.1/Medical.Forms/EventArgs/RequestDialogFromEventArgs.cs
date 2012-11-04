using System;
using Medical.Forms.Enums;

namespace Medical.Forms.EventArgs
{
    public class RequestDialogFromEventArgs : System.EventArgs
    {
        public DialogMode DialogMode { get; set; }

        public string MessageId { get; set; }
        public Object[] Parameters { get; set; }

        public string FileFilter { get; set; }

        public Object Result { get; set; }
    }
}
