using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserManage : System.Web.UI.Page
{
    ChenlinDBCon db;
    //显示出用户信息
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new ChenlinDBCon();
        DataTable dt=new DataTable();
        dt = db.Query("select * from chenlinusers ORDER BY SubScribeTime desc");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}