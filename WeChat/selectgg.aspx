<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="selectgg.aspx.cs" Inherits="selectgg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">公告详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">
    <p>
        标题：<asp:TextBox ID="ttitle" runat="server" CssClass="form-control" 
            Enabled="False"></asp:TextBox>
    </p>
    <p>
        内容：<asp:TextBox ID="tcontent" runat="server" CssClass="form-control" 
            TextMode="MultiLine" Height="100px" Enabled="False"></asp:TextBox>
    </p>
    <p>
        发布时间：<asp:Label ID="ldatetime" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        浏览次数：<asp:Label ID="lcs" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="取消" 
            CssClass="form-control btn-lg btn-success" Height="50px" 
            onclick="Button1_Click"/>
    </p>
</asp:Content>

