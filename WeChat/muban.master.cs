using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class muban : System.Web.UI.MasterPage
{
    //登录显示当前用户
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yhid"] != null)
        {
            Panel1.Visible = true;
            LinkButton1.Visible = false;
            lyhname.Text = "当前用户:" + Session["yhid"].ToString();
        }
        else
        {
            Panel1.Visible = false;
            LinkButton1.Visible = true;
            lyhname.Text = "当前未登录！";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
}
