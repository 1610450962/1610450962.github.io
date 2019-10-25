using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class bind : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"];
    }
    //绑定
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string sql = "select * from stuinfo2017 where 学号='" + stuno.Text + "' and 身份证号码='" + stuid.Text + "'";
        //stuno.Text = sql;
        dt = db.Query("select * from stuinfo2017 where 学号='" + stuno.Text + "' and 身份证号码='" + stuid.Text + "'");
        if (dt.Rows.Count > 0)
        {
            int n = db.ZSG("update chenlinusers set Remark='" + stuno.Text + "' where userid='" + id + "'");
            if (n > 0)
            {
                Response.Write("<script>alert('绑定成功');document.addEventListener('WeixinJSBridgeReady', function(){ WeixinJSBridge.call('closeWindow'); }, false)</script>");
            }
            else
            {
                Response.Write("<script>alert('绑定失败');</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('学号或身份证错误');</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        stuid.Text = "";
        stuno.Text = "";
    }
}