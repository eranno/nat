<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sick.aspx.cs" Inherits="Application.sick" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>nat</title>
    <link rel="stylesheet" href="main.css" />
    <link rel="icon" type="image/png" href="favicon.ico" />
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
            <br /><a href="main.aspx">[לדף הראשי]</a><br />
        </div>
    </div> 

    <div class="frame">
        <h3>ימי מחלה</h3>
        <span>שנתי: <asp:Label ID="totalSum" runat="server"></asp:Label></span>
         <span>יתרה: <asp:Label ID="havesum" runat="server"></asp:Label></span>
         <span>חריגה: <asp:Label ID="lass" runat="server"></asp:Label></span>
         <span>השתמשת: <asp:Label ID="use" runat="server"></asp:Label></span>
        <asp:Table ID="Table1" GridLines="Both" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>חודש</asp:TableHeaderCell>
                <asp:TableHeaderCell>מספר ימי מחלה</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    <!-- footer -->
    <div class="frame footer"></div>

</body>
</html>
