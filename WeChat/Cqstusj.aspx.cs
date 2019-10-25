using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Cqstusj : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = db.Query("SELECT stuNum,stuName,sum(CASE Status WHEN '正常' THEN 1 ELSE 0 END) AS zhengchang,sum(CASE Status WHEN '缺勤' THEN 1 ELSE 0 END) AS queqin,sum(CASE Status WHEN '请假' THEN 1 ELSE 0 END) AS qingjia,sum(CASE Status WHEN '早退' THEN 1 ELSE 0 END) AS zaotui,sum(CASE Status WHEN '迟到' THEN 1 ELSE 0 END) AS chidao FROM chenlinkqdetails GROUP BY stuNum,stuName ORDER BY zhengchang DESC,stuNum");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //搜索
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string s = "SELECT stuNum,stuName,sum(CASE Status WHEN '正常' THEN 1 ELSE 0 END) AS zhengchang,sum(CASE Status WHEN '缺勤' THEN 1 ELSE 0 END) AS queqin,sum(CASE Status WHEN '请假' THEN 1 ELSE 0 END) AS qingjia,sum(CASE Status WHEN '早退' THEN 1 ELSE 0 END) AS zaotui,sum(CASE Status WHEN '迟到' THEN 1 ELSE 0 END) AS chidao FROM chenlinkqdetails where '" + RadioButtonList1.SelectedValue + "'like '%" + tss.Text + "%' GROUP BY stuNum ORDER BY zhengchang DESC,stuNum";
        //tss.Text = s;
        dt = db.Query("SELECT stuNum,stuName,sum(CASE Status WHEN '正常' THEN 1 ELSE 0 END) AS zhengchang,sum(CASE Status WHEN '缺勤' THEN 1 ELSE 0 END) AS queqin,sum(CASE Status WHEN '请假' THEN 1 ELSE 0 END) AS qingjia,sum(CASE Status WHEN '早退' THEN 1 ELSE 0 END) AS zaotui,sum(CASE Status WHEN '迟到' THEN 1 ELSE 0 END) AS chidao FROM chenlinkqdetails where " + RadioButtonList1.SelectedValue + " like '%" + tss.Text + "%' GROUP BY stuNum,stuName ORDER BY zhengchang DESC,stuNum");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //查询时间内的
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request.Form.Get("dateinput1") == "" && Request.Form.Get("dateinput2") == "")//两个时间为空，全部查询
        {
            dt = db.Query("SELECT stuNum,stuName,sum(CASE Status WHEN '正常' THEN 1 ELSE 0 END) AS zhengchang,sum(CASE Status WHEN '缺勤' THEN 1 ELSE 0 END) AS queqin,sum(CASE Status WHEN '请假' THEN 1 ELSE 0 END) AS qingjia,sum(CASE Status WHEN '早退' THEN 1 ELSE 0 END) AS zaotui,sum(CASE Status WHEN '迟到' THEN 1 ELSE 0 END) AS chidao FROM chenlinkqdetails GROUP BY stuNum,stuName ORDER BY zhengchang DESC,stuNum");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else if (Request.Form.Get("dateinput1") == "")//如果只有最后的时间，查询时间之前
        {
            DateTime time2 = Convert.ToDateTime(Request.Form.Get("dateinput2"));//最后时间
            time2 = time2.AddDays(1);//最后时间+1天
            dt = db.Query("SELECT stuNum,stuName,sum(CASE Status WHEN '正常' THEN 1 ELSE 0 END) AS zhengchang,sum(CASE Status WHEN '缺勤' THEN 1 ELSE 0 END) AS queqin,sum(CASE Status WHEN '请假' THEN 1 ELSE 0 END) AS qingjia,sum(CASE Status WHEN '早退' THEN 1 ELSE 0 END) AS zaotui,sum(CASE Status WHEN '迟到' THEN 1 ELSE 0 END) AS chidao FROM chenlinkqdetails WHERE KQID IN (SELECT KQID from chenlinkqinfo where KQDate<'" + time2 + "') GROUP BY stuNum ORDER BY zhengchang DESC,stuNum");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else if (Request.Form.Get("dateinput2") == "")//如果只有开始的时间，查询时间之前
        {
            DateTime time1 = Convert.ToDateTime(Request.Form.Get("dateinput1"));//最后时间
            dt = db.Query("SELECT stuNum,stuName,sum(CASE Status WHEN '正常' THEN 1 ELSE 0 END) AS zhengchang,sum(CASE Status WHEN '缺勤' THEN 1 ELSE 0 END) AS queqin,sum(CASE Status WHEN '请假' THEN 1 ELSE 0 END) AS qingjia,sum(CASE Status WHEN '早退' THEN 1 ELSE 0 END) AS zaotui,sum(CASE Status WHEN '迟到' THEN 1 ELSE 0 END) AS chidao FROM chenlinkqdetails WHERE KQID IN (SELECT KQID from chenlinkqinfo where KQDate>'" + time1 + "') GROUP BY stuNum ORDER BY zhengchang DESC,stuNum");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else//两个时间都有
        {
            DateTime time1 = Convert.ToDateTime(Request.Form.Get("dateinput1"));//开始时间
            DateTime time2 = Convert.ToDateTime(Request.Form.Get("dateinput2"));//最后时间
            time2 = time2.AddDays(1);//最后时间+1天
            if (time1 > time2 || time1 == time2)
            {
                Response.Write("<script>alert('开始时间不能大于或等于结束时间！');</script>");
            }
            else
            {
                dt = db.Query("SELECT stuNum,stuName,sum(CASE Status WHEN '正常' THEN 1 ELSE 0 END) AS zhengchang,sum(CASE Status WHEN '缺勤' THEN 1 ELSE 0 END) AS queqin,sum(CASE Status WHEN '请假' THEN 1 ELSE 0 END) AS qingjia,sum(CASE Status WHEN '早退' THEN 1 ELSE 0 END) AS zaotui,sum(CASE Status WHEN '迟到' THEN 1 ELSE 0 END) AS chidao FROM chenlinkqdetails WHERE KQID IN (SELECT KQID from chenlinkqinfo where KQDate>'" + time1 + "' and KQDate<'" + time2 + "') GROUP BY stuNum ORDER BY zhengchang DESC,stuNum");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}