using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cjxq : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = db.Query("select * from score2017 where 学号='" + Request.QueryString["stuno"] + "'");
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Label3.Text = dt.Rows[0][2].ToString();
        dt = db.Query("SELECT sum(学分) FROM score2017 where 学号='" + Request.QueryString["stuno"] + "' and 成绩>59");
        Label2.Text = dt.Rows[0][0].ToString();
    }
}