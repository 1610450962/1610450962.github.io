using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Xml;
using System.Web.Script.Serialization;

public partial class Tools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //获取access_token
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label1.Text = GETaccess_token();
    }


    //方法，获取access_token
    public string GETaccess_token()
    {
        string GetaccessTokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx6c547c8e9a84e241&secret=ceb6b4a3932883cdea41fe9baf0f3fc7";
        //提交链接请求
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetaccessTokenUrl);
        request.Method = "GET";
        request.ContentType = "textml;charset=UTF-8";
        //处理得到的响应凭证
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        //将得到的jason数据包写入文件流
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        //解析数据包
        JavaScriptSerializer jss = new JavaScriptSerializer();
        Dictionary<string, object> dic = (Dictionary<string, object>)jss.DeserializeObject(retString);
        string str = dic["access_token"].ToString();
        return str;
    }
    //创建......
    public void CreateMenu(string posturl, string postData)
    {
        Stream outstream = null;
        Stream instream = null;
        StreamReader sr = null;
        HttpWebResponse response = null;
        HttpWebRequest request = null;
        Encoding encoding = Encoding.UTF8;
        byte[] data = encoding.GetBytes(postData);

        request = WebRequest.Create(posturl) as HttpWebRequest;
        CookieContainer cookieContainer = new CookieContainer();
        request.CookieContainer = cookieContainer;
        request.AllowAutoRedirect = true;
        request.Method = "POST";
        request.ContentType = "application/x-www/urlencoded";
        request.ContentLength = data.Length;
        outstream = request.GetRequestStream();
        outstream.Write(data, 0, data.Length);
        outstream.Close();
        response = request.GetResponse() as HttpWebResponse;
        instream = response.GetResponseStream();
        sr = new StreamReader(instream, encoding);
        string content = sr.ReadToEnd();
        Context.Response.Write(content);
    }
    //创建
    protected void Button1_Click(object sender, EventArgs e)
    {
        FileStream fs1 = new FileStream(Server.MapPath("/cl6-20-17/App_Code/") + "\\clMenu.txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs1, Encoding.GetEncoding("GBK"));
        string menu = sr.ReadToEnd();
        sr.Close();
        fs1.Close();
        CreateMenu("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + GETaccess_token(),menu);
    }
    //删除
    protected void Button2_Click(object sender, EventArgs e)
    {
        FileStream fs1 = new FileStream(Server.MapPath("/cl6-20-17/App_Code/") + "\\clMenu.txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs1, Encoding.GetEncoding("GBK"));
        string menu = sr.ReadToEnd();
        sr.Close();
        fs1.Close();
        CreateMenu("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + GETaccess_token(), menu);
    }
}