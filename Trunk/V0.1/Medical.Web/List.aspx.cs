using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        uctListBase.TableName = "Figure";

        List<SearchExpander> searchConditions = new List<SearchExpander>();
        searchConditions.Add(new SearchExpander("Name", "Tên gọi", typeof(string)));
        uctListBase.SearchConditions = searchConditions;


    }
}