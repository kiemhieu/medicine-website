using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medical.Synchronization.Basic;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Medical.Synchronization
{
    public class Synchronize
    {
        #region Events hander return
        public event EventHandler SendingCompleted;
        public event EventHandler ReceivingCompleted;
        #endregion

        #region Varial members
        SynService.SynServiceSoapClient synSrv;
        #endregion

        public Synchronize()
        {
            Uri serviceUri = new Uri("http://localhost:5384/Medical.Web/Services/SynService.asmx");
            EndpointAddress endpointAddress = new EndpointAddress(serviceUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.UseDefaultWebProxy = true;
            synSrv = new SynService.SynServiceSoapClient(binding, endpointAddress);
        }

        /// <summary>
        /// Send all object to services
        /// </summary>
        /// <param name="ClientID"></param>
        public void SendAll(string ClientID)
        {
            Thread thread = new Thread(() => DoSending(ClientID));
            thread.Start();
        }

        public void ReiceiveAll()
        {
            if (ReceivingCompleted != null) ReceivingCompleted(null, null);
        }

        #region Private functions
        /// <summary>
        /// Actions when sending to server
        /// </summary>
        /// <param name="ClientID"></param>
        private void DoSending(string ClientID)
        {
            //Start value
            SynEvents e = new SynEvents();
            //================================Figure===============================
            List<SynService.Figure> figures = SynDBCore<SynService.Figure>.GetAllToSend("Id");
            SynService.Figure[] figures2 = synSrv.SendFigure(figures.ToArray(), ClientID);
            SynDBCore<SynService.Figure>.SaveLog(new List<SynService.Figure>(figures2));

            //================================Figure Detail===============================
            List<SynService.FigureDetail> figuresDetail = SynDBCore<SynService.FigureDetail>.GetAllToSend("Id");
            SynService.FigureDetail[] figuresDetail2 = synSrv.SendFigureDetail(figuresDetail.ToArray(), ClientID);
            SynDBCore<SynService.FigureDetail>.SaveLog(new List<SynService.FigureDetail>(figuresDetail2));

            //================================Figure Detail===============================
            List<SynService.MedicineDelivery> medicineDeliveries = SynDBCore<SynService.MedicineDelivery>.GetAllToSend("Id");
            SynService.MedicineDelivery[] medicineDeliveries2 = synSrv.SendMedicineDelivery(medicineDeliveries.ToArray(), ClientID);
            SynDBCore<SynService.MedicineDelivery>.SaveLog(new List<SynService.MedicineDelivery>(medicineDeliveries2));

            //================================Medicine Delivery Detail===============================
            List<SynService.MedicineDeliveryDetail> medicineDeliveryDetail = SynDBCore<SynService.MedicineDeliveryDetail>.GetAllToSend("Id");
            SynService.MedicineDeliveryDetail[] medicineDeliveryDetail2 =  synSrv.SendMedicineDeliveryDetail(medicineDeliveryDetail.ToArray(), ClientID);
            SynDBCore<SynService.MedicineDeliveryDetail>.SaveLog(new List<SynService.MedicineDeliveryDetail>(medicineDeliveryDetail2));

            //================================Medicine Delivery Detail Allocatel===============================
            List<SynService.MedicineDeliveryDetailAllocate> medicineDeliveryDetailAllocate = SynDBCore<SynService.MedicineDeliveryDetailAllocate>.GetAllToSend("Id");
            SynService.MedicineDeliveryDetailAllocate[] medicineDeliveryDetailAllocate2 = synSrv.SendMedicineDeliveryDetailAllocate(medicineDeliveryDetailAllocate.ToArray(), ClientID);
            SynDBCore<SynService.MedicineDeliveryDetailAllocate>.SaveLog(new List<SynService.MedicineDeliveryDetailAllocate>(medicineDeliveryDetailAllocate2));

            //================================MedicinePlan===============================
            List<SynService.MedicinePlan> medicinePlan = SynDBCore<SynService.MedicinePlan>.GetAllToSend("Id");
            SynService.MedicinePlan[] medicinePlan2 = synSrv.SendMedicinePlan(medicinePlan.ToArray(), ClientID);
            SynDBCore<SynService.MedicinePlan>.SaveLog(new List<SynService.MedicinePlan>(medicinePlan2));

            //================================MedicinePlan===============================
            List<SynService.MedicinePlanDetail> medicinePlanDetail = SynDBCore<SynService.MedicinePlanDetail>.GetAllToSend("Id");
            SynService.MedicinePlanDetail[] medicinePlanDetail2 = synSrv.SendMedicinePlanDetail(medicinePlanDetail.ToArray(), ClientID);
            SynDBCore<SynService.MedicinePlanDetail>.SaveLog(new List<SynService.MedicinePlanDetail>(medicinePlanDetail2));

            //================================MedicineUnitPrice===============================
            List<SynService.MedicineUnitPrice> medicineUnitPrice = SynDBCore<SynService.MedicineUnitPrice>.GetAllToSend("Id");
            SynService.MedicineUnitPrice[] medicineUnitPrice2 = synSrv.SendMedicineUnitPrice(medicineUnitPrice.ToArray(), ClientID);
            SynDBCore<SynService.MedicineUnitPrice>.SaveLog(new List<SynService.MedicineUnitPrice>(medicineUnitPrice2));

            //================================Patient===============================
            List<SynService.Patient> patient = SynDBCore<SynService.Patient>.GetAllToSend("Id");
            SynService.Patient[] patient2 = synSrv.SendPatient(patient.ToArray(), ClientID);
            SynDBCore<SynService.Patient>.SaveLog(new List<SynService.Patient>(patient2));

            //================================PatientFigure===============================
            List<SynService.PatientFigure> patientFigure = SynDBCore<SynService.PatientFigure>.GetAllToSend("Id");
            SynService.PatientFigure[] patientFigure2 = synSrv.SendPatientFigure(patientFigure.ToArray(), ClientID);
            SynDBCore<SynService.PatientFigure>.SaveLog(new List<SynService.PatientFigure>(patientFigure2));

            //================================Prescription===============================
            List<SynService.Prescription> prescription = SynDBCore<SynService.Prescription>.GetAllToSend("Id");
            SynService.Prescription[] prescription2 = synSrv.SendPrescription(prescription.ToArray(), ClientID);
            SynDBCore<SynService.Prescription>.SaveLog(new List<SynService.Prescription>(prescription2));

            //================================PrescriptionDetail===============================
            List<SynService.PrescriptionDetail> prescriptionDetail = SynDBCore<SynService.PrescriptionDetail>.GetAllToSend("Id");
            SynService.PrescriptionDetail[] prescriptionDetail2 = synSrv.SendPrescriptionDetail(prescriptionDetail.ToArray(), ClientID);
            SynDBCore<SynService.PrescriptionDetail>.SaveLog(new List<SynService.PrescriptionDetail>(prescriptionDetail2));

            //================================WareHouse===============================
            List<SynService.WareHouse> wareHouse = SynDBCore<SynService.WareHouse>.GetAllToSend("Id");
            SynService.WareHouse[] wareHouse2 = synSrv.SendWareHouse(wareHouse.ToArray(), ClientID);
            SynDBCore<SynService.WareHouse>.SaveLog(new List<SynService.WareHouse>(wareHouse2));

            //================================WareHouseDetail===============================
            List<SynService.WareHouseDetail> wareHouseDetail = SynDBCore<SynService.WareHouseDetail>.GetAllToSend("Id");
            SynService.WareHouseDetail[] wareHouseDetail2 = synSrv.SendWareHouseDetail(wareHouseDetail.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseDetail>.SaveLog(new List<SynService.WareHouseDetail>(wareHouseDetail2));

            //================================WareHouseExportAllocate===============================
            List<SynService.WareHouseExportAllocate> wareHouseExportAllocate = SynDBCore<SynService.WareHouseExportAllocate>.GetAllToSend("Id");
            SynService.WareHouseExportAllocate[] wareHouseExportAllocate2 = synSrv.SendWareHouseExportAllocate(wareHouseExportAllocate.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseExportAllocate>.SaveLog(new List<SynService.WareHouseExportAllocate>(wareHouseExportAllocate2));

            //================================WareHouseIO===============================
            List<SynService.WareHouseIO> wareHouseIO = SynDBCore<SynService.WareHouseIO>.GetAllToSend("Id");
            SynService.WareHouseIO[] wareHouseIO2 = synSrv.SendWareHouseIO(wareHouseIO.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseIO>.SaveLog(new List<SynService.WareHouseIO>(wareHouseIO2));

            //================================WareHouse IO Detail===============================
            List<SynService.WareHouseIODetail> wareHouseIODetail = SynDBCore<SynService.WareHouseIODetail>.GetAllToSend("Id");
            SynService.WareHouseIODetail[] wareHouseIODetail2 = synSrv.SendWareHouseIODetail(wareHouseIODetail.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseIODetail>.SaveLog(new List<SynService.WareHouseIODetail>(wareHouseIODetail2));

            //================================WareHouse Minimum Allow===============================
            List<SynService.WareHouseMinimumAllow> wareHouseMinimumAllow = SynDBCore<SynService.WareHouseMinimumAllow>.GetAllToSend("Id");
            SynService.WareHouseMinimumAllow[] wareHouseMinimumAllow2 = synSrv.SendWareHouseMinimumAllow(wareHouseMinimumAllow.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseMinimumAllow>.SaveLog(new List<SynService.WareHouseMinimumAllow>(wareHouseMinimumAllow2));

            if (SendingCompleted != null) SendingCompleted(figures, e);
        }
        #endregion
    }
}
