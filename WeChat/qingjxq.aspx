<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="qingjxq.aspx.cs" Inherits="qingjxq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">请假操作
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">
    <p>

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="QjManage.aspx">请假管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="qingjxq.aspx">审核请假</asp:HyperLink>

    </p>
    <p>
        <asp:Label ID="lstuname" runat="server" Text="Label" Font-Size="18pt"></asp:Label>
    </p>
    <p>
        请假人学号：<asp:Label ID="lstuno" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        请假时间：<asp:Label ID="ldatetime" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        请假天数：<asp:Label ID="lday" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        请假理由：<asp:TextBox ID="tconly" runat="server" CssClass="form-control" 
            TextMode="MultiLine" Height="60px" Enabled="False"></asp:TextBox>
    </p>
    <p>
        审核状态：<asp:Label ID="lsh" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="批准审核" 
            CssClass="form-control btn-lg btn-success" Height="50px" 
            onclick="Button1_Click"/>
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" Text="拒绝审核" 
            CssClass="form-control btn-lg btn-primary" Height="50px" 
            onclick="Button3_Click" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="返回" 
            CssClass="form-control btn-lg btn-warning" Height="50px" 
            onclick="Button2_Click"/>
    </p>
</asp:Content>

