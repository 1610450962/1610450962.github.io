<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stuqingj.aspx.cs" Inherits="stuqingj" %>

<!DOCTYPE html>
<html lang="zh-CN">
  <head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- 上述3个meta标签*必须*放在最前面，任何其他内容都*必须*跟随其后！ -->
    <title>
        公告查询
    </title>

    <script src="http://www.jq22.com/jquery/jquery-1.10.2.js"></script>
    <script src="shijianx/js/shij.js" type="text/javascript"></script>
    <script src="shijianx/js/iscroll_date.js" type="text/javascript"></script>
    <script src="shijianx/js/date.js" type="text/javascript"></script>
    <link href="shijianx/css/date.css" rel="stylesheet" type="text/css" />

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
      <div id="header">2017级计算机成绩查询系统<br />
        </div>

      <div id="mainContent">
          <asp:Panel ID="Panel1" runat="server">

          请假日期：<br />
          <div id="datePlugin"></div>
           <input type="text" name="dateinput" id="dateinput" style="width:90%;height:50px;line-height:50px;display:block;margin:10px auto;font-size:16px;text-align:center;" onclick="return dateinput_onclick()" />
              请假天数：<br />
          <asp:TextBox ID="tday" runat="server" CssClass="form-control"></asp:TextBox>
          <br />
          请假理由：<br />
          <asp:TextBox ID="tconly" runat="server" CssClass="form-control" 
              TextMode="MultiLine" Height="60px"></asp:TextBox>
          <br />

          </asp:Panel>

          <asp:Panel ID="Panel2" runat="server">
              <asp:Label ID="Label1" runat="server" Font-Size="16pt" ForeColor="#99FF33" 
                  Text="Label"></asp:Label>
              <asp:Table ID="tmyqj" runat="server" Width="100%">
              </asp:Table>
          </asp:Panel>
          
          <asp:Button ID="Button1" runat="server" Text="我要请假" 
              CssClass="form-control btn-lg btn-success" Height="50px" 
              onclick="Button1_Click"/>
          <br />
          <asp:Button ID="Button4" runat="server" Text="我的请假" 
              CssClass="form-control btn-lg btn-group" Height="50px" 
              onclick="Button4_Click" Width="50%"/>
          <asp:Button ID="Button5" runat="server" Text="返回请假" 
              CssClass="form-control btn-lg btn-group" Height="50px" Width="49%" 
              onclick="Button5_Click" />
          <br />
          <br />
          <asp:Button ID="Button2" runat="server" Text="取消" 
              CssClass="form-control btn-lg btn-warning" Height="50px" 
              onclick="Button2_Click"/>

      </div>

      <div id="footer">重庆广播电视大学直属学院     17计算机2班 CL版权所有</div>
    </div>
        <link href="style/Chenlin.css" rel="stylesheet" type="text/css" />

    </form>
  </body>
</html>