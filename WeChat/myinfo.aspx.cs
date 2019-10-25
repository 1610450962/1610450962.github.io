using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class myinfo : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["id"] != "" || Request.QueryString["id"] != null)
            {
                Session["infoid"] = Request.QueryString["id"];
            }
            if (Request.QueryString["id"] != "" || Request.QueryString["id"] != null)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                dt = db.Query("select * from chenlinusers where userid='" + Session["infoid"] + "'");
                ImageButton1.ImageUrl = dt.Rows[0][7].ToString();
                lid.Text = dt.Rows[0][0].ToString();
                lname.Text = dt.Rows[0][1].ToString();
                lsex.Text = dt.Rows[0][2].ToString();
                lcity.Text = dt.Rows[0][3].ToString();
                lgj.Text = dt.Rows[0][4].ToString();
                lcs.Text = dt.Rows[0][5].ToString();
                lyy.Text = dt.Rows[0][6].ToString();
                lgztime.Text = dt.Rows[0][8].ToString();
                lgzf.Text = dt.Rows[0][9].ToString();
                lstuno.Text = dt.Rows[0][10].ToString();
            }
            else
            {
                if (Request.QueryString["stuno"] != "" || Request.QueryString["stuno"] != null)
                {
                    Session["infostuno"] = Request.QueryString["stuno"];
                }
                Panel1.Visible = false;
                Panel2.Visible = true;
                if (Session["infostuno"] == null)
                    Response.Write("<script>document.addEventListener('WeixinJSBridgeReady', function(){ WeixinJSBridge.call('closeWindow'); }, false)</script>");
                else
                {
                    if (!IsPostBack)
                    {
                        dt = db.Query("select * from stuinfo2017 where 学号='" + Session["infostuno"] + "'");
                        stuname.Text = dt.Rows[0][3].ToString();
                        tstuclass.Text = dt.Rows[0][1].ToString();
                        tstuno.Text = dt.Rows[0][2].ToString();
                        tstumz.Text = dt.Rows[0][4].ToString();
                        tstuid.Text = dt.Rows[0][5].ToString();
                        tstucs.Text = dt.Rows[0][6].ToString();
                        tstuphone.Text = dt.Rows[0][7].ToString();
                        tstuadres.Text = dt.Rows[0][8].ToString();
                        tstujjr.Text = dt.Rows[0][9].ToString();
                        tstujjidh.Text = dt.Rows[0][10].ToString();
                        tstuqq.Text = dt.Rows[0][11].ToString();
                        tstuyx.Text = dt.Rows[0][12].ToString();
                    }
                }
            }
        }
        catch (Exception)
        {
            if (Request.QueryString["stuno"] != "" || Request.QueryString["stuno"] != null)
            {
                Session["infostuno"] = Request.QueryString["stuno"];
            }
            Panel1.Visible = false;
            Panel2.Visible = true;
            if (Session["infostuno"] == null)
                Response.Write("<script>document.addEventListener('WeixinJSBridgeReady', function(){ WeixinJSBridge.call('closeWindow'); }, false)</script>");
            else
            {
                if (!IsPostBack)
                {
                    dt = db.Query("select * from stuinfo2017 where 学号='" + Session["infostuno"] + "'");
                    stuname.Text = dt.Rows[0][3].ToString();
                    tstuclass.Text = dt.Rows[0][1].ToString();
                    tstuno.Text = dt.Rows[0][2].ToString();
                    tstumz.Text = dt.Rows[0][4].ToString();
                    tstuid.Text = dt.Rows[0][5].ToString();
                    tstucs.Text = dt.Rows[0][6].ToString();
                    tstuphone.Text = dt.Rows[0][7].ToString();
                    tstuadres.Text = dt.Rows[0][8].ToString();
                    tstujjr.Text = dt.Rows[0][9].ToString();
                    tstujjidh.Text = dt.Rows[0][10].ToString();
                    tstuqq.Text = dt.Rows[0][11].ToString();
                    tstuyx.Text = dt.Rows[0][12].ToString();
                }
            }
        }
        
    }
    //修改个人信息
    protected void Button1_Click(object sender, EventArgs e)
    {
        int n = db.ZSG("update stuinfo2017 set 联系电话='" + tstuphone.Text + "',联系地址='" + tstuadres.Text + "',紧急联系人='" + tstujjr.Text + "',紧急联系人电话='" + tstujjidh.Text + "',QQ='" + tstuqq.Text + "',电子邮箱='" + tstuyx.Text + "' where 学号='" + Request.QueryString["stuno"] + "'");
        if (n > 0)
            Response.Write("<script>alert('修改成功');</script>");
        else
            Response.Write("<script>alert('修改失败');location.href='myinfo.aspx';</script>");
    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>document.addEventListener('WeixinJSBridgeReady', function(){ WeixinJSBridge.call('closeWindow'); }, false)</script>");
    }
}