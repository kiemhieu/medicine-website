using System;

namespace Medical.Forms.EventArgs
{
    public class UIToViewEventArgs : System.EventArgs
    {
        public UIToViewEventArgs(String key, params Object[] parameters)
        {
            Key = key;
            Parameter = parameters;
        }
        public String Key { get; set; }
        public Object[] Parameter { get; set; }
        public Object Result { get; set; }
    }
}
