<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="StuInManage.aspx.cs" Inherits="StuInManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">学生管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="StuInManage.aspx">学生管理</asp:HyperLink>
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" CssClass="form-control">
        <asp:ListItem Selected="True">学号</asp:ListItem>
        <asp:ListItem>姓名</asp:ListItem>
        <asp:ListItem Value="联系电话">电话</asp:ListItem>
        <asp:ListItem>班级</asp:ListItem>
        <asp:ListItem>联系地址</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="Label1" runat="server" Font-Size="16pt" Text="查询:"></asp:Label>
    <asp:TextBox ID="tstuidcx" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="GO" class="btn btn-primary"/>
    <br />
    <asp:Label ID="ljls" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="学号" HeaderText="学号" />
            <asp:BoundField DataField="姓名" HeaderText="姓名" />
            <asp:BoundField DataField="班级" HeaderText="班级" />
            <asp:HyperLinkField DataNavigateUrlFields="学号" 
                DataNavigateUrlFormatString="Stuxq.aspx?id={0}" HeaderText="查看" Text="详情" />
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
    
</asp:Content>

