﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usercontrol_UserControlBase : System.Web.UI.UserControl
{
    public string TableName { get; set; }

    public List<SearchExpander> SearchConditions { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}