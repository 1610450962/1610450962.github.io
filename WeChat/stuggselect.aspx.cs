using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class stuggselect : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = db.Query("select * from chenlinnotice ORDER BY ndate DESC");
        if (dt.Rows.Count > 0)
        {
            Label1.Visible = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int a = int.Parse(dt.Rows[i][4].ToString());
                a = a+1;
                db.ZSG("update chenlinnotice set viewNum=" + a + " where nid=" + dt.Rows[i][0] + "");

                TableRow tra = new TableRow();
                TableCell tca1 = new TableCell();
                tca1.Text = "标题：" + dt.Rows[i][1].ToString();
                tca1.Font.Size = 18;//字体12
                tca1.ColumnSpan = 2;
                tra.Cells.Add(tca1);
                tggxq.Rows.Add(tra);

                TableRow trb = new TableRow();
                TableCell tcb1 = new TableCell();
                tcb1.Text = "内容：" + dt.Rows[i][2].ToString();
                tca1.ColumnSpan = 2;
                trb.Cells.Add(tcb1); 
                tggxq.Rows.Add(trb);

                TableRow trf = new TableRow();
                trf.Height = 10;
                tggxq.Rows.Add(trf);

                TableRow trc = new TableRow();
                TableCell tcc1 = new TableCell();
                tcc1.Text = "发布时间：" + dt.Rows[i][3].ToString();
                tcc1.ForeColor = System.Drawing.Color.Red;//需求红色
                tcc1.Font.Name = "幼圆";
                TableCell tcc2 = new TableCell();
                tcc2.Text = "点击次数：" + dt.Rows[i][4].ToString();
                tcc2.ForeColor = System.Drawing.Color.Red;//需求红色
                tcc2.Font.Name = "幼圆";
                trc.Cells.Add(tcc1);
                trc.Cells.Add(tcc2);
                tggxq.Rows.Add(trc);

                TableRow tre = new TableRow();
                tre.Height = 30;
                tggxq.Rows.Add(tre);
            }
        }
        else
        {
            Label1.Text = "暂时没有公告！！！";
        }
    }
}
