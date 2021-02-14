<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassPage.aspx.cs" Inherits="EcommAssignment2.ForgotPassPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="CSS/ForgotPassPageStyle.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="body-section">
            <p>Enter Your Email And You Will See Your Password In Your Inbox</p>
            <asp:TextBox ID="forgotPassEmailInput" CssClass="input" runat="server"></asp:TextBox>
            <asp:Button CssClass="confirm-button" ID="sendEmailButton" runat="server" Text="Send Email" OnClick="sendEmailButton_Click" />
            &nbsp;
            <asp:Button CssClass="confirm-button" ID="goBackToHome" runat="server" Text="Back to Sign In Page" OnClick="goBackToHome_Click" />
        </div>
    </form>
</body>
</html>
