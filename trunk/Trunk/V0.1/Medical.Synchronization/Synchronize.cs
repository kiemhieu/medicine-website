using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Synchronization
{
    public class Synchronize
    {
        #region Events hander return
        public EventHandler SendingCompleted;
        public EventHandler ReceivingCompleted;
        #endregion

        public void SendAll()
        {

            if (SendingCompleted != null) SendingCompleted(null, null);
        }


        public void ReiceiveAll()
        {
            if (ReceivingCompleted != null) ReceivingCompleted(null, null);
        }
    }
}
