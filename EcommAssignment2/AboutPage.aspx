<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="AboutPage.aspx.cs" Inherits="EcommAssignment2.AboutPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Download the newsletter to learn about this store and the others owned by Bulma.</p>
    <asp:LinkButton ID="downloadLink" runat="server" OnClick="downloadLink_Click">Download Here</asp:LinkButton>
</asp:Content>
