using Medical.Synchronization.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using Medical.Synchronization;

/// <summary>
/// Summary description for SynService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SynService : System.Web.Services.WebService
{

    public SynService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<Figure> SendFigure(List<Figure> figures, string ClientID)
    {
        try
        {
            return SynDBCore<Figure>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<FigureDetail> SendFigureDetail(List<FigureDetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<FigureDetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<MedicineDelivery> SendMedicineDelivery(List<MedicineDelivery> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineDelivery>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<MedicineDeliveryDetail> SendMedicineDeliveryDetail(List<MedicineDeliveryDetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineDeliveryDetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<MedicineDeliveryDetailAllocate> SendMedicineDeliveryDetailAllocate(List<MedicineDeliveryDetailAllocate> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineDeliveryDetailAllocate>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<MedicinePlan> SendMedicinePlan(List<MedicinePlan> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicinePlan>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<MedicinePlanDetail> SendMedicinePlanDetail(List<MedicinePlanDetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicinePlanDetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }


    [WebMethod]
    public List<MedicineUnitPrice> SendMedicineUnitPrice(List<MedicineUnitPrice> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineUnitPrice>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<Patient> SendPatient(List<Patient> patients, string ClientID)
    {
        try
        {
            return SynDBCore<Patient>.SendToSV(ClientID, patients);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<PatientFigure> SendPatientFigure(List<PatientFigure> patientfigures, string ClientID)
    {
        try
        {
            return SynDBCore<PatientFigure>.SendToSV(ClientID, patientfigures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<Prescription> SendPrescription(List<Prescription> prescriptions, string ClientID)
    {
        try
        {
            return SynDBCore<Prescription>.SendToSV(ClientID, prescriptions);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<PrescriptionDetail> SendPrescriptionDetail(List<PrescriptionDetail> prescriptiondetail, string ClientID)
    {
        try
        {
            return SynDBCore<PrescriptionDetail>.SendToSV(ClientID, prescriptiondetail);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<WareHouse> SendWareHouse(List<WareHouse> warehouse, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouse>.SendToSV(ClientID, warehouse);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<WareHouseDetail> SendWareHouseDetail(List<WareHouseDetail> warehousedetail, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseDetail>.SendToSV(ClientID, warehousedetail);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<WareHouseExportAllocate> SendWareHouseExportAllocate(List<WareHouseExportAllocate> warehouseexportallocate, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseExportAllocate>.SendToSV(ClientID, warehouseexportallocate);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<WareHouseIO> SendWareHouseIO(List<WareHouseIO> figures, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseIO>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<WareHouseIODetail> SendWareHouseIODetail(List<WareHouseIODetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseIODetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<WareHouseMinimumAllow> SendWareHouseMinimumAllow(List<WareHouseMinimumAllow> warehouseminimumallow, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseMinimumAllow>.SendToSV(ClientID, warehouseminimumallow);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<Medicine> SendMedicines(List<Medicine> medicines, string ClientID)
    {
        try
        {
            return SynDBCore<Medicine>.SendToSV(ClientID, medicines);
        }
        catch
        {
            return null;
        }
    }

    [WebMethod]
    public List<User> SendUser(List<User> users, string ClientID)
    {
        try
        {
            return SynDBCore<User>.SendToSV(ClientID, users);
        }
        catch
        {
            return null;
        }
    }
}
