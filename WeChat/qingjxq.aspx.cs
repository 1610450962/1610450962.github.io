using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class qingjxq : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["state"] == "批准审核")
        {
            Button1.Visible = false;
        }
        else if (Request.QueryString["state"] == "拒绝审核")
        {
            Button3.Visible = false;
        }
        if (!IsPostBack)
        {
            dt = db.Query("select * from chenlinLeave where lid='" + Request.QueryString["id"] + "'");
            lstuno.Text = dt.Rows[0][1].ToString();
            lstuname.Text = dt.Rows[0][2].ToString();
            ldatetime.Text = dt.Rows[0][3].ToString();
            lday.Text = dt.Rows[0][4].ToString();
            tconly.Text = dt.Rows[0][5].ToString();
            lsh.Text = dt.Rows[0][6].ToString();
        }
    }
    //允许
    protected void Button1_Click(object sender, EventArgs e)
    {
        int n = db.ZSG("update chenlinLeave set state='批准审核' where lid='" + Request.QueryString["id"] + "'");
        if (n > 0)
        {
            Response.Write("<script>alert('审核成功');</script>");
        }
        else
        {
            Response.Write("<script>alert('审核失败');</script>");
        }
    }
    //反回上一也
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location.href='QjManage.aspx';</script>");
    }
    //拒绝审核
    protected void Button3_Click(object sender, EventArgs e)
    {
        int n = db.ZSG("update chenlinLeave set state='拒绝审核' where lid='" + Request.QueryString["id"] + "'");
        if (n > 0)
        {
            Response.Write("<script>alert('审核成功');</script>");
        }
        else
        {
            Response.Write("<script>alert('审核失败');</script>");
        }
    }
}