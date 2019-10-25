<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="Cqstusj.aspx.cs" Inherits="Cqstusj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">学生数据</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">



    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Cqmanage.aspx">出勤管理</asp:HyperLink>
    &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Cqstusj.aspx">学生数据</asp:HyperLink>
    <div id="datePlugin"></div>
        <br />
    开始时间：<input type="text" name="dateinput1" id="dateinput1" style="width:90%;height:50px;line-height:50px;display:block;margin:10px auto;font-size:16px;text-align:center;" onclick="return dateinput_onclick()" /> 
        结束时间:<input type="text" name="dateinput2" id="dateinput2" style="width:90%;height:50px;line-height:50px;display:block;margin:10px auto;font-size:16px;text-align:center;" onclick="return dateinput_onclick()" /> 
    <asp:Button ID="Button2" runat="server" Text="查询时间内" class="btn btn-primary" OnClick="Button2_Click"/>
    <br />
    <div id="datePlug">
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="form-control">
            <asp:ListItem Value="stuNum" Selected="True">学号</asp:ListItem>
            <asp:ListItem Value="stuname">姓名</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        查询：<asp:TextBox ID="tss" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="GO" class="btn btn-primary" OnClick="Button1_Click" />
    </div>
           &nbsp;<br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" CssClass="table" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="stuNum" HeaderText="学号" />
            <asp:BoundField DataField="stuName" HeaderText="姓名" />
            <asp:BoundField DataField="zhengchang" HeaderText="正常" />
            <asp:BoundField DataField="chidao" HeaderText="迟到" />
            <asp:BoundField DataField="qingjia" HeaderText="请假" />
            <asp:BoundField DataField="zaotui" HeaderText="早退" />
            <asp:BoundField DataField="queqin" HeaderText="缺勤" />
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

