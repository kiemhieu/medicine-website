using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Usercontrol_uMenu : System.Web.UI.UserControl
{
    Hashtable htCheckMenu = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {

        InsertParentItem();
    }

    public void InsertChildItem(RadMenuItem chucNangCha)
    {
        //if (dtChucNang != null)
        //{
        //foreach (DataRow dr in dtChucNang.Rows)
        //{
        //    if (htCheckMenu.Contains(dr["ChucNangId"])) continue;
        //    else htCheckMenu.Add(dr["ChucNangId"], dr["ChucNangId"]);

        //    if (dr["ChucNangChaId"].ToString() == chucNangCha.Value)
        //    {
        //        RadMenuItem chucNangCon = new RadMenuItem();
        //        chucNangCon.Value = dr["ChucNangId"].ToString();
        //        chucNangCon.Text = dr["TenChucNang"].ToString();
        //        chucNangCon.NavigateUrl = dr["LienKet"].ToString();
        //        chucNangCha.Items.Add(chucNangCon);
        //        InsertChildItem(chucNangCon, dtChucNang);
        //    }
        //}

        RadMenuItem chucNangCon = new RadMenuItem();
        chucNangCon.Value = "1.1";
        chucNangCon.Text = "Danh mục 1";
        chucNangCon.NavigateUrl = "~/list.aspx?id=1";
        chucNangCha.Items.Add(chucNangCon);
        //}
        htCheckMenu.Clear();
        htCheckMenu = null;
    }

    public void InsertParentItem()
    {
        this.menuTop.Items.Clear();
        //ChucNang cn = new ChucNang();
        //DataSet ds = cn.GetChucNangByUser(Page.User.Identity.Name);
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        RadMenuItem chucNang = new RadMenuItem();
        chucNang.Value = "1";
        chucNang.Text = "Các danh mục";
        chucNang.NavigateUrl = "";
        this.menuTop.Items.Add(chucNang);
        InsertChildItem(chucNang);

        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{
        //    if (htCheckMenu.Contains(dr["ChucNangId"])) continue;
        //    else htCheckMenu.Add(dr["ChucNangId"], dr["ChucNangId"]);

        //    if (int.Parse(dr["ChucNangChaId"].ToString()) == -1)
        //    {
        //        RadMenuItem chucNang = new RadMenuItem();
        //        chucNang.Value = dr["ChucNangId"].ToString();
        //        chucNang.Text = dr["TenChucNang"].ToString();
        //        chucNang.NavigateUrl = dr["LienKet"].ToString();
        //        this.menuTop.Items.Add(chucNang);
        //        InsertChildItem(chucNang, ds.Tables[0]);
        //    }
        //}
        //}

        if (htCheckMenu != null)
        {
            htCheckMenu.Clear();
            htCheckMenu = null;
        }
    }
}
