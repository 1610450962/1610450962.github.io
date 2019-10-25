<%@ Page Title="" Language="C#" MasterPageFile="muban.master" AutoEventWireup="true" CodeFile="Userxq.aspx.cs" Inherits="Userxq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleC" Runat="Server">用户详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlace" Runat="Server">

        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="adminindex.aspx" >管理</asp:HyperLink>
            &gt;&gt;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="UserManage.aspx">用户管理</asp:HyperLink>
            &gt;&gt;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Userxq.aspx">用户详情</asp:HyperLink>
        </p>
        <p>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" ImageAlign="AbsBottom" Width="200px" />
        </p>
        <p>
            <asp:Label ID="lname" runat="server" Text="Label" Font-Size="24pt" 
                ForeColor="#00CCFF"></asp:Label>
        </p>
        <p>
            用户ID：<asp:Label ID="lid" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            性别：<asp:Label ID="lsex" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            city:<asp:Label ID="lcity" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            国际：<asp:Label ID="lgj" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            城市：<asp:Label ID="lcs" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            语言：<asp:Label ID="lyy" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            关注时间：<asp:Label ID="lgztime" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            关注方法：<asp:Label ID="lgzf" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            学号：<asp:TextBox ID="tstuid" runat="server" 
                CssClass="form-control" placeholder="输入你的学号绑定"></asp:TextBox>
        </p>
        <p>
            描述：<asp:Label ID="lmm" runat="server" Text="Label"></asp:Label>
        </p>
        
        <p>
            <asp:Button ID="Button2" runat="server" Text="绑定" 
                CssClass="form-control btn-lg btn-primary" Height="50px" 
                onclick="Button2_Click"/>
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="解绑" 
                CssClass="form-control btn-lg btn-success" Height="50px" 
                onclick="Button3_Click" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="返回" CssClass="form-control btn-lg btn-success" Height="50px" OnClick="Button1_Click"/>
        </p>

</asp:Content>

