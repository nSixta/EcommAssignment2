<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="orders_cart.aspx.cs" Inherits="EcommAssignment2.orders_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/orders_cart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="ButtonCurr" runat="server" Text="Current" OnClick="ButtonCurr_Click" />
    <asp:Button ID="ButtonDel" runat="server" Text="Delivering" OnClick="ButtonDel_Click" />
    <asp:Button ID="ButtonPrev" runat="server" Text="Previous" OnClick="ButtonPrev_Click" />
    <div id="currentOrders" class="currentOrders" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Current Orders"></asp:Label>
    </div>
    <div id="deliveringOrders" class="deliveringOrders" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Delivering Orders"></asp:Label>
    </div>
    <div id="previousOrders" class="previousOrders" runat="server">
        <asp:Label ID="Label3" runat="server" Text="Previous Orders"></asp:Label>
    </div>
</asp:Content>
