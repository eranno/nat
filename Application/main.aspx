<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Application.main" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>nat</title>
    <link rel="stylesheet" href="main.css" />
    <script type="application/x-javascript" src="clock.js"></script>
</head>
<body>
    <!-- header -->
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

    <asp:Panel ID="showUserDetails" runat="server">
        <div id="view" class="frame" runat="server" visible="true" style="background-color:#e8ffaf">
            <img id="search" src="pic/man1.png" style="width:150px;height:150px;" />
            <h3>פרטי העובד:</h3>
        </div>
    </asp:Panel>

    <div id="links" class="frame" runat="server">
        <a href="vacations.aspx<% if (Request.QueryString["id"] != null) Response.Write("?id=" + Request.QueryString["id"]); %>" class="button">חופשות</a>
        <a href="sick.aspx<% if (Request.QueryString["id"] != null) Response.Write("?id=" + Request.QueryString["id"]); %>" class="button">ימי מחלה</a>
        <a href="clockReport.aspx<% if (Request.QueryString["id"] != null) Response.Write("?id=" + Request.QueryString["id"]); %>" class="button">דו"ח שעות</a>
        <a href="messages.aspx<% if (Request.QueryString["id"] != null) Response.Write("?id=" + Request.QueryString["id"]); %>" class="button">הודעות[<asp:Label ID="msgs" runat="server"></asp:Label>]</a>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div id="Div1" class="frame" runat="server" visible="true">
            <span>ניהול:</span>
            <a href="employees.aspx" class="button" style="margin-right:-3px;">עובדים</a>
        </div>
    </asp:Panel>

    <!-- footer -->
    <div class="frame footer"></div>
</body>
</html>
