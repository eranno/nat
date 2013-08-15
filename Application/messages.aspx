<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messages.aspx.cs" Inherits="Application.messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>nat</title>
    <link rel="stylesheet" href="main.css" />
    <link rel="icon" type="image/png" href="favicon.ico" />
    <script type="application/x-javascript" src="clock.js"></script>
    <script type="application/x-javascript" src="msgs.js"></script>
</head>
<body>
    <div class="frame header">
        <div class="left">
            <span><asp:Label ID="first" runat="server"></asp:Label> <asp:Label ID="last" runat="server"></asp:Label></span>
            <br /><span id="time"></span>
        </div>
        <div class="right">
            <a href="index.aspx?r=outoftime">השהייה</a> / <a href="disconnect.aspx">התנתקות</a>
            <br /><br />
        </div>
    </div>

    <form class="frame" runat="server">        
        הודעות: <asp:Label ID="msgs" runat="server"></asp:Label>
        <asp:Table ID="Table1" GridLines="Both" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>תאריך</asp:TableHeaderCell>
                <asp:TableHeaderCell>השולח</asp:TableHeaderCell>
                <asp:TableHeaderCell>סוג</asp:TableHeaderCell>
                <asp:TableHeaderCell>מאושר</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
       


    </form>

    <div class="frame footer"></div>
</body>
</html>
