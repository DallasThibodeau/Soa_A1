<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SOAAssign2._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 524px;
            width: 834px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ListBox ID="Operation" runat="server" Height="232px">
            <asp:ListItem value="NTW">Number to Word</asp:ListItem>
            <asp:ListItem value="NTD">Number To Dollars</asp:ListItem>

            <asp:ListItem value="FIFA">World Cup - Get All Player's Names</asp:ListItem>
            <asp:ListItem value="TOPGOAL">World Cup - Top Goal Scorers</asp:ListItem>
            <asp:ListItem value="STADIUMS">World Cup - Stadium Names</asp:ListItem>
            <asp:ListItem value="STADINFO">World Cup - Stadium Info</asp:ListItem>
            <asp:ListItem value="TEAMS">World Cup - Teams</asp:ListItem>

            <asp:ListItem value="COUNTRY">Country Information - List of Country Names by Name</asp:ListItem>
            <asp:ListItem value="CAPITAL">Country Information - Capital City</asp:ListItem>
            <asp:ListItem value="CURRENCY">Country Information - List of Currencies by Code</asp:ListItem>
            <asp:ListItem value="ISO">Country Information - Country ISO Code</asp:ListItem>

            <asp:ListItem value="CASE">String Case Change</asp:ListItem>
            <asp:ListItem value="CASEPREV">Conform String to First Letter Casing</asp:ListItem>
        </asp:ListBox>
        &nbsp;
        <br/>
        <asp:TextBox ID="argument" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br/>
    </form>
</body>
</html>
