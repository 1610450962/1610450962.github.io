using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CQh : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            try
            {
                int n = db.ZSG("update chenlinkqdetails set Status='请假' where KQDid=" + Request.QueryString["qid"] + "");
                if (n > 0)
                    Response.Write("<script>alert('修改请假成功');location.href='Cqsjh.aspx';</script>");
                else
                    Response.Write("<script>alert('修改请假失败');location.href='Cqsjh.aspx';</script>");
            }
            catch (Exception)
            {

                int n = db.ZSG("update chenlinkqdetails set Status='早退' where KQDid=" + Request.QueryString["zid"] + "");
                if (n > 0)
                    Response.Write("<script>alert('修改早退成功');location.href='Cqsjh.aspx';</script>");
                else
                    Response.Write("<script>alert('修改早退失败');location.href='Cqsjh.aspx';</script>");
            }
        }
        catch (Exception)
        {
            
            int n = db.ZSG("update chenlinkqdetails set Status='迟到',KQtime='"+DateTime.Now+"' where KQDid=" + Request.QueryString["cid"] + "");
                if (n > 0)
                    Response.Write("<script>alert('修改迟到成功');location.href='Cqsjh.aspx';</script>");
                else
                    Response.Write("<script>alert('修改迟到失败');location.href='Cqsjh.aspx';</script>");
        }
    }
}