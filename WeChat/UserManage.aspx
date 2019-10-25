<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">用户管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <br />
            <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
        &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="UserManage.aspx">用户管理</asp:HyperLink>
    <asp:GridView ID="GridView1" Width="100%" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" CssClass="table">
        <AlternatingRowStyle BackColor="White"/>
        <Columns>
            <asp:BoundField DataField="userNickName" HeaderText="昵称">

            </asp:BoundField>
            <asp:BoundField DataField="sex" HeaderText="性别">

            </asp:BoundField>
            <asp:BoundField DataField="subscribe_scene" HeaderText="关注方法">

            </asp:BoundField>
            <asp:HyperLinkField HeaderText="查看详情" Text="查看详情" DataNavigateUrlFields="userid" DataNavigateUrlFormatString="Userxq.aspx?id={0}" >

            </asp:HyperLinkField>
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

