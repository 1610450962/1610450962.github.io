<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shijian.aspx.cs" Inherits="shijian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="http://www.jq22.com/jquery/jquery-1.10.2.js"></script>
    <link href="shijianx/css/date.css" rel="stylesheet" />
    <script src="shijianx/js/date.js"></script>
    <script src="shijianx/js/iscroll_date.js"></script>
    <script src="shijianx/js/shij.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="datePlugin"></div>
           <input type="text" name="dateinput" id="dateinput" style="width:90%;height:50px;line-height:50px;display:block;margin:10px auto;font-size:16px;text-align:center;" onclick="return dateinput_onclick()" />
              
    </div>
    </form>
</body>
</html>
