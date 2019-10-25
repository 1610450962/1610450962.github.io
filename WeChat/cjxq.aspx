<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="cjxq.aspx.cs" Inherits="cjxq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">成绩详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx">管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="CjManage.aspx">成绩管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="cjxq.aspx">成绩详情</asp:HyperLink>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Font-Size="16pt" Text="Label"></asp:Label>
应修学分：129，已修学分：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="False" CssClass="table" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="科目" HeaderText="科目" />
                        <asp:BoundField DataField="学分" HeaderText="学分" />
                        <asp:BoundField DataField="成绩" HeaderText="成绩" />
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

