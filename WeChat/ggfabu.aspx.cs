using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ggfabu : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //发布
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string aa = "insert into chenlinnotice(ntitle,content,ndate,viewNum) values('" + ttitle.Text + "','" + tcontent.Text + "','" + DateTime.Now + "','0')";
        //tcontent.Text = aa;
        int n = db.ZSG("insert into chenlinnotice(ntitle,content,ndate,viewNum) values('" + ttitle.Text + "','" + tcontent.Text + "','" + DateTime.Now + "','0')");
        if (n > 0)
            Response.Write("<script>alert('发布成功');location.href='Ggmanage.aspx';</script>");
        else
            Response.Write("<script>alert('发布失败！请重试');</script>");
    }
    //取消
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location.href='Ggmanage.aspx';</script>");
    }
}