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
            synSrv.SendFigure(figures.ToArray(), ClientID);
            SynDBCore<SynService.Figure>.SaveLog(figures);

            //================================Figure Detail===============================
            List<SynService.FigureDetail> figuresDetail = SynDBCore<SynService.FigureDetail>.GetAllToSend("Id");
            synSrv.SendFigureDetail(figuresDetail.ToArray(), ClientID);
            SynDBCore<SynService.FigureDetail>.SaveLog(figuresDetail);

            //================================Figure Detail===============================
            List<SynService.MedicineDelivery> medicineDeliveries = SynDBCore<SynService.MedicineDelivery>.GetAllToSend("Id");
            synSrv.SendMedicineDelivery(medicineDeliveries.ToArray(), ClientID);
            SynDBCore<SynService.MedicineDelivery>.SaveLog(medicineDeliveries);

            //================================Medicine Delivery Detail===============================
            List<SynService.MedicineDeliveryDetail> medicineDeliveryDetail = SynDBCore<SynService.MedicineDeliveryDetail>.GetAllToSend("Id");
            synSrv.SendMedicineDeliveryDetail(medicineDeliveryDetail.ToArray(), ClientID);
            SynDBCore<SynService.MedicineDeliveryDetail>.SaveLog(medicineDeliveryDetail);

            //================================Medicine Delivery Detail Allocatel===============================
            List<SynService.MedicineDeliveryDetailAllocate> medicineDeliveryDetailAllocate = SynDBCore<SynService.MedicineDeliveryDetailAllocate>.GetAllToSend("Id");
            synSrv.SendMedicineDeliveryDetailAllocate(medicineDeliveryDetailAllocate.ToArray(), ClientID);
            SynDBCore<SynService.MedicineDeliveryDetailAllocate>.SaveLog(medicineDeliveryDetailAllocate);

            //================================MedicinePlan===============================
            List<SynService.MedicinePlan> medicinePlan = SynDBCore<SynService.MedicinePlan>.GetAllToSend("Id");
            synSrv.SendMedicinePlan(medicinePlan.ToArray(), ClientID);
            SynDBCore<SynService.MedicinePlan>.SaveLog(medicinePlan);

            //================================MedicinePlan===============================
            List<SynService.MedicinePlanDetail> medicinePlanDetail = SynDBCore<SynService.MedicinePlanDetail>.GetAllToSend("Id");
            synSrv.SendMedicinePlanDetail(medicinePlanDetail.ToArray(), ClientID);
            SynDBCore<SynService.MedicinePlanDetail>.SaveLog(medicinePlanDetail);

            //================================MedicineUnitPrice===============================
            List<SynService.MedicineUnitPrice> medicineUnitPrice = SynDBCore<SynService.MedicineUnitPrice>.GetAllToSend("Id");
            synSrv.SendMedicineUnitPrice(medicineUnitPrice.ToArray(), ClientID);
            SynDBCore<SynService.MedicineUnitPrice>.SaveLog(medicineUnitPrice);

            //================================Patient===============================
            List<SynService.Patient> patient = SynDBCore<SynService.Patient>.GetAllToSend("Id");
            synSrv.SendPatient(patient.ToArray(), ClientID);
            SynDBCore<SynService.Patient>.SaveLog(patient);

            //================================PatientFigure===============================
            List<SynService.PatientFigure> patientFigure = SynDBCore<SynService.PatientFigure>.GetAllToSend("Id");
            synSrv.SendPatientFigure(patientFigure.ToArray(), ClientID);
            SynDBCore<SynService.PatientFigure>.SaveLog(patientFigure);

            //================================Prescription===============================
            List<SynService.Prescription> prescription = SynDBCore<SynService.Prescription>.GetAllToSend("Id");
            synSrv.SendPrescription(prescription.ToArray(), ClientID);
            SynDBCore<SynService.Prescription>.SaveLog(prescription);

            //================================PrescriptionDetail===============================
            List<SynService.PrescriptionDetail> prescriptionDetail = SynDBCore<SynService.PrescriptionDetail>.GetAllToSend("Id");
            synSrv.SendPrescriptionDetail(prescriptionDetail.ToArray(), ClientID);
            SynDBCore<SynService.PrescriptionDetail>.SaveLog(prescriptionDetail);

            //================================WareHouse===============================
            List<SynService.WareHouse> WareHouse = SynDBCore<SynService.WareHouse>.GetAllToSend("Id");
            synSrv.SendMedicineDelivery(medicineDeliveries.ToArray(), ClientID);
            SynDBCore<SynService.WareHouse>.SaveLog(WareHouse);

            //================================WareHouseDetail===============================
            List<SynService.WareHouseDetail> wareHouseDetail = SynDBCore<SynService.WareHouseDetail>.GetAllToSend("Id");
            synSrv.SendWareHouseDetail(wareHouseDetail.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseDetail>.SaveLog(wareHouseDetail);

            //================================WareHouseExportAllocate===============================
            List<SynService.WareHouseExportAllocate> wareHouseExportAllocate = SynDBCore<SynService.WareHouseExportAllocate>.GetAllToSend("Id");
            synSrv.SendWareHouseExportAllocate(wareHouseExportAllocate.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseExportAllocate>.SaveLog(wareHouseExportAllocate);

            //================================WareHouseIO===============================
            List<SynService.WareHouseIO> wareHouseIO = SynDBCore<SynService.WareHouseIO>.GetAllToSend("Id");
            synSrv.SendWareHouseIO(wareHouseIO.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseIO>.SaveLog(wareHouseIO);

            //================================WareHouse IO Detail===============================
            List<SynService.WareHouseIODetail> wareHouseIODetail = SynDBCore<SynService.WareHouseIODetail>.GetAllToSend("Id");
            synSrv.SendWareHouseIODetail(wareHouseIODetail.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseIODetail>.SaveLog(wareHouseIODetail);

            //================================WareHouse Minimum Allow===============================
            List<SynService.WareHouseMinimumAllow> wareHouseMinimumAllow = SynDBCore<SynService.WareHouseMinimumAllow>.GetAllToSend("Id");
            synSrv.SendWareHouseMinimumAllow(wareHouseMinimumAllow.ToArray(), ClientID);
            SynDBCore<SynService.WareHouseMinimumAllow>.SaveLog(wareHouseMinimumAllow);

            if (SendingCompleted != null) SendingCompleted(figures, e);
        }
        #endregion
    }
}
