<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="ggfabu.aspx.cs" Inherits="ggfabu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">发布公告
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">
    <p>

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Ggmanage.aspx">公告管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="ggfabu.aspx">发布公告</asp:HyperLink>

    </p>
    <p>
        标题：<asp:TextBox ID="ttitle" runat="server" CssClass="form-control"></asp:TextBox>
    </p>
    <p>
        内容：<asp:TextBox ID="tcontent" runat="server" CssClass="form-control" 
            TextMode="MultiLine" Height="100px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="发布" 
            CssClass="form-control btn-lg btn-success" Height="50px" 
            onclick="Button1_Click"/>
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="取消" 
            CssClass="form-control btn-lg btn-group" Height="50px" onclick="Button2_Click"/>
    </p>
</asp:Content>

