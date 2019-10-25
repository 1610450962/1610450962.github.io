<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myinfo.aspx.cs" Inherits="myinfo" %>

<!DOCTYPE html>
<html lang="zh-CN">
  <head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <title>
        个人信息
    </title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- HTML5 shim 和 Respond.js 是为了让 IE8 支持 HTML5 元素和媒体查询（media queries）功能 -->
    <!-- 警告：通过 file:// 协议（就是直接将 html 页面拖拽到浏览器中）访问页面时 Respond.js 不起作用 -->
    <!--[if lt IE 9]>
      <script src="https://cdn.jsdelivr.net/npm/html5shiv@3.7.3/dist/html5shiv.min.js"></script>
      <script src="https://cdn.jsdelivr.net/npm/respond.js@1.4.2/dest/respond.min.js"></script>
    <![endif]-->
  </head>
  <body>

    <form id="form1" runat="server">
    
    <div id="quanju">
      <div id="header">2017计算机管理系统级<br />
          
        </div>
      <div id="mainContent">
          <asp:Panel ID="Panel1" runat="server">
          <p>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" ImageAlign="AbsBottom" Width="200px" />
        </p>
        <p>
            <asp:Label ID="lname" runat="server" Text="Label" Font-Size="24pt" 
                ForeColor="#00CCFF"></asp:Label>
        </p>
        <p>
            用户ID：<asp:Label ID="lid" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            性别：<asp:Label ID="lsex" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            city:<asp:Label ID="lcity" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            国际：<asp:Label ID="lgj" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            城市：<asp:Label ID="lcs" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            语言：<asp:Label ID="lyy" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            关注时间：<asp:Label ID="lgztime" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            关注方法：<asp:Label ID="lgzf" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            学号：<asp:Label ID="lstuno" 
                runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            描述：<asp:Label ID="lmm" runat="server" Text="Label"></asp:Label>
        </p>
          </asp:Panel>
          
          <asp:Panel ID="Panel2" runat="server">
              <asp:Label ID="stuname" runat="server" Font-Size="18pt" ForeColor="#CC9900" 
                  Text="Label"></asp:Label>
              <br />
              班级：<br /> 
              <asp:TextBox ID="tstuclass" runat="server"  CssClass="form-control"  Enabled="False" BorderColor="#33CCFF"></asp:TextBox>
              <br />
              学号：<br /> 
              <asp:TextBox ID="tstuno" runat="server"  CssClass="form-control" Enabled="False" BorderColor="#33CCFF"></asp:TextBox>
              <br />
              民族：<br /> 
              <asp:TextBox ID="tstumz" runat="server" CssClass="form-control" Enabled="False" BorderColor="#33CCFF"></asp:TextBox>
              <br />
              身份证：<br /> 
              <asp:TextBox ID="tstuid" runat="server" CssClass="form-control" Enabled="False" BorderColor="#33CCFF"></asp:TextBox>
              <br />
              出生日期：<br /> 
              <asp:TextBox ID="tstucs" runat="server" CssClass="form-control" Enabled="False" BorderColor="#33CCFF"></asp:TextBox>
              <br />
              联系电话：<br /> 
              <asp:TextBox ID="tstuphone" runat="server" CssClass="form-control"></asp:TextBox>
              <br />
              联系地址：<br /> 
              <asp:TextBox ID="tstuadres" runat="server" CssClass="form-control"></asp:TextBox>
              <br />
              紧急联系人：<br /> 
              <asp:TextBox ID="tstujjr" runat="server" CssClass="form-control"></asp:TextBox>
              <br />
              紧急联系人电话：<br /> 
              <asp:TextBox ID="tstujjidh" runat="server" CssClass="form-control"></asp:TextBox>
              <br />
              QQ：<br /> 
              <asp:TextBox ID="tstuqq" runat="server" CssClass="form-control"></asp:TextBox>
              <br />
              电子邮箱：<br /> 
              <asp:TextBox ID="tstuyx" runat="server" CssClass="form-control"></asp:TextBox>
              <br />
              <asp:Button ID="Button1" runat="server" Text="修改" 
                  CssClass="form-control btn-lg btn-success" Height="50px" 
                  onclick="Button1_Click"/>
              <br />
              <asp:Button ID="Button2" runat="server" Text="取消"  
                  CssClass="form-control btn-lg btn-warning" Height="50px" 
                  onclick="Button2_Click"/>
          </asp:Panel>
                        
      </div>
      <div id="footer">重庆广播电视大学直属学院<br />
          17计算机2班 CL版权所有</div>
    </div>
      <link href="style/Chenlin.css" rel="stylesheet" type="text/css" />
    <!-- jQuery (Bootstrap 的所有 JavaScript 插件都依赖 jQuery，所以必须放在前边) -->
  <script src="https://cdn.jsdelivr.net/npm/jquery@1.12.4/dist/jquery.min.js"></script>
    <!-- 加载 Bootstrap 的所有 JavaScript 插件。你也可以根据需要只加载单个插件。 -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/js/bootstrap.min.js"></script>

    </form>
  </body>
</html>
