<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Application.info" %>

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
            <br /><a href="main.aspx">[לדף הראשי]</a><br />
        </div>
    </div> 

    <asp:Panel ID="Panel1" runat="server">
        <div id="msgs" runat="server" class="frame" visible="false"></div>
    </asp:Panel>

    <form class="frame" runat="server">
        
        <% if (Request.QueryString["id"] != null){%>

        <h3>עדכון פרטים</h3>
        <br /><span>תעודת זהות</span>
        <asp:TextBox runat="server" ID="new_id" TextMode="SingleLine" MaxLength="9"></asp:TextBox>
        <br /><span>שם פרטי</span>
        <asp:TextBox runat="server" ID="new_first" TextMode="SingleLine"></asp:TextBox>
        <br /><span>שם משפחה</span>
        <asp:TextBox runat="server" ID="new_last" TextMode="SingleLine"></asp:TextBox>
        <br /><span>ימי מחלה</span>
        <asp:TextBox runat="server" ID="new_sick" TextMode="SingleLine"></asp:TextBox>
        <br /><span>ימי חופשה</span>
        <asp:TextBox runat="server" ID="new_vacation" TextMode="SingleLine"></asp:TextBox>
        <br /><span>שעות מינימום</span>
        <asp:TextBox runat="server" ID="new_minhours" TextMode="SingleLine"></asp:TextBox>
        <br /><span>שעות מקסימום</span>
        <asp:TextBox runat="server" ID="new_maxhours" TextMode="SingleLine"></asp:TextBox>
        <br /><span>דרגה</span>
        <asp:TextBox runat="server" ID="new_rank" TextMode="SingleLine"></asp:TextBox>
        <br /><span>שכר</span>
        <asp:TextBox runat="server" ID="new_wage" TextMode="SingleLine"></asp:TextBox>
        <br />

        <% } else { %>

        <br /><span>סיסמה ישנה</span>
        <asp:TextBox runat="server" ID="oldpass" TextMode="Password"></asp:TextBox>
        <br /><span>סיסמה חדשה</span>
        <asp:TextBox runat="server" ID="pass1" TextMode="Password"></asp:TextBox>
        <br /><span>אימות סיסמה</span>
        <asp:TextBox runat="server" ID="pass2" TextMode="Password"></asp:TextBox>
        <br />

        <% } %>
        <asp:Button id="button" Text="עדכן" runat="server" CssClass="button" OnClick="button_Click"/>
    </form> 

    <!-- footer -->
    <div class="frame footer"></div>
</body>
</html>
