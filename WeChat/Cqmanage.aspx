<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="Cqmanage.aspx.cs" Inherits="Cqmanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">出勤管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Cqmanage.aspx">出勤管理</asp:HyperLink>

    <br />
    上课时间:<asp:DropDownList ID="dclassnum" runat="server">
        <asp:ListItem>第一节课</asp:ListItem>
        <asp:ListItem>第二节课</asp:ListItem>
        <asp:ListItem>第三节课</asp:ListItem>
        <asp:ListItem>第四节课</asp:ListItem>
        <asp:ListItem>第五节课</asp:ListItem>
        <asp:ListItem>第六节课</asp:ListItem>
        <asp:ListItem>第七节课</asp:ListItem>
        <asp:ListItem>第八节课</asp:ListItem>
        <asp:ListItem>第九节课</asp:ListItem>
        <asp:ListItem>第十节课</asp:ListItem>
        <asp:ListItem>第十一节课</asp:ListItem>
        <asp:ListItem>第十二节课</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    考勤课程:<asp:DropDownList ID="dclass" runat="server">
        <asp:ListItem>综合实训（一）</asp:ListItem>
        <asp:ListItem>计算机</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    考勤班级:<asp:DropDownList ID="dclassname" runat="server">
        <asp:ListItem>2017软件方向班</asp:ListItem>
        <asp:ListItem>2017网络方向班</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    多少时间后开始记迟到:<asp:DropDownList ID="dtime" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
    </asp:DropDownList>
    分钟<br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="开始考勤" CssClass="btn-warning" Height="40px" Width="19%"/>
    <asp:Button ID="Button2" runat="server" Text="结束考勤" CssClass="btn-success" Height="40px" Width="19%" onclick="Button2_Click"/>
    <asp:Button ID="Button3" runat="server" Text="刷新数据" CssClass="btn-toolbar" Height="40px" Width="19%" onclick="Button3_Click1"/>
    <asp:Button ID="Button4" runat="server" Text="考勤数据管理" CssClass="btn-primary" Height="40px" Width="19%" OnClick="Button4_Click"/>
    <asp:Button ID="Button5" runat="server" Text="学生考勤信息" CssClass="btn-primary"  Height="40px" Width="19%" onclick="Button5_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" CssClass="table" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="stuNum" HeaderText="学号" />
            <asp:BoundField DataField="stuName" HeaderText="姓名" />
            <asp:BoundField DataField="Status" HeaderText="签到情况" />
            <asp:BoundField DataField="KQtime" HeaderText="签到时间" />
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

