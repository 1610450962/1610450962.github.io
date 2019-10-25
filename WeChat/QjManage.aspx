<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="QjManage.aspx.cs" Inherits="QjManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">请假管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="QjManage.aspx">请假管理</asp:HyperLink>

    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="未审核" 
        Width="30%" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="以批准" 
        Width="30%" />
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="已拒绝" 
        Width="30%" />

    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="table" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="stuName" HeaderText="姓名" />
            <asp:BoundField DataField="ldate" HeaderText="请假日期" />
            <asp:BoundField DataField="days" HeaderText="天数" />
            <asp:HyperLinkField DataNavigateUrlFields="lid,state" 
                DataNavigateUrlFormatString="qingjxq.aspx?id={0}&amp;state={1}" 
                HeaderText="管理" Text="管理" />
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

