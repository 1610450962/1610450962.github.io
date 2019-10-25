using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class StuInManage : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    //加载显示学生信息
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = db.Query("select * from stuinfo2017 ORDER BY 学号");
        ljls.Text = "有"+dt.Rows.Count.ToString()+"条记录";
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //学号查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = db.Query("select * from stuinfo2017 where `" + RadioButtonList1.SelectedValue + "` like '%" + tstuidcx.Text + "%'");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}