<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employees.aspx.cs" Inherits="Application.employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <title>nat</title>
    <link rel="stylesheet" href="main.css" />
    <link rel="icon" type="image/png" href="favicon.ico" />
    <script type="application/x-javascript" src="func.js"></script>
    <script type="application/x-javascript" src="clock.js"></script>
</head>
<body>
    <div class="frame header">
        <span><asp:Label ID="Label1" runat="server"></asp:Label> <asp:Label ID="Label2" runat="server"></asp:Label></span>
        <br /><span id="time"></span>
    </div>

    <asp:Panel>
        <div id="msgs" runat="server" class="frame" visible="false">No records are available.</div>
    </asp:Panel>

    <div class="frame">
        <img id="search" src="https://lh6.ggpht.com/IVdU2KpQmijHlotOGVzINvcGAja67hyNZkBjCjhwZTcKs6JmYobFkmlj5t_AjKy4dOc=w170" />
        <h3>רשימת עובדים</h3>
        <asp:Table ID="Table1" GridLines="Both" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>תעודת זהות</asp:TableHeaderCell>
                <asp:TableHeaderCell>שם פרטי</asp:TableHeaderCell>
                <asp:TableHeaderCell>שם משפחה</asp:TableHeaderCell>
                <asp:TableHeaderCell>דרגה</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    <form class="frame" id="form1" runat="server">
        <div id="js_toggle">
            <h3>הוספת עובד</h3>
            <div class="toggle">
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
                <br /><span>overtimeinday</span>
                <asp:TextBox runat="server" ID="new_overtimeinday" TextMode="SingleLine"></asp:TextBox>
                <br /><span>דרגה</span>
                <asp:TextBox runat="server" ID="new_rank" TextMode="SingleLine"></asp:TextBox>
                <br /><span>שכר</span>
                <asp:TextBox runat="server" ID="new_wage" TextMode="SingleLine"></asp:TextBox>
                <br /><span>overtimeWages</span>
                <asp:TextBox runat="server" ID="new_overtimeWages" TextMode="SingleLine"></asp:TextBox>
                <br /><span>overtimeinmonth</span>
                <asp:TextBox runat="server" ID="new_overtimeinmonth" TextMode="SingleLine"></asp:TextBox>
                <br /><span>timeheworkonday</span>
                <asp:TextBox runat="server" ID="new_timeheworkonday" TextMode="SingleLine"></asp:TextBox>
                <br /><span>timeheworkonmonth</span>
                <asp:TextBox runat="server" ID="new_timeheworkonmonth" TextMode="SingleLine"></asp:TextBox>
                <br />

                <asp:Button id="button" Text="שלח" runat="server" CssClass="button" OnClick="button_Click"/>
            </div>
        </div>
    </form>

    <div class="frame footer"></div>

</body>
</html>
