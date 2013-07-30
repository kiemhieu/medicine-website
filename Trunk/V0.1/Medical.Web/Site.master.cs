using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Logined"] == null || (bool)Session["Logined"] != true) Response.Redirect("~/login.aspx");
        if(string.IsNullOrEmpty(Page.User.Identity.Name)) Response.Redirect("~/login.aspx");
    }
}
