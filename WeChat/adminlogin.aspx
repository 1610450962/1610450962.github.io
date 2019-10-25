<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="adminlogin" %>

<!DOCTYPE html>
<html lang="zh-CN">
  <head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <title>登录</title>

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
          <asp:Label ID="lyhname" runat="server" Text="未登录" Font-Size="9pt"></asp:Label>
          
        </div>
      <div id="mainContent">
          
              <asp:Panel ID="Panel1" runat="server">
              <table style="width:100%;">
        <tr>
            <td class="h3">
                管理员登录</td>
        </tr>
        <tr>
            <td>
                登录名：<br />
                <asp:TextBox ID="tname" runat="server" CssClass="form-control">admin</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                密码：<br />
                <asp:TextBox ID="tpass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="登录" CssClass="form-control btn-lg btn-success" Height="50px"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="重置" CssClass="form-control btn-lg btn-warning" Height="50px"/>
            </td>
        </tr>
    </table>
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
