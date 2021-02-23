<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="EcommAssignment2.MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Menu Menu</title>
    <link rel="stylesheet" href="CSS/MainMenuStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">
        <div id="mainDiv" class="mainDiv" runat="server">
        </div>
        <div id="currentOrdersSection" class="current-orders-section" runat="server">
            <h4>Current Orders</h4>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1">Restaurant1</asp:ListItem>
                <asp:ListItem Value="2">Restaurant2</asp:ListItem>
                <asp:ListItem Value="3">Restaurant3</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="cancelButton" CssClass="cancelButton" runat="server" Text="Cancel" OnClick="cancelButton_Click" />
            <asp:Button ID="ordersButton" CssClass="placeOrderButton" runat="server" Text="Place Order" OnClick="ordersButton_Click" />
            <asp:Label ID="totalPriceLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
