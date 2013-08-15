<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clockReport.aspx.cs" Inherits="Application.clockReport" %>

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
            <a>השהייה</a> / <a href="disconnect.aspx">התנתקות</a>
            <br /><br />
        </div>
    </div>

    <div class="frame">
        <h3>דו"ח שעות נוכחות</h3>
        <asp:Table ID="Table1" GridLines="Both" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="3"></asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="2">החתמות</asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="3"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>תאריך</asp:TableHeaderCell>
                <asp:TableHeaderCell>סיבה</asp:TableHeaderCell>
                <asp:TableHeaderCell>נימוק</asp:TableHeaderCell>
                <asp:TableHeaderCell>כניסה</asp:TableHeaderCell>
                <asp:TableHeaderCell>יציאה</asp:TableHeaderCell>
                <asp:TableHeaderCell>סה"כ שעות</asp:TableHeaderCell>
                <asp:TableHeaderCell>שעות עודפות</asp:TableHeaderCell>
                <asp:TableHeaderCell>שעות חסרות</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

</body>
</html>
