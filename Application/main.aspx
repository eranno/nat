﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Application.main" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>nat</title>
    <link rel="stylesheet" href="main.css" />
    <script type="application/x-javascript" src="clock.js"></script>
</head>
<body>
    
    

    <div class="frame header">
        <span><asp:Label ID="first" runat="server"></asp:Label> <asp:Label ID="last" runat="server"></asp:Label></span>
        <br /><span id="time"></span>
    </div>
    <div class="frame">
    הודעות: <asp:Label ID="msgs" runat="server"></asp:Label>
    </div>
    <div class="frame">
        <a href="vacations.aspx" class="button">חופשות</a>
        <a class="button">ימי מחלה</a>
        <a href="clockReport.aspx" class="button">דו"ח שעות</a>
    </div>
    <asp:Panel runat="server">
        <div id="Div1" class="frame" runat="server" visible="true">
            <span>ניהול:</span>
            <a href="employees.aspx" class="button" style="margin-right:7px;">עובדים</a>
        </div>
    </asp:Panel>
</body>
</html>
