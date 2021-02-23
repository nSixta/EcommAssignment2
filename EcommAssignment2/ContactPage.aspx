<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactPage.aspx.cs" Inherits="EcommAssignment2.ContactPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contact</title>
    <link href="CSS/ContactPageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">

        <p>First Name:</p>
        <asp:TextBox CssClass="input" ID="firstNameContactInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="firstNameContactLabel" runat="server" Visible="False"></asp:Label>
        <br />

        <p>Last Name:</p>
        <asp:TextBox CssClass="input" ID="lastNameContactInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lastNameContactLabel" runat="server" Visible="False"></asp:Label>
        <br />

        <p>Email:</p>
        <asp:TextBox CssClass="input" ID="emailContactInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="emailContactLabel" runat="server" Visible="False"></asp:Label>
        <br />

        <p>Subject:</p>
        <asp:TextBox CssClass="input" ID="subjectInput" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="subjectLabel" runat="server" Visible="False"></asp:Label>
        <br />

        <p>Message:</p>
        <asp:TextBox CssClass="input" ID="messageInput" runat="server" Height="211px" TextMode="MultiLine" Width="492px"></asp:TextBox>
        <br />
        <br />
        <asp:Button CssClass="confirm-button" ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
    </div>
</asp:Content>
