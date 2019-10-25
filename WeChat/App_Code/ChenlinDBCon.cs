using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// ClDBCon 的摘要说明
/// </summary>
public class ChenlinDBCon
{
    SqlConnection con;
	public ChenlinDBCon()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        con = new SqlConnection("Password=Cl200116.;Persist Security Info=True;User ID=chenlin;Initial Catalog=WeChat;Data Source=chenlincl.cn");
	}
    //打开数据库
    public void Open()
    {
        if (con.State != ConnectionState.Open)
            con.Open();
    }
    //关闭
    public void Close()
    {
        if (con.State == ConnectionState.Open)
            con.Close();
    }
    //增删改
    public int ZSG(string sql)
    {
        Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        int n = cmd.ExecuteNonQuery();
        Close();
        return n;
    }
    //查询
    public DataTable Query(string sql)
    {
        Open();
        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        Close();
        return dt;
    }
}