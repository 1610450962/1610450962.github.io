using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class adminlogin : System.Web.UI.Page
{
    ChenlinDBCon db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new ChenlinDBCon();
        Session.RemoveAll();
        Session.Clear();
    }
    //清空
    protected void Button2_Click(object sender, EventArgs e)
    {
        tname.Text = "";
        tpass.Text = "";
    }
    //登录
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = db.Query("select * from chenlinadmin where adminID='" + tname.Text + "' and adminpass='" + tpass.Text + "'");
        if (dt.Rows.Count > 0)
        {
            Session["yhid"] = tname.Text;
            Response.Write("<script>location.href='adminindex.aspx';</script>");
        }
        else
            Response.Write("<script>alert('登录失败，重试！！！！！！');location.href='http://aspwangxiaona.get.vip/S2017/2-174761622-cl/adminlogin.aspx';</script>");
    }
}