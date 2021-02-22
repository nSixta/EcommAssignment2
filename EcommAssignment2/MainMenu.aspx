<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="EcommAssignment2.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Menu Menu</title>
        <link href="CSS/menu_page_stylesheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="mainDiv" class="mainDiv" runat="server">
    </div>

    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="1">Restaurant1</asp:ListItem>
        <asp:ListItem Value="2">Restaurant2</asp:ListItem>
        <asp:ListItem Value="3">Restaurant3</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="ordersButton" runat="server" Text="Orders" OnClick="ordersButton_Click" />
</asp:Content>