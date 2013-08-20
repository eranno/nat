<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clockReport.aspx.cs" Inherits="Application.clockReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>nat</title>
    <link rel="stylesheet" href="main.css" />
    <link rel="icon" type="image/png" href="favicon.ico" />
    <script type="application/x-javascript" src="clock.js"></script>
    <script type="application/x-javascript" src="reportEdit.js"></script>
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
            <br /><a href="main.aspx">[לדף הראשי]</a><br />
        </div>
    </div> 

    <div id="clockReports" class="frame<% if (Request.QueryString["id"] != null) Response.Write(" admin"); %>">
        <h3>דו"ח שעות נוכחות</h3>
        <asp:Label ID="user_first" runat="server"></asp:Label> <asp:Label ID="user_last" runat="server"></asp:Label>
        <br /><asp:Label ID="past" runat="server"><<</asp:Label> <asp:Label ID="user_month" runat="server"></asp:Label> <asp:Label ID="user_year" runat="server"></asp:Label> <asp:Label ID="next" runat="server">>></asp:Label>
        <asp:Table ID="Table1" GridLines="Both" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="3"></asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="2">החתמות</asp:TableHeaderCell>
                <asp:TableHeaderCell ColumnSpan="3"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="50px">תאריך</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="100px">סיבה</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="300px">נימוק</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50px">כניסה</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50px">יציאה</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50px">סה"כ שעות</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50px">שעות עודפות</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="50px">שעות חסרות</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    <div class="frame">
        <h3>סיכום דו"ח שעות:</h3>
        סה"כ שעות חודשי: <asp:Label ID="totalHours" runat="server"></asp:Label>
    </div> 

    <!-- footer -->
    <div class="frame footer"></div>

</body>
</html>
