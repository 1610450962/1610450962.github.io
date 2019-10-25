using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class jbind : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id=Request.QueryString["id"];
        int n = db.ZSG("update chenlinusers set Remark='' where userid='" + id + "'");
        if (n > 0)
            Response.Write("<script>alert('解绑成功');document.addEventListener('WeixinJSBridgeReady', function(){ WeixinJSBridge.call('closeWindow'); }, false)</script>");
        else
            Response.Write("<script>alert('解绑失败');</script>");
    }
}