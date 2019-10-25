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

public partial class index : System.Web.UI.Page
{
    private string Token = "chenlin";
    ChenlinXML xml;
    ChenlinDBCon db;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
       //Auth();//接入
        db = new ChenlinDBCon();
        dt = new DataTable();
        if (Request.HttpMethod == "POST")
        {
            //获取xml信息
            string weixin = "";
            Stream s = Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            weixin = Encoding.UTF8.GetString(b);
            if (weixin != null && weixin != "")
                ResponseMsg(weixin);//调用
        }
    }
    //相应微信请求
    private void ResponseMsg(string weixin)
    {
        XmlDocument doc = new XmlDocument();//创建XML对象
        doc.LoadXml(weixin);//读取XML字符串
        XmlElement root = doc.DocumentElement;//获取根元素
        xml = new ChenlinXML()
        {
            FromUserName = root.GetElementsByTagName("FromUserName")[0].InnerText,
            ToUserName = root.GetElementsByTagName("ToUserName")[0].InnerText,
            CreateTime = root.GetElementsByTagName("CreateTime")[0].InnerText,
            MsgType = root.GetElementsByTagName("MsgType")[0].InnerText,//消息类型
        };

        if (xml.MsgType == "text")//接受类型文本
        {
            xml.Content = root.GetElementsByTagName("Content")[0].InnerText;
        }
        else if (xml.MsgType.Trim().ToLower() == "event")//事件
        {
            xml.Event = root.GetElementsByTagName("Event")[0].InnerText;//获取事件类型
        }

        string messageType = xml.MsgType;//获取接收消息类型。
        
        //返回回去的消息类容变量;
        try
        {
            switch (messageType)
            {
                //接收text文本时
                case "text":
                    insertxx("文本", xml.Content);
                    if (xml.Content == "1")
                    {
                        text("联系方式不给！！！！！！！！！");
                    }
                    else if(xml.Content == "2")
                    {
                        text("你是真的2！！！！！");
                    }
                    else if(xml.Content == "辅导员电话")
                    {
                        text("110");
                    }
                    else if(xml.Content == "音乐")
                    {
                        music();//调用音乐
                    }
                    else if(xml.Content == "图文")
                    {
                        string title = "5555555";
                        string miaos = "666666";
                        string tuUrl = "http://aspwangxiaona.get.vip/S2017/cl.png";
                        string goUrl = "https://www.baidu.com/";
                        tuwen(title,miaos,tuUrl,goUrl);//调用图文
                    }
                    else if (xml.Content == "管理员登录" || xml.Content == "管理员")
                    {
                        string title = "管理员";
                        string miaos = "点击登录";
                        string tuUrl = "data:image/png;base64,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";
                        string goUrl = "http://chenlincl.cn/WeChat/adminlogin.aspx";
                        tuwen(title, miaos, tuUrl, goUrl);//调用图文
                    }
                    else
                    {
                        text("人话？？？？");
                    }
                    
                    break;
                //接收其他时
                case "event":
                    string jevent=xml.Event;//获取接受世间类型
                    switch(jevent)
                    {
                        case "subscribe"://当事件类型关注时
                            insertyh(xml.FromUserName);
                            break;
                        case "unsubscribe"://取关，没必要
                            text("取关？？？？？");
                            break;
                        case "CLICK"://取关，没必要
                            xml.EventKey = root.GetElementsByTagName("EventKey")[0].InnerText;
                            string eventkey = xml.EventKey;
                            dt = db.Query("select * from chenlinusers where userid='" + xml.FromUserName + "' and (Remark!='' or Remark!=null)");
                            switch (eventkey)
                            {
                                case "BIND":
                                    insertxx("点击菜单", "绑定用户");
                                    if(dt.Rows.Count>0)
                                        text(dt.Rows[0][10] + "你已绑定！<a href=\"http://chenlincl.cn/WeChat/jbind.aspx?id=" + xml.FromUserName + "\">点击解除绑定</a>");
                                    else
                                        text("<a href=\"http://chenlincl.cn/WeChat/bind.aspx?id=" + xml.FromUserName + "\">点击绑定！</a>");
                                    break;
                                case "QUERYSCORE":
                                    insertxx("点击菜单", "查询成绩");
                                    if (dt.Rows.Count > 0)
                                        text("学号为：" + dt.Rows[0][10] + "的同学！<a href=\"http://chenlincl.cn/WeChat/results.aspx?id=" + dt.Rows[0][10] + "\">点击查询成绩</a>");
                                    else
                                        text("你未绑定，<a href=\"http://chenlincl.cn/WeChat/bind.aspx?id=" + xml.FromUserName + "\">点击绑定！</a>");
                                    break;
                                case "PERSONAL":
                                    insertxx("点击菜单", "个人信息");
                                    if (dt.Rows.Count > 0)
                                        text("学号为：" + dt.Rows[0][10] + "的同学！<a href=\"http://chenlincl.cn/WeChat/myinfo.aspx?id=" + dt.Rows[0][0] + "\">点击查看微信个人信息</a>，<a href=\"http://chenlincl.cn/WeChat/myinfo.aspx?stuno=" + dt.Rows[0][10] + "\">点击查看学生个人信息</a>");
                                    else
                                        text("你未绑定，<a href=\"http://chenlincl.cn/WeChat/bind.aspx?id=" + xml.FromUserName + "\">点击绑定！</a>");
                                    break;
                                case "NOTICE":
                                    insertxx("点击菜单", "查看公告");
                                    //if (dt.Rows.Count > 0)
                                        text("<a href=\"http://chenlincl.cn/WeChat/stuggselect.aspx\">点击查看公告</a>");
                                    //else
                                    //    text("你未绑定，<a href=\"http://chenlincl.cn/WeChat/bind.aspx?id=" + xml.FromUserName + "\">点击绑定！</a>");
                                    break;
                                case "ASKFORLEAVE":
                                    insertxx("点击菜单", "请假");
                                    if (dt.Rows.Count > 0)
                                        text("学号为：" + dt.Rows[0][10] + "的同学！<a href=\"http://chenlincl.cn/WeChat/stuqingj.aspx?stuno=" + dt.Rows[0][10] + "\">前往请假</a>");
                                    else
                                        text("你未绑定，<a href=\"http://chenlincl.cn/WeChat/bind.aspx?id=" + xml.FromUserName + "\">点击绑定！</a>");
                                    break;
                                case "ATTEND":
                                    insertxx("点击菜单", "签到");
                                    if (dt.Rows.Count > 0)
                                    {
                                        try
                                        {
                                            DataTable dt1 = new DataTable();
                                            string stuclass = db.Query("select 班级 from stuinfo2017 where 学号='" + dt.Rows[0][10] + "'").Rows[0][0].ToString();
                                            dt1 = db.Query("select * from chenlinkqinfo where KQClassName='" + stuclass + "' and KQStatus='考勤中'");
                                            if (dt1.Rows.Count > 0)
                                            {
                                                DateTime tim = Convert.ToDateTime(dt1.Rows[0][6].ToString());
                                                if (tim > DateTime.Now)
                                                {
                                                    db.ZSG("update chenlinkqdetails set status='正常',KQtime='" + DateTime.Now + "' where stuNum='" + dt.Rows[0][10].ToString() + "' and status is null and KQID=" + dt1.Rows[0][0]);
                                                    text("考勤成功  状态：正常考勤");
                                                }
                                                else
                                                {
                                                    db.ZSG("update chenlinkqdetails set status='迟到',KQtime='" + DateTime.Now + "' where stuNum='" + dt.Rows[0][10].ToString() + "' and status is null and KQID=" + dt1.Rows[0][0]);
                                                    text("考勤成功  状态：迟到考勤");
                                                }
                                            }
                                            else
                                            {
                                                text("当前："+stuclass+"  不可考勤");
                                            }

                                        }
                                        catch (Exception ex)
                                        {

                                            text("签到失败！ " + ex.Message);
                                        }
                                    }
                                    else
                                        text("你未绑定，<a href=\"http://chenlincl.cn/WeChat/bind.aspx?id=" + xml.FromUserName + "\">点击绑定！</a>");
                                    break;
                            }
                            break;
                    }
                    break;
                case "image":
                    insertxx("图片",root.GetElementsByTagName("PicUrl")[0].InnerText);
                    text("图片");
                    break;
                case "voice":
                    insertxx("语音", root.GetElementsByTagName("Recognition")[0].InnerText);
                    text("语音识别："+root.GetElementsByTagName("Recognition")[0].InnerText);
                    break;
                case "video":
                    insertxx("视频", root.GetElementsByTagName("MediaId")[0].InnerText);
                    text("视频");
                    break;
                case "shortvideo":
                    insertxx("小视频", root.GetElementsByTagName("MediaId")[0].InnerText);
                    text("小视频");
                    break;
                case "location":
                    insertxx("位置", root.GetElementsByTagName("Label")[0].InnerText);
                    text("你的位置:"+root.GetElementsByTagName("Label")[0].InnerText);
                    break;
                case "link":
                    insertxx("链接", root.GetElementsByTagName("Url")[0].InnerText);
                    text("链接");
                    break;
                default:
                    insertxx("其他","不懂！！！！");
                    text(root.GetElementsByTagName("MsgType")[0].InnerText);
                    break;
            }
        }
        catch (Exception)
        {
            text("你不行！！！！！！！");
        }
    }
    //添加信息到消息表
    private void insertxx(string msgtype,string content)
    {
        try
        {
            db.ZSG("insert into ChenlinMessage(userid,MsgType,MsgContent,MsgTime) values('" + xml.FromUserName + "','" + msgtype + "','" + content + "','" + DateTime.Now + "')");
        }
        catch (Exception)
        {

            Response.Write("错误");
        }
    }
    //关注后添加用户信息
    private void insertyh(string openid)
    {
     
        string GetyhUrl = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + GETaccess_token() + "&openid="+openid+"&lang=zh_CN";
        //提交链接请求
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetyhUrl);
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
        string nickname = dic["nickname"].ToString();
        string sex = dic["sex"].ToString();
        string city = dic["city"].ToString();
        string country = dic["country"].ToString();
        string province = dic["province"].ToString();
        string language = dic["language"].ToString();
        string headimgurl = dic["headimgurl"].ToString();
        string remark = dic["remark"].ToString();
        string subscribe_scene = dic["subscribe_scene"].ToString();
        string xb;
        if (sex == "1")
            xb = "男";
        else if (sex == "2")
            xb = "女";
        else
            xb = "人妖";
        string fr;
        if (subscribe_scene == "ADD_SCENE_SEARCH")
            fr = "公众号搜索";
        else if (subscribe_scene == "ADD_SCENE_ACCOUNT_MIGRATION")
            fr = "公众号迁移";
        else if (subscribe_scene == "ADD_SCENE_PROFILE_CARD")
            fr = "名片分享";
        else if (subscribe_scene == "ADD_SCENE_QR_CODE")
            fr = "扫描二维码";
        else if (subscribe_scene == "ADD_SCENEPROFILE LINK")
            fr = "图文页内名称点击";
        else if (subscribe_scene == "ADD_SCENE_PROFILE_ITEM ")
            fr = "图文页右上角菜单";
        else if (subscribe_scene == "ADD_SCENE_PAID")
            fr = " 支付后关注";
        else
            fr = "其他";

        try
        {
            DataTable dt = new DataTable();
            dt=db.Query("select * from chenlinusers where userid='" + openid + "'");
            if (dt.Rows.Count > 0)
            {
                db.ZSG("update chenlinusers set userNickName='" + nickname + "',sex='" + xb + "',city='" + city + "',country='" + country + "',Province='" + province + "',Language='" + language + "',Headimg='" + headimgurl + "',SubScribeTime='" + DateTime.Now + "',subscribe_scene='" + fr + "',Remark='" + remark + "' where userid='" + openid + "'");
                text("欢迎回家！！！");
            }
            else
            {
                int n=db.ZSG("INSERT INTO chenlinusers(userid,userNickName,sex,city,country,Province,Language,Headimg,SubScribeTime,subscribe_scene,Remark) VALUES('" + openid + "','" + nickname + "','" + xb + "','" + city + "','" + country + "','" + province + "','" + language + "','" + headimgurl + "','" + DateTime.Now + "','" + fr + "','" + remark + "')");
                if(n<1)
                    text("谢谢你的关注，我会绞尽脑汁发送有用的东西，共同进步！\n回复1，获取我的联系方式\n回复2了解我们\n回复图文，看图文介绍\n回复音乐，听歌");
                else
                    text("出错了");
            }
        }
        catch (Exception ex)
        {
            
            Response.Write(ex);
        }
    }
    //回复图文
    private void tuwen(string title,string miaos,string tuUrl,string goUrl)
    {
        string resxml = "<xml><ToUserName><![CDATA["+xml.FromUserName+"]]></ToUserName>";
        resxml += "<FromUserName><![CDATA["+xml.ToUserName+"]]></FromUserName>";
        resxml += "<CreateTime> "+ConvertDateTimeInt(DateTime.Now)+" </CreateTime>";
        resxml += "<MsgType><![CDATA[news]]></MsgType>";
        resxml += "<ArticleCount>1</ArticleCount>";
        resxml += "<Articles >";
        resxml += "<item>";
        resxml += "<Title><![CDATA["+title+"]]></Title>";
        resxml += "<Description><![CDATA["+miaos+"]]></Description>";
        resxml += "<PicUrl><![CDATA["+tuUrl+"]]></PicUrl>";
        resxml += "<Url><![CDATA["+goUrl+"]]></Url>";
        resxml += "</item>";
        resxml += "</Articles>";
        //resxml += "<Articles >";
        //resxml += "<item>";
        //resxml += "<Title><![CDATA[11111111]]></Title>";
        //resxml += "<Description><![CDATA[222222222]]></Description>";
        //resxml += "<PicUrl><![CDATA[]]></PicUrl>";
        //resxml += "<Url><![CDATA[https://www.baidu.com/]]></Url>";
        //resxml += "</item>";
        //resxml += "</Articles>";//开发者只能回复一条图文
        resxml += "</xml>";
        Response.Write(resxml);
        Response.End();
    }
    //回复文本
    private void text(string msg)
    {
        string resxml = "<xml><ToUserName><![CDATA[" + xml.FromUserName + "]]></ToUserName>";
        resxml = resxml + "<FromUserName><![CDATA[" + xml.ToUserName + "]]></FromUserName>";
        resxml = resxml + "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
        resxml += "<MsgType><![CDATA[text]]></MsgType>";
        resxml = resxml + "<Content><![CDATA[" + msg + "]]></Content></xml>";
        Response.Write(resxml);
        Response.End();
    }
    //回复音乐
    private void music()
    {
        string resxml ="<xml><ToUserName><![CDATA["+xml.FromUserName+"]]></ToUserName>";
        resxml = resxml + "<FromUserName><![CDATA["+xml.ToUserName+"]]></FromUserName>";
        resxml = resxml + "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
        resxml = resxml + "<MsgType><![CDATA[music]]></MsgType>";
        resxml = resxml + "<Music>";
        resxml = resxml + "<Title><![CDATA[歌曲]]></Title>";
        resxml = resxml + "<Description><![CDATA[外国音乐]]></Description>";
        resxml = resxml + "<MusicUrl><![CDATA[http://aspwangxiaona.get.vip/S2017/h.mp3]]></MusicUrl>";
        resxml = resxml + "<HQMusicUrl><![CDATA[http://aspwangxiaona.get.vip/S2017/h.mp3]]></HQMusicUrl>";
        //resxml = resxml + "<ThumbMediaId><![CDATA[media_id]]></ThumbMediaId>";
        resxml = resxml + "</Music></xml>";
        Response.Write(resxml);
        Response.End();

    }


    //时间转换为int
    private int ConvertDateTimeInt(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (int)(time - startTime).TotalSeconds;
    }




    //微信接口验证，加载调用
    private void Auth()
    {
        string signature = Request["signature"];
        string timestamp = Request["timestamp"];
        string nonce = Request["nonce"];
        string echostr = Request["echostr"];
        if (Request.HttpMethod == "GET")
        {
            if (Check(signature, timestamp, nonce, Token))
                Response.Output.Write(echostr);
            else
                Response.Output.Write("failed:" + signature + "," + GetSignature(timestamp, nonce, Token) + "。" + "如果你在浏览器看到这句话，说明此地址可以被作为微信公众号账号后台的URL，请注意保持Token一致。");
            Response.End();
        }
    }
    //判断是否接入成功
    public static bool Check(string signature, string timestamp, string nonce, string Token)
    {
        return signature == GetSignature(timestamp, nonce, Token);
    }
    //接入判断，排序及加密
    public static string GetSignature(string timestamp, string nonce, string token)
    {
        //token = token ?? Token;
        string[] arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
        string arrString = string.Join("", arr);
        System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
        byte[] sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
        StringBuilder enText = new StringBuilder();
        foreach (var b in sha1Arr)
        {
            enText.AppendFormat("{0:x2}", b);
        }
        return enText.ToString();
    }
    //获取access_token方法
    public string GETaccess_token()
    {
        string GetaccessTokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxa37d40e6dd51e98d&secret=de2ee2933b0b89605fe5dd0b9108b903";
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
}