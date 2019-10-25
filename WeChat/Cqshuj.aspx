<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="Cqshuj.aspx.cs" Inherits="Cqshuj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">出勤数据管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Cqmanage.aspx">出勤管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Cqshuj.aspx">出勤数据管理</asp:HyperLink>

    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="KQID" HeaderText="序号" />
            <asp:BoundField DataField="KQDate" HeaderText="考勤时间" />
            <asp:BoundField DataField="KQClassName" HeaderText="班级" />
            <asp:BoundField DataField="KQClass" HeaderText="课程名" />
            <asp:BoundField DataField="KQClassNum" HeaderText="节数" />
            <asp:HyperLinkField DataNavigateUrlFields="KQID" HeaderText="查看详情" Text="查看" DataNavigateUrlFormatString="Cqsjh.aspx?id={0}" />
            <asp:HyperLinkField DataNavigateUrlFields="KQID" HeaderText="删除" Text="删除" DataNavigateUrlFormatString="Cqsjh.aspx?sid={0}" />
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
</asp:Content>

