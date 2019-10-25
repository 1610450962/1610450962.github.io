using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class selectgg : System.Web.UI.Page
{
    ChenlinDBCon db=new ChenlinDBCon();
    DataTable dt = new DataTable();
    //查看详情
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = db.Query("select * from chenlinnotice where nid='" + Request.QueryString["id"] + "'");
        ttitle.Text = dt.Rows[0][1].ToString();
        tcontent.Text = dt.Rows[0][2].ToString();
        ldatetime.Text = dt.Rows[0][3].ToString();
        lcs.Text = dt.Rows[0][4].ToString();
    }
    //取消
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location.href='Ggmanage.aspx';</script>");
    }
}