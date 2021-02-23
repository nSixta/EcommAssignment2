<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="EcommAssignment2.orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="CSS/orders.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ordersMainDiv">
        <div>
            <div ID="currentOrders" class="orderCard" runat="server">
                <asp:Label ID="currentOrdersLabel" runat="server" Text="Current Orders"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Overall-Total"></asp:Label>
                <asp:Label ID="overAllTotal" runat="server" Text="Label"></asp:Label>
                 <asp:Button ID="Button1" runat="server" Text="Pay These Orders" OnClick="Button1_Click" />

            </div>
            <div ID="deliveryOrders" class="orderCard" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Being Delivered"></asp:Label>
                <asp:Button ID="deliveredButton" runat="server" Text="Click if delivered" OnClick="deliveredButton_Click" />
            </div>
        </div>
        <div ID="previousOrders" class="orderCard" runat="server">
            <asp:Label ID="Label3" runat="server" Text="Previous Orders"></asp:Label>
            <asp:Button ID="clearPreivousTable" runat="server" Text="Clear Previous Orders" OnClick="clearPreivousTable_Click" />
        </div>
    </div>
</asp:Content>
