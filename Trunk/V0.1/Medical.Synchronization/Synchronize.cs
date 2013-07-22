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

            //================================Figure===============================
            List<SynService.Figure> figures = SynDBCore<SynService.Figure>.GetAllToSend("Id");
            if (!synSrv.SendFigure(figures.ToArray())) bSendAll = false;
            e.Message = "Can not send all figures to server";

            //================================Figure Detail===============================
            List<SynService.FigureDetail> figuresDetail = SynDBCore<SynService.FigureDetail>.GetAllToSend("Id");
            //if (!synSrv.SendFigureDe(figuresDetail.ToArray())) bSendAll = false;
            //e.Message = "Can not send all figures to server";




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
           
            return false;
        }
        #endregion
    }
}
