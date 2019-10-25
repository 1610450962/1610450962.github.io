using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class stuqingj : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        dt1 = db.Query("select * from chenlinLeave where dtudyNum='" + Request.QueryString["stuno"] + "'");
        if (dt1.Rows.Count > 0)
        {
            Label1.Text = dt1.Rows[0][2].ToString();
        }
        else
        {
            Label1.Text = "当前没有请假！";
        }
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            TableRow tra = new TableRow();
            TableCell tca1 = new TableCell();
            tca1.Text = "请假时间：" + dt1.Rows[i][3].ToString();
            tca1.Font.Size = 12;//字体12
            TableCell tca2 = new TableCell();
            tca2.Text = "请假天数：" + dt1.Rows[i][4].ToString();
            tca2.Font.Size = 12;//字体12
            tra.Cells.Add(tca1);
            tra.Cells.Add(tca2);
            tmyqj.Rows.Add(tra);

            TableRow trb = new TableRow();
            TableCell tcb1 = new TableCell();
            tcb1.Text = "请假理由：" + dt1.Rows[i][5].ToString();
            tca1.ColumnSpan = 2;
            trb.Cells.Add(tcb1);
            tmyqj.Rows.Add(trb);

            TableRow trf = new TableRow();
            trf.Height = 10;
            tmyqj.Rows.Add(trf);

            TableRow trc = new TableRow();
            TableCell tcc1 = new TableCell();
            tcc1.Text = "审核状态：" + dt1.Rows[i][6].ToString();
            tcc1.ForeColor = System.Drawing.Color.Red;//需求红色
            tcc1.Font.Name = "幼圆";
            trc.Cells.Add(tcc1);
            tmyqj.Rows.Add(trc);

            TableRow tre = new TableRow();
            tre.Height = 30;
            tmyqj.Rows.Add(tre);
        }
    }
    //取消请假
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("<script>document.addEventListener('WeixinJSBridgeReady', function(){ WeixinJSBridge.call('closeWindow'); }, false)</script>");
    }

    //请假
    protected void Button1_Click(object sender, EventArgs e)
    {
        string dateinput = Request.Form.Get("dateinput").ToString();
        dt = db.Query("select * from stuinfo2017 where `学号`='" + Request.QueryString["stuno"] + "'");
        string name = dt.Rows[0][3].ToString();//学生姓名
        int n = db.ZSG("insert into chenlinleave(dtudyNum,stuName,ldate,days,reason,state) value('" + Request.QueryString["stuno"] + "','" + name + "','" + dateinput + "','" + tday.Text + "','" + tconly.Text + "','待审核')");
        if (n > 0)
            Response.Write("<script>alert('请假发布成功，等待审核！');document.addEventListener('WeixinJSBridgeReady', function(){ WeixinJSBridge.call('closeWindow'); }, false)</script>");
        else
            Response.Write("<script>alert('请假失败！请重试');</script>");
    }
    //我的请假
    protected void Button4_Click(object sender, EventArgs e)
    {
        Button1.Visible = false;
        Panel1.Visible = false;
        Panel2.Visible = true;
    }
    //返回请假
    protected void Button5_Click(object sender, EventArgs e)
    {
        Button1.Visible = true ;
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
}