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
    public bool SendFigure(List<Figure> figures, string ClientID)
    {
        try
        {
            return SynDBCore<Figure>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<FigureDetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<FigureDetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<MedicineDelivery> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineDelivery>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<MedicineDeliveryDetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineDeliveryDetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<MedicineDeliveryDetailAllocate> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineDeliveryDetailAllocate>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<MedicinePlan> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicinePlan>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<MedicinePlanDetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicinePlanDetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }


    [WebMethod]
    public bool SendFigure(List<MedicineUnitPrice> figures, string ClientID)
    {
        try
        {
            return SynDBCore<MedicineUnitPrice>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<Patient> patients, string ClientID)
    {
        try
        {
            return SynDBCore<Patient>.SendToSV(ClientID, patients);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<PatientFigure> patientfigures, string ClientID)
    {
        try
        {
            return SynDBCore<PatientFigure>.SendToSV(ClientID, patientfigures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<Prescription> prescriptions, string ClientID)
    {
        try
        {
            return SynDBCore<Prescription>.SendToSV(ClientID, prescriptions);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<PrescriptionDetail> prescriptiondetail, string ClientID)
    {
        try
        {
            return SynDBCore<PrescriptionDetail>.SendToSV(ClientID, prescriptiondetail);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<WareHouse> warehouse, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouse>.SendToSV(ClientID, warehouse);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<WareHouseDetail> warehousedetail, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseDetail>.SendToSV(ClientID, warehousedetail);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<WareHouseExportAllocate> warehouseexportallocate, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseExportAllocate>.SendToSV(ClientID, warehouseexportallocate);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<WareHouseIO> figures, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseIO>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<WareHouseIODetail> figures, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseIODetail>.SendToSV(ClientID, figures);
        }
        catch
        {
            return false;
        }
    }

    [WebMethod]
    public bool SendFigure(List<WareHouseMinimumAllow> warehouseminimumallow, string ClientID)
    {
        try
        {
            return SynDBCore<WareHouseMinimumAllow>.SendToSV(ClientID, warehouseminimumallow);
        }
        catch
        {
            return false;
        }
    }
}
