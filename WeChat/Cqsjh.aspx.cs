using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Cqsjh : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //删除
            string state = db.Query("select KQStatus from chenlinkqinfo where KQID=" + Request.QueryString["sid"] + "").Rows[0][0].ToString();
            if (state == "考勤中")
            {
                Response.Write("<script>alert('考勤中不可删除！');location.href='Cqshuj.aspx';</script>");
            }
            else
            {
                int n = db.ZSG("delete from chenlinkqdetails where KQID=" + Request.QueryString["sid"] + "");
                if (n > 0)
                {
                    int m = db.ZSG("delete from chenlinkqinfo where KQID=" + Request.QueryString["sid"] + "");
                    if (m > 0)
                        Response.Write("<script>alert('删除成功');location.href='Cqshuj.aspx';</script>");
                    else
                        Response.Write("<script>alert('删除失败');location.href='Cqshuj.aspx';</script>");
                }
                else
                    Response.Write("<script>alert('删除失败,重试');location.href='Cqshuj.aspx';</script>");
            }
        }
        catch (Exception)
        {
            //查看课程学生状态
            if (Request.QueryString["id"] != null)
            {
                Session["Cqxqid"] = Request.QueryString["id"];
            }
            if (Session["Cqxqid"] != null)
            {
                if (!IsPostBack)
                {
                    dt = db.Query("select * from chenlinkqdetails where KQID=" + Session["Cqxqid"] + "");
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("<script>location.href='Cqshuj.aspx';</script>");
            }
        }
    }
}