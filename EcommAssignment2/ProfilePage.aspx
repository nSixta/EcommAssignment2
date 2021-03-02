<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="EcommAssignment2.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile</title>
    <link href="CSS/ProfilePageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">
        <asp:Label ID="Label4" runat="server" Text="Username:"></asp:Label>
        <br />
        <input type="text" class="input" id="profileUsernameInput" />
        <br />
        <br />
        <br />

        <asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label>
        <br />
        <input type="text" class="input" id="profilePassInput" />
        <br />
        <br />
        <br />

        <input type="button" class="confirm-button" id="changeProfileButton" value="Save Changes?" onclick="updateAccount()" data-bs-toggle="modal" data-bs-target="#exampleModal" />
        &nbsp;<asp:Button CssClass="confirm-button" ID="deleteProfileButton" runat="server" Text="Delete Account" OnClick="deleteProfileButton_Click" />
        <br />
        <asp:Label ID="accountChangedLabel" runat="server" Text=""></asp:Label>

        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Alert!</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>Profile was Updated</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Script/script.js"></script>
</asp:Content>
