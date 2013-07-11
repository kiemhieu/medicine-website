using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Synchronization.Basic;

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
            bool bSendAll = true;
            if (!SendAllFigure(null)) bSendAll = false;

            if (bSendAll && SendingCompleted != null) SendingCompleted(null, null);
        }


        public void ReiceiveAll()
        {
            if (ReceivingCompleted != null) ReceivingCompleted(null, null);
        }

        #region Private functions
        private bool SendAllFigure(Figure figures)
        {
            return false;
        }
        #endregion
    }
}
