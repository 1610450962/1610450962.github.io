<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="Ggmanage.aspx.cs" Inherits="Ggmanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">公告管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Ggmanage.aspx">公告管理</asp:HyperLink>

    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" CssClass="table" AutoGenerateColumns="False" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ntitle" HeaderText="标题" />
            <asp:BoundField DataField="ndate" HeaderText="发布日期" />
            <asp:BoundField DataField="viewNum" HeaderText="浏览次数" />
            <asp:HyperLinkField DataNavigateUrlFields="nid" 
                DataNavigateUrlFormatString="selectgg.aspx?id={0}" HeaderText="查看" Text="查看" />
            <asp:HyperLinkField DataNavigateUrlFields="nid" 
                DataNavigateUrlFormatString="deletegg.aspx?id={0}" HeaderText="删除" Text="删除" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <br />

    <br />
    <asp:Button ID="Button1" runat="server" Text="发布公告" 
        CssClass="form-control btn-lg btn-success" Height="50px" 
        onclick="Button1_Click" PostBackUrl="ggfabu.aspx"/>

</asp:Content>

