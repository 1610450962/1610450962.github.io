using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CjManage : System.Web.UI.Page
{
    ChenlinDBCon db = new ChenlinDBCon();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = db.Query("SELECT 学号,姓名,sum(学分) as '已修学分',sum(成绩) as '总成绩' FROM score2017 where 成绩>59 group by 学号,姓名 ORDER BY sum(成绩) DESC  ");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //查询
    protected void Button1_Click(object sender, EventArgs e)
    {
        dt = db.Query("select 学号,姓名,sum(学分) as '已修学分',sum(成绩) as '总成绩' from score2017 where " + RadioButtonList1.SelectedValue + " like '%" + tstuidcx.Text + "%' and 成绩>59 group by 学号,姓名");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}