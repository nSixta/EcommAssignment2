<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="EcommAssignment2.SignInPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="CSS/SignUpPageStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="body-section">
            <p>First Name:</p>
            <asp:TextBox CssClass="input" ID="firstNameInput" runat="server"></asp:TextBox>
            <asp:Label ID="firstNameLabel" runat="server" Visible="False"></asp:Label>

            <br />

            <p>Last Name:</p>
            <asp:TextBox CssClass="input" ID="lastNameInput" runat="server"></asp:TextBox>
            <asp:Label ID="lastNameLabel" runat="server" Visible="False"></asp:Label>

            <br />

            <p>Email:</p>
            <asp:TextBox CssClass="input" ID="emailInput" runat="server"></asp:TextBox>
            <asp:Label ID="emailLabel" runat="server" Visible="False"></asp:Label>

            <br />

            <p>Username:</p>
            <asp:TextBox CssClass="input" ID="usernameInput" runat="server"></asp:TextBox>
            <asp:Label ID="usernameLabel" runat="server" Visible="False"></asp:Label>

            <br />

            <p>Password:</p>
            <asp:TextBox CssClass="input" ID="passwordInput" runat="server"></asp:TextBox>
            <asp:Label ID="passwordLabel" runat="server" Visible="False"></asp:Label>

            <br />

            <p>Confirm Password:</p>
            <asp:TextBox CssClass="input" ID="confirmPasswordInput" runat="server"></asp:TextBox>
            <asp:Label ID="confirmPassLabel" runat="server" Visible="False"></asp:Label>

            <br />
            <br />
            <br />

            <asp:Button CssClass="confirm-button" ID="confirmSignUpButton" runat="server" Text="Create Account" OnClick="confirmSignUpButton_Click" />
            &nbsp;&nbsp;
            <asp:Button CssClass="confirm-button" ID="backToHome" runat="server" Text="Back To Home Page" OnClick="backToHome_Click" />
        </div>
    </form>
</body>
</html>
