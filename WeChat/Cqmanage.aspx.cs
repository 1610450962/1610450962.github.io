using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Cqmanage : System.Web.UI.Page
{
    ChenlinDBCon db;
    DataTable dt;
    int KQid;
    //页面加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        //未登录返回登录页
        if (Session["yhid"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            db = new ChenlinDBCon();
            dt = new DataTable();
            DataTable dd = new DataTable();
            //查询当前登录教师是否有记录正在考勤中，有则显示考勤详情
            dd = db.Query("select * from chenlinkqinfo where  KQStatus='考勤中' and KQTeachar='" + Session["yhid"] + "'");
            if (dd.Rows.Count > 0)//有考勤
            {
                bind();
                Button1.Visible = false;
                Button2.Visible = true;
            }
            else
            {
                Button2.Visible = false;
                Label1.Visible = false;
            }
        }
    }
    //开始考勤

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (db.Query("select * from chenlinkqinfo where KQClassName='" + dclassname.Text + "' and KQStatus='考勤中'").Rows.Count > 0)
        {
            Response.Write("<script>alert('当前班级正在考勤中！无法开始考勤')</script>");
        }
        else
        {
            DateTime d = DateTime.Now;
            //迟到时间计算
            d = d.AddMinutes(Convert.ToDouble(dtime.Text));
            //插入一条新的考勤状态记录
            string sql = "insert into chenlinkqinfo(KQDate,KQTeachar,KQClassName,KQClassNum,KQClass,KQLateTime,KQStatus) values ('" + DateTime.Now + "','" + Session["yhid"] + "','" + dclassname.Text + "','" + dclassnum.Text + "','" + dclass.Text + "','" + d + "','考勤中')";
            int n = db.ZSG(sql);
            if (n > 0)
            {
                DataTable dt2 = new DataTable();
                dt2 = db.Query("select 学号,姓名 from stuinfo2017 where 班级='" + dclassname.Text + "'");
                //获取当前考勤记录号
                KQid = int.Parse(db.Query("select max(KQID) from chenlinkqinfo").Rows[0][0].ToString());
                //将目前考勤班级学生信息依次插入考勤详情表中
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    db.ZSG("insert into chenlinkqdetails(KQID,stuNum,stuName) values (" + KQid + ",'" + dt2.Rows[i][0].ToString() + "','" + dt2.Rows[i][1].ToString() + "')");
                }
                //显示当前考勤数据
                bind();
                Label1.Visible = true;
                Button1.Visible = false;
                Button2.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('开始考勤操作失败！请重试')</script>");
            }
        }

    }
    //刷新数据
    protected void Button3_Click1(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {
        KQid = int.Parse(db.Query("select max(KQID) from chenlinkqinfo ").Rows[0][0].ToString());
        DataTable d2 = new DataTable();
        d2 = db.Query("select * from chenlinkqinfo where KQID=" + KQid);
        int n1 = db.Query("select * from chenlinkqdetails where   KQID=" + KQid + " and Status is null").Rows.Count;
        int n2 = db.Query("select * from chenlinkqdetails where   KQID=" + KQid + " and Status='正常'").Rows.Count;
        int n3 = db.Query("select * from chenlinkqdetails where   KQID=" + KQid + " and Status='迟到'").Rows.Count;
        Label1.Text = d2.Rows[0][0].ToString() + "  :  " + d2.Rows[0][1].ToString() + "<br/>迟到：" + d2.Rows[0][6].ToString() + "<br/>班级:  " + d2.Rows[0][3].ToString() + "<br/>课程： " + d2.Rows[0][5].ToString() + "<br/>节数： " + d2.Rows[0][4].ToString() + "<br/>状态：" + d2.Rows[0][7].ToString() + "<br/>正常出勤：" + n2 + "<br/>迟到：" + n3 + "<br/>未签到:" + n1;
        dt = db.Query("select * from chenlinkqdetails where   KQID=" + KQid + " order by KQTime desc");


        GridView1.DataSource = dt;
        GridView1.DataBind();
        // Label2.Text = KQid.ToString();
    }
    //  结束考勤
    protected void Button2_Click(object sender, EventArgs e)
    {
        int n = db.ZSG("update chenlinkqinfo set KQStatus='考勤结束' where KQStatus='考勤中' and KQID=" + KQid);
        if (n > 0)
        {
            int n2 = db.ZSG("update chenlinkqdetails set Status='缺勤' where status is null and KQID=" + KQid);
            Response.Write("<script>alert('考勤已结束！')</script>");
            bind();
            Button1.Visible = true;
            Button2.Visible = false;
            Label1.Visible = true;
        }
        else
        {
            Response.Write("<script>alert('结束考勤操作失败！请重试'+"+KQid+")</script>");
        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location.href='Cqshuj.aspx';</script>");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Write("<script>location.href='Cqstusj.aspx';</script>");
    }























    //ChenlinDBCon db = new ChenlinDBCon();
    //int Kqid;
    //DataTable dt = new DataTable();
    //DataTable dt2 = new DataTable();
    //DataTable dt3 = new DataTable();
    //DataTable dt4 = new DataTable();

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    Response.Write("<script>alert("+Kqid+")</script>");
    //    if (Session["yhid"] == null)
    //    {
    //        Response.Redirect("adminlogin.aspx");
    //    }
    //    else
    //    {
    //        dt4 = db.Query("select * from chenlinkqinfo where KQStatus='考勤中' and KQTeachar='" + Kqid + "'");//查询该教师是否有正在考勤
    //        if (dt4.Rows.Count > 0)//该教师有考勤的时候
    //        {
    //            //Button1.Visible = false;//开始时考勤不可见
    //            bind();
    //        }
    //        else
    //        {
    //            //Button2.Visible = false;//结束考勤不可见
    //        }
    //    }
    //}
    ////开始考勤
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    DateTime d = DateTime.Now;
    //    d = d.AddMinutes(Convert.ToDouble(dtime.Text));//迟到的时间
    //    if (db.Query("select * from chenlinkqinfo where KQClassName='" + dclassname.Text + "' and KQStatus='考勤中'").Rows.Count > 0)
    //    {
    //        Response.Write("<script>alert('此班正在考勤中！无法开始考勤')</script>");
    //    }
    //    else
    //    {
    //        int n = db.ZSG("insert into chenlinkqinfo(KQDate,KQTeachar,KQClassName,KQClassNum,KQClass,KQlateTime,KQStatus) values('" + DateTime.Now + "','" + Session["yhid"] + "','" + dclassname.Text + "','" + dclassnum.Text + "','" + dclass.Text + "','" + d + "','考勤中')");
    //        if (n > 0)
    //        {
    //            dt = db.Query("select * from stuinfo2017 where 班级='" + dclassname.Text + "'");
    //            //Session["KQid"] = int.Parse(db.Query("select max(KQID) from chenlinkqinfo").Rows[0][0].ToString());//获取当前考勤ID
    //            Kqid = int.Parse(db.Query("select max(KQID) from chenlinkqinfo").Rows[0][0].ToString());//获取当前考勤ID
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                db.ZSG("insert into chenlinkqdetails(KQID,stuNum,stuName) values(" + Kqid + ",'" + dt.Rows[i][2] + "','" + dt.Rows[i][3] + "')");//循环添加这个班级的每个学生
    //            }
    //            Response.Write("<script>alert('开始考勤'+" + Kqid + ")</script>");
    //            bind();
    //        }
            
    //    }
    //}
    ////结束考勤
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    Response.Write("<script>alert(" + Kqid + "</script>");
    //    //int n = db.ZSG("update chenlinkqinfo set KQStatus='考勤结束' where KQID=" + Kqid);
    //    //if(n>0)
    //    //    Response.Write("<script>alert(" + Kqid + "+'结束成功')</script>");
    //    //else
    //    //    Response.Write("<script>alert(" + Kqid + "+'结束s')</script>");
    //}
    ////数据
    //public void bind()
    //{
    //    Kqid = int.Parse(db.Query("select max(KQID) from chenlinkqinfo").Rows[0][0].ToString());//获取当前考勤ID
    //    //string s = "select * from chenlinkqinfo where KQID='" + Kqid + "'";
    //    //Label1.Text = s;
    //    dt3 = db.Query("select * from chenlinkqinfo where KQID='" + Kqid + "'");
    //    Label1.Text = dt3.Rows[0][0].ToString();
    //    DataTable dt2 = new DataTable();
    //    dt2 = db.Query("select * from chenlinkqdetails where KQID='" + Kqid + "'");
    //    GridView1.DataSource = dt2;
    //    GridView1.DataBind();
    //}

}