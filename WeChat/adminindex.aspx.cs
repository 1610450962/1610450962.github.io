using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminindex : System.Web.UI.Page
{
    //登录显示管理员id
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["yhid"] == "" || Session["yhid"]==null)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        else
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
    }
    //注销
    protected void Button7_Click(object sender, EventArgs e)
    {
        Session["yhid"] = "";
        Response.Write("<script>location.href='adminlogin.aspx';</script>");
    }
}