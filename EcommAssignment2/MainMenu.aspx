<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="EcommAssignment2.MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Menu Menu</title>
    <link rel="stylesheet" href="CSS/MainMenuStyle.css" />
    <script src="https://kit.fontawesome.com/bcb50e5738.js" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">
        <div id="mainDiv" class="mainDiv" runat="server">
        </div>
        <div id="currentOrdersSection" class="current-orders-section" runat="server">
            <h4 class="titles">Current Orders</h4>
            <div class="currentOrderDivider">
                <asp:Button ID="cancelButton" class="btn btn-danger buttonText" runat="server" Text="Cancel" OnClick="cancelButton_Click" />
                <asp:Button ID="ordersButton" class="btn btn-success buttonText" runat="server" Text="Place Order" OnClick="ordersButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
