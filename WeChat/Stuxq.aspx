<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="Stuxq.aspx.cs" Inherits="Stuxq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">学生详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StuInManage.aspx">学生管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Stuxq.aspx">学生详情</asp:HyperLink>
    <br />
    <asp:Label ID="lname" runat="server" Text="Label" Font-Size="24px" 
        ForeColor="Aqua"></asp:Label>
    <br />
    <br />
    学号：<asp:Label ID="lstuid" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    民族：<asp:Label ID="lmz" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    身份证号：<asp:Label ID="lid" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    出生日期：<asp:Label ID="lcs" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    联系电话：<asp:TextBox ID="tdh" runat="server" class="btn btn-default"></asp:TextBox>
    <br />
    <br />
    联系地址：<asp:TextBox ID="tdz" runat="server" class="btn btn-default"></asp:TextBox>
    <br />
    <br />
    紧急联系人：<asp:TextBox ID="tjjxlr" runat="server" class="btn btn-default"></asp:TextBox>
    <br />
    <br />
    紧急联系人电话：<asp:TextBox ID="tjjlxrdh" runat="server" class="btn btn-default"></asp:TextBox>
    <br />
    <br />
    QQ：<asp:TextBox ID="tqq" runat="server" class="btn btn-default"></asp:TextBox>
    <br />
    <br />
    电子邮箱：<asp:TextBox ID="tyx" runat="server" class="btn btn-default"></asp:TextBox>
    <br />
    <br />
    班级：<asp:TextBox ID="tclass" runat="server" class="btn btn-default"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="修改" 
        CssClass="form-control btn-lg btn-primary" Height="50px" 
        onclick="Button1_Click"/>
    <br />
    <asp:Button ID="Button2" runat="server" Text="返回" 
        CssClass="form-control btn-lg btn-success" Height="50px" 
        onclick="Button2_Click"/>

</asp:Content>

