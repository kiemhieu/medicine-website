using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Synchronization.Basic;
using System.IO;
using System.Xml.Serialization;

namespace Medical.Synchronization
{
    public delegate void SynEventHandler(object sender, SynEvents e);
    public class Synchronize
    {
        #region Events hander return
        public SynEventHandler SendingCompleted;
        public SynEventHandler ReceivingCompleted;
        #endregion

        public void SendAll()
        {
            //Start value
            SynEvents e = new SynEvents();
            bool bSendAll = true;

            List<Figure> figures = new List<Figure>();
            if (!SendAllFigure(figures)) bSendAll = false;
            e.Message = "Can not send all figures to server";
            if (bSendAll && SendingCompleted != null) SendingCompleted(figures, e);


        }


        public void ReiceiveAll()
        {
            
            if (ReceivingCompleted != null) ReceivingCompleted(null, null);
        }

        #region Private functions
        SynService.SynServiceSoapClient synSrv = new SynService.SynServiceSoapClient();
        private bool SendAllFigure(List<Figure> figures)
        {
            synSrv.SendFigure(figures);
            return false;
        }
        #endregion
    }
}
