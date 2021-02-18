<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="EcommAssignment2.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Menu Menu</title>
        <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainDiv" runat="server">
        <div class="menuCard">
            <img class="photo" src="menu/applejuice.jpg" />
            <img class="photo" src="menu/applejuice.jpg" />
        </div>
    </div>

    <asp:Button class="button" ID="Button1" runat="server" Text="Add to Orders" />
</asp:Content>






