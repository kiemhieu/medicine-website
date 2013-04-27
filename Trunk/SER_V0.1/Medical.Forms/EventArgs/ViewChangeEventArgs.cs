using System;
using Medical.Forms.Enums;

namespace Medical.Forms.EventArgs
{
    public class ViewChangeEventArgs : System.EventArgs
    {
        public ViewChangeStatus Status { get; set; }

        public Boolean IsInDialogMode { get; set; }
    }
}
