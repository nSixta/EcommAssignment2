<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EcommAssignment2.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="CSS/HomePageStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-section">
            <div class="login-header">
                <asp:Image ID="bulmaImage" runat="server" Height="114px" ImageUrl="/Images/bulma_image.png" Width="107px" />
                <div class="login-header-right">
                    <p>Bulma</p>
                    <p>Fast-Food</p>
                </div>
            </div>
            <br />
            <p>First Time Here? Sign Up Now!</p>
            <asp:Button CssClass="button" ID="signUpButton" runat="server" Text="Sign Up!" OnClick="signUpButton_Click" />
            <br />
            <br />
            <p class="input-label"><i class="fa fa-user"></i>Username</p>
            <asp:TextBox CssClass="input" ID="usernameTextBox" runat="server" Width="300px"></asp:TextBox>
            <asp:Label ID="usernameLabel" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <p class="input-label"><i class="fa fa-key"></i>Password</p>
            <asp:TextBox CssClass="input" ID="passwordTextBox" runat="server" Width="300px"></asp:TextBox>
            <asp:Label ID="passwordLabel" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button CssClass="button" ID="signInButton" runat="server" Text="Sign In" OnClick="signInButton_Click" />
            <br />
            <br />
            <asp:LinkButton ID="forgotPassLink" runat="server" OnClick="forgotPassLink_Click">Forgot Password</asp:LinkButton>
        </div>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    </form>
</body>
</html>
