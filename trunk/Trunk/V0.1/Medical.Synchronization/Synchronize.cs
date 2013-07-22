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

        #region Varial members
        SynService.SynServiceSoapClient synSrv = new SynService.SynServiceSoapClient();
        #endregion

        /// <summary>
        /// Send all object to services
        /// </summary>
        /// <param name="ClientID"></param>
        public void SendAll(string ClientID)
        {
            //Start value
            SynEvents e = new SynEvents();
            bool bSendAll = true;

            //================================Figure===============================
            List<SynService.Figure> figures = SynDBCore<SynService.Figure>.GetAllToSend("Id");
            if (!synSrv.SendFigure(figures.ToArray(), ClientID)) bSendAll = false;
            e.Message = "Can not send all figures to server";

            //================================Figure Detail===============================
            List<SynService.FigureDetail> figuresDetail = SynDBCore<SynService.FigureDetail>.GetAllToSend("Id");
            if (!synSrv.SendFigureDetail(figuresDetail.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================Figure Detail===============================
            List<SynService.MedicineDelivery> medicineDeliveries = SynDBCore<SynService.MedicineDelivery>.GetAllToSend("Id");
            if (!synSrv.SendMedicineDelivery(medicineDeliveries.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================Medicine Delivery Detail===============================
            List<SynService.MedicineDeliveryDetail> medicineDeliveryDetail = SynDBCore<SynService.MedicineDeliveryDetail>.GetAllToSend("Id");
            if (!synSrv.SendMedicineDeliveryDetail(medicineDeliveryDetail.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================Medicine Delivery Detail Allocatel===============================
            List<SynService.MedicineDeliveryDetailAllocate> medicineDeliveryDetailAllocate = SynDBCore<SynService.MedicineDeliveryDetailAllocate>.GetAllToSend("Id");
            if (!synSrv.SendMedicineDeliveryDetailAllocate(medicineDeliveryDetailAllocate.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================MedicinePlan===============================
            List<SynService.MedicinePlan> medicinePlan = SynDBCore<SynService.MedicinePlan>.GetAllToSend("Id");
            if (!synSrv.SendMedicinePlan(medicinePlan.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================MedicinePlan===============================
            List<SynService.MedicinePlanDetail> medicinePlanDetail = SynDBCore<SynService.MedicinePlanDetail>.GetAllToSend("Id");
            if (!synSrv.SendMedicinePlanDetail(medicinePlanDetail.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================MedicineUnitPrice===============================
            List<SynService.MedicineUnitPrice> medicineUnitPrice = SynDBCore<SynService.MedicineUnitPrice>.GetAllToSend("Id");
            if (!synSrv.SendMedicineUnitPrice(medicineUnitPrice.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================Patient===============================
            List<SynService.Patient> patient = SynDBCore<SynService.Patient>.GetAllToSend("Id");
            if (!synSrv.SendPatient(patient.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================PatientFigure===============================
            List<SynService.PatientFigure> patientFigure = SynDBCore<SynService.PatientFigure>.GetAllToSend("Id");
            if (!synSrv.SendPatientFigure(patientFigure.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================Prescription===============================
            List<SynService.Prescription> prescription = SynDBCore<SynService.Prescription>.GetAllToSend("Id");
            if (!synSrv.SendPrescription(prescription.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================PrescriptionDetail===============================
            List<SynService.PrescriptionDetail> prescriptionDetail = SynDBCore<SynService.PrescriptionDetail>.GetAllToSend("Id");
            if (!synSrv.SendPrescriptionDetail(prescriptionDetail.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================WareHouse===============================
            List<SynService.WareHouse> WareHouse = SynDBCore<SynService.WareHouse>.GetAllToSend("Id");
            if (!synSrv.SendMedicineDelivery(medicineDeliveries.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================WareHouseDetail===============================
            List<SynService.WareHouseDetail> wareHouseDetail = SynDBCore<SynService.WareHouseDetail>.GetAllToSend("Id");
            if (!synSrv.SendWareHouseDetail(wareHouseDetail.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================WareHouseExportAllocate===============================
            List<SynService.WareHouseExportAllocate> wareHouseExportAllocate = SynDBCore<SynService.WareHouseExportAllocate>.GetAllToSend("Id");
            if (!synSrv.SendWareHouseExportAllocate(wareHouseExportAllocate.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================WareHouseIO===============================
            List<SynService.WareHouseIO> wareHouseIO = SynDBCore<SynService.WareHouseIO>.GetAllToSend("Id");
            if (!synSrv.SendWareHouseIO(wareHouseIO.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================WareHouse IO Detail===============================
            List<SynService.WareHouseIODetail> wareHouseIODetail = SynDBCore<SynService.WareHouseIODetail>.GetAllToSend("Id");
            if (!synSrv.SendWareHouseIODetail(wareHouseIODetail.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            //================================WareHouse Minimum Allow===============================
            List<SynService.WareHouseMinimumAllow> wareHouseMinimumAllow = SynDBCore<SynService.WareHouseMinimumAllow>.GetAllToSend("Id");
            if (!synSrv.SendWareHouseMinimumAllow(wareHouseMinimumAllow.ToArray(), ClientID)) bSendAll = false;
            //e.Message = "Can not send all figures to server";

            if (bSendAll && SendingCompleted != null) SendingCompleted(figures, e);
        }

        public void ReiceiveAll()
        {
            if (ReceivingCompleted != null) ReceivingCompleted(null, null);
        }
    }
}
