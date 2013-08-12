<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Application.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="index.css" 
    <link rel="icon" type="image/png" href="favicon.ico">
    <title>nat</title>
</head>
<body>
    <form id="Form1" runat="server">
        <fieldset>
            <legend>התחברות</legend>

            <img id="login" src="pic/login.png" title="login" />
            <span>ת"ז</span>

            <asp:TextBox runat="server" ID="id" TextMode="SingleLine" ToolTip="זהות משתמש" MaxLength="9"></asp:TextBox>
            <br /><span>סיסמה</span>
            <asp:TextBox runat="server" ID="password" TextMode="Password" ToolTip="סיסמה"></asp:TextBox>


            <asp:Button id="button" Text="התחבר" runat="server" OnClick="Unnamed1_Click" />
            <asp:Label ID="Label" runat="server"></asp:Label>
            
        </fieldset>
    </form>
</body>
</html>