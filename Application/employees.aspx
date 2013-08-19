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
        <div class="left">
            <span><asp:Label ID="first" runat="server"></asp:Label> <asp:Label ID="last" runat="server"></asp:Label></span>
            <br /><span id="time"></span>
        </div>
        <div class="right">
            <a href="index.aspx?r=outoftime">השהייה</a> / <a href="disconnect.aspx">התנתקות</a>
            <br /><br />
        </div>
    </div>

    <asp:Panel ID="Panel1" runat="server">
        <div id="msgs" runat="server" class="frame" visible="false"></div>
    </asp:Panel>

    <div class="frame">
        <a id="js_toggle_1" href="#" class="button">רשימת עובדים</a>
        <a id="js_toggle_2" href="#" class="button">עובדים נוכחים</a>
        <a id="js_toggle_3" href="#" class="button">חיפוש עובד</a>
        <a id="js_toggle_4" href="#" class="button">הוספת עובד</a>
    </div>

    <form id="form1" runat="server">

    <div id="toggle_1" class="frame toggle">
        <img id="search" src="pic/search.jpg" />
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

    <div id="toggle_2" class="frame toggle">
        <img id="Img1" src="pic/search.jpg" />
        <h3>עובדים נוכחים</h3>
        <asp:Table ID="Table2" GridLines="Both" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>תעודת זהות</asp:TableHeaderCell>
                <asp:TableHeaderCell>שם פרטי</asp:TableHeaderCell>
                <asp:TableHeaderCell>שם משפחה</asp:TableHeaderCell>
                <asp:TableHeaderCell>דרגה</asp:TableHeaderCell>
                <asp:TableHeaderCell>שעות</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    <div id="toggle_3" class="frame toggle">
        <h3>חיפוש עובד</h3>

        <select runat="server" id="js_select">
            <option value="1" selected="selected">תעודת זהות</option>
            <option value="2">שם</option>
        </select>
        <div id="opt1">
            <asp:TextBox runat="server" ID="opt_id" TextMode="SingleLine"></asp:TextBox>
        </div>
        <div id="opt2" class="toggle">
            <span>שם פרטי</span>
            <asp:TextBox runat="server" ID="opt_first" TextMode="SingleLine"></asp:TextBox>
            <br /><span>שם משפחה</span>
            <asp:TextBox runat="server" ID="opt_last" TextMode="SingleLine"></asp:TextBox>
        </div>
        

        <asp:Button id="button1" Text="חפש" runat="server" CssClass="button" OnClick="button_Click3"/>
    </div>

    <div id="toggle_4" class="frame toggle" runat="server">
        <h3>הוספת עובד</h3>
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

        <asp:Button id="button" Text="שלח" runat="server" CssClass="button" OnClick="button_Click4"/>
    </div>
    </form>

    <div class="frame footer"></div>

</body>
</html>
