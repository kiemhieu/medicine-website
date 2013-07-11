using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
       
    } 

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}