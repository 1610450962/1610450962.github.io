using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class deletegg : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        int n = db.ZSG("delete from chenlinnotice where nid=" + Request.QueryString["id"] + "");
        if (n > 0)
            Response.Write("<script>alert('删除成功');location.href='Ggmanage.aspx';</script>");
        else
            Response.Write("<script>alert('删除失败！请重试');</script>");
    }
}