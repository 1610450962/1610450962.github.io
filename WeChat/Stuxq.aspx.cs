using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Stuxq : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    //加载页面显示学生信息
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
                Session["stuid"] = Request.QueryString["id"];
            if (Session["stuid"] == null)
                Response.Redirect("StuInManage.aspx");
            else
            {
                dt = db.Query("select * from stuinfo2017 where 学号 = '" + Session["stuid"] + "'");
                lname.Text = dt.Rows[0][3].ToString();
                lstuid.Text = dt.Rows[0][2].ToString();
                lmz.Text = dt.Rows[0][4].ToString();
                lid.Text = dt.Rows[0][5].ToString();
                lcs.Text = dt.Rows[0][6].ToString();
                tdh.Text = dt.Rows[0][7].ToString();
                tdz.Text = dt.Rows[0][8].ToString();
                tjjxlr.Text = dt.Rows[0][9].ToString();
                tjjlxrdh.Text = dt.Rows[0][10].ToString();
                tqq.Text = dt.Rows[0][11].ToString();
                tyx.Text = dt.Rows[0][12].ToString();
                tclass.Text = dt.Rows[0][1].ToString();
            }
        }
    }
    //修改
    protected void Button1_Click(object sender, EventArgs e)
    {
        int n = db.ZSG("update stuinfo2017 set `班级`='" + tclass.Text + "',`联系电话`='" + tdh.Text + "',`联系地址`='" + tdz.Text + "',`紧急联系人`='" + tjjxlr.Text + "',`紧急联系人电话`='" + tjjlxrdh.Text + "',QQ='" + tqq.Text + "',`电子邮箱`='" + tyx.Text + "' where `学号` = '" + Session["stuid"] + "'");
        if (n > 0)
            Response.Write("<script>alert('修改成功');location.href='Stuxq.aspx';</script>");
        else
            Response.Write("<script>alert('修改失败');location.href='Stuxq.aspx';</script>");
    }
    //返回上一页
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("StuInManage.aspx");
    }
}