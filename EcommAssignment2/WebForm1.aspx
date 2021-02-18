<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EcommAssignment2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>abc</title>
    <link href="CSS/menu_page_stylesheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="mainDiv" class="mainDiv" runat="server">
        <div class="menuCard">
            <img class="photo" src="menu/applejuice.jpg" />
            <img class="photo" src="menu/applejuice.jpg" />
        </div>
    </div>

     <asp:Button class="button" ID="Button1" runat="server" Text="Add to Orders" />
</asp:Content>
