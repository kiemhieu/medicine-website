using System;
using Medical.Forms.Enums;

namespace Medical.Forms.EventArgs
{
    public class ViewToFormEventArgs
    {
        public UIViewEventType ActionType { get; set; }
        public Object Parameter { get; set; }
        public Object Result { get; set; }
    }
}
