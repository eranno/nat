<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="disconnect.aspx.cs" Inherits="Application.disconnect" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="index.css" />
    <link rel="icon" type="image/png" href="favicon.ico" />
    <title>nat</title>
</head>
<body style="background-image:url('pic/jce_bg.jpg');background-position:center;">
    <form id="Form1" runat="server">
        <fieldset>
            <legend>התנתקות</legend>

            <img id="login" src="pic/login.png" title="login" />
            <span>ת"ז</span>

            <asp:TextBox runat="server" ID="id" TextMode="SingleLine" ToolTip="זהות משתמש" MaxLength="9" ReadOnly="true"></asp:TextBox>
            <br /><span>סיסמה</span>
            <asp:TextBox runat="server" ID="password" TextMode="Password" ToolTip="סיסמה"></asp:TextBox>


            <asp:Button id="button" Text="התנתק" runat="server" OnClick="button_Click" />
            <asp:Label ID="Label" runat="server"></asp:Label>
            
        </fieldset>
    </form>
</body>
</html>