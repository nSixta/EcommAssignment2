<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="EcommAssignment2.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile</title>
    <link rel="stylesheet" href="CSS/ProfilePageStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">
        <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
        <br />

        <asp:TextBox CssClass="input" ID="profileFirstNameInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="profileFirstNameLabel" runat="server"></asp:Label>
        <br />
        <br />

        <asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
        <br />

        <asp:TextBox CssClass="input" ID="profileLastNameInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="profileLastNameLabel" runat="server"></asp:Label>
        <br />
        <br />

        <asp:Label ID="Label4" runat="server" Text="Username:"></asp:Label>
        <br />

        <asp:TextBox CssClass="input" ID="profileUsernameInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="profileUsernameLabel" runat="server"></asp:Label>
        <br />
        <br />

        <asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label>
        <br />

        <asp:TextBox CssClass="input" ID="profilePassInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="profilePasswordLabel" runat="server" Visible="False"></asp:Label>
        <br />
        <br />

        <asp:Label ID="Label6" runat="server" Text="Confirm Password:"></asp:Label>
        <br />

        <asp:TextBox CssClass="input" ID="profileConfirmPassInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="profileConfirmPassLabel" runat="server" Visible="False"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button CssClass="confirm-button" ID="changeProfileButton" runat="server" Text="Save Changes?" OnClick="changeProfileButton_Click" />
    </div>
</asp:Content>
