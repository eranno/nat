﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vacations.aspx.cs" Inherits="Application.vacations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>nat</title>
    <link rel="stylesheet" href="main.css" />
    <link rel="icon" type="image/png" href="favicon.ico" />
    <script type="application/x-javascript" src="clock.js"></script>
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

    <div class="frame">
        <h3>מאזן חופשות</h3>
        <span>יתרה: <asp:Label ID="totalSum" runat="server"></asp:Label></span>
        <asp:Table ID="Table1" GridLines="Both" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>חודש</asp:TableHeaderCell>
                <asp:TableHeaderCell>מספר ימי חופשה</asp:TableHeaderCell>
                <asp:TableHeaderCell>תאריך תחילת חופשה</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    <form class="frame" id="form1" runat="server">
        <div id="toggle">
            <h3>בקשת חופשה</h3>
            <div class="toggle">
                <span>מתאריך</span>
                <asp:TextBox runat="server" ID="start" TextMode="Date"></asp:TextBox>
                <br /><span>עד לתאריך</span>
                <asp:TextBox runat="server" ID="end" TextMode="Date"></asp:TextBox>
                <br /><span>משך</span>
                <asp:TextBox runat="server" ID="during" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Button id="button" Text="שלח" runat="server" CssClass="button" OnClick="button_Click"/>
            </div>
        </div>
    </form>

    <div class="frame footer"></div>

</body>
</html>
