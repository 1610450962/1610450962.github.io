<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="Cqsjh.aspx.cs" Inherits="Cqsjh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">考勤数据详情管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Cqmanage.aspx">出勤管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Cqshuj.aspx">出勤数据管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="Cqsjh.aspx">考勤数据详情管理</asp:HyperLink>

    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="序号" DataField="KQDid" />
            <asp:BoundField HeaderText="姓名" DataField="stuName" />
            <asp:BoundField HeaderText="签到时间" DataField="KQtime" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
            <asp:HyperLinkField HeaderText="更改状态" Text="设为请假" DataNavigateUrlFields="KQDid" DataNavigateUrlFormatString="CQh.aspx?qid={0}" />
            <asp:HyperLinkField Text="设为早退" DataNavigateUrlFields="KQDid" DataNavigateUrlFormatString="CQh.aspx?zid={0}" />
            <asp:HyperLinkField Text="设为迟到" DataNavigateUrlFields="KQDid" DataNavigateUrlFormatString="CQh.aspx?cid={0}" />
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

