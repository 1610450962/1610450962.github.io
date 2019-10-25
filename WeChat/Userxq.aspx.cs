using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Userxq : System.Web.UI.Page
{
    ChenlinDBCon db;
    DataTable dt = new DataTable();
    
    //显示用户信息
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new ChenlinDBCon();
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)

                Session["uid"] = Request.QueryString["id"];
            if (Session["uid"] == null)
                Response.Redirect("UserManage.aspx");
            else
            {
                dt = db.Query("select * from chenlinusers where userid='" + Session["uid"] + "'");
                lid.Text = Session["uid"].ToString();
                ImageButton1.ImageUrl = dt.Rows[0][7].ToString();
                lname.Text = dt.Rows[0][1].ToString();
                lsex.Text = dt.Rows[0][2].ToString();
                lcity.Text = dt.Rows[0][3].ToString();
                lgj.Text = dt.Rows[0][4].ToString();
                lcs.Text = dt.Rows[0][5].ToString();
                lyy.Text = dt.Rows[0][6].ToString();
                lgztime.Text = dt.Rows[0][8].ToString();
                lgzf.Text = dt.Rows[0][9].ToString();
                string stuid = dt.Rows[0][10].ToString();
                if (stuid == "" || stuid == null)
                {
                    Button3.Visible = false;
                }
                else
                {
                    tstuid.Text = stuid;
                    Button2.Visible = false;
                }
            }
            lmm.Text = "";
        }
    }
    //返回上一层
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location.href='UserManage.aspx';</script>");
    }
    //绑定学生信息
    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        dt = db.Query("SELECT * FROM stuinfo2017 where `学号`='"+tstuid.Text+"'");
        if (dt.Rows.Count > 0)
        {
            int n=db.ZSG("update chenlinusers set Remark='" + tstuid.Text + "' where userid='" + Session["uid"] + "'");
            if(n>0)
                Response.Write("<script>alert('绑定成功');location.href='Userxq.aspx';</script>");
            else
                Response.Write("<script>alert('绑定失败');location.href='Userxq.aspx';</script>");
        }
        else
            Response.Write("<script>alert('学号错误');location.href='Userxq.aspx';</script>");
    }
    //解绑
    protected void Button3_Click(object sender, EventArgs e)
    {
        int n = db.ZSG("update chenlinusers set Remark=null where userid='" + Session["uid"] + "'");
        if (n > 0)
            Response.Write("<script>alert('解绑成功');location.href='Userxq.aspx';</script>");
        else
            Response.Write("<script>alert('解绑失败');location.href='Userxq.aspx';</script>");
    }
}