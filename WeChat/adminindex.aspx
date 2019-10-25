<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="adminindex.aspx.cs" Inherits="adminindex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:Panel ID="Panel1" runat="server">
        <br />
    <asp:Button ID="Button1" runat="server" Text="用户管理" 
        CssClass="form-control btn-lg btn-danger" EnableTheming="True" PostBackUrl="UserManage.aspx" Height="50px"/>
    <br />
    <asp:Button ID="Button2" runat="server" Text="学生信息管理" 
        CssClass="form-control btn-lg btn-warning " PostBackUrl="StuInManage.aspx" Height="50px"/>
    <br />
    <asp:Button ID="Button3" runat="server" Text="成绩管理" 
        CssClass="form-control btn-lg btn-success" PostBackUrl="CjManage.aspx"  Height="50px"/>
    <br />
    <asp:Button ID="Button4" runat="server" Text="请假管理" 
        CssClass="form-control btn-lg btn-default" PostBackUrl="QjManage.aspx" Height="50px"/>
    <br />
    <asp:Button ID="Button5" runat="server" Text="公告管理" 
        CssClass="form-control btn-lg btn-primary" PostBackUrl="Ggmanage.aspx" Height="50px"/>
    <br />
    <asp:Button ID="Button6" runat="server" Text="出勤管理" 
        CssClass="form-control btn-lg btn-danger" PostBackUrl="Cqmanage.aspx" Height="50px"/>
    <br />
        <asp:Button ID="Button8" runat="server" CssClass="form-control btn-lg btn-success" Height="50px" PostBackUrl="../Binary/fileBinary.exe" Text="下载文件转二进制" />
     <br />
     <asp:Button ID="Button7" runat="server" Text="注销" 
        CssClass="form-control btn-lg btn-danger"
        Height="50px" onclick="Button7_Click"/>
        <br /> 
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
            你还没有登录请先<asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="Login.aspx">登录</asp:HyperLink>
        </asp:Panel>
    

</asp:Content>

