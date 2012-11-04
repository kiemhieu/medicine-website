using System;

namespace Medical.Forms.EventArgs
{
    public class ActionArgs : System.EventArgs
    {
         public Action MethodExecuter { get; set; }

        public ActionArgs()
        {
            
        }

        public ActionArgs(Action action)
        {
            this.MethodExecuter = action;
        }
    }
}
