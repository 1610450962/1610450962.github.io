using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Ggmanage : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = db.Query("select * from chenlinnotice");
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (dt.Rows.Count > 0)
        {
            Label1.Visible = false;
        }
        else
        {
            Label1.Text = "暂时没有公告！";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}