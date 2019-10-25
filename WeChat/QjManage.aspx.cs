using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class QjManage : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = db.Query("select * from chenlinLeave where state='待审核' ORDER BY ldate");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //待审核
    protected void Button1_Click(object sender, EventArgs e)
    {
        dt = db.Query("select * from chenlinLeave where state='待审核' ORDER BY ldate");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //批准审核
    protected void Button2_Click(object sender, EventArgs e)
    {
        dt = db.Query("select * from chenlinLeave where state='批准审核' ORDER BY ldate");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //拒绝审核
    protected void Button3_Click(object sender, EventArgs e)
    {
        dt = db.Query("select * from chenlinLeave where state='拒绝审核' ORDER BY ldate");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}