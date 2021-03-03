<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactPage.aspx.cs" Inherits="EcommAssignment2.ContactPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contact</title>
    <link href="CSS/ContactPageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">
        <div class="message-input">
            <p>Comment:</p>
            <asp:TextBox CssClass="input" ID="messageInput" runat="server" Height="211px" TextMode="MultiLine" Width="492px"></asp:TextBox>
            <br />
            <br />
            <asp:Button CssClass="confirm-button" ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
        </div>
        <div style="padding: 15px">
            <h3>Here are some comments from our clients.</h3>
            <h4>We allow all comments to be seen.</h4>
            <hr />
            <div id="messageSection" class="message-section" runat="server">
            </div>
        </div>
    </div>
</asp:Content>
