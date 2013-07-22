﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logined"]  != null && (bool)Session["Logined"] == true) Response.Redirect("Default.aspx");
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (LoginUser.UserName.ToUpper() == "ADMIN" && LoginUser.Password.ToUpper() == "ADMIN")
        {
            Session["Logined"] = true;
            Response.Redirect("Default.aspx");
        }
    }
}
