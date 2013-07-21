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
public class SynService : System.Web.Services.WebService {

    public SynService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool SendFigure(List<Figure> figures, string ClientID)
    {
        try
        {
            //SqlParameter[] param = new SqlParameter[6];
            //param[0] = new SqlParameter("@TenBaoCao", _TenBaoCao);
            //param[1] = new SqlParameter("@FileDinhKem", _FileDinhKem);
            //param[2] = new SqlParameter("@Username", _Username);
            //param[3] = new SqlParameter("@NgayGui", _NgayGui);
            //param[4] = new SqlParameter("@LyDo", _LyDo);
            //param[5] = new SqlParameter("@TrangThai", _TrangThai);
            // SqlHelper.ExecuteNonQuery(WebConfig.ConnectString, CommandType.StoredProcedure, "dbo.InsertBaoCao", param);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
}
