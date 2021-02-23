﻿<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EcommAssignment2.HomePage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>House</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">
    <link href="CSS/HomePageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="d-block w-100" src="Images/goku_family.jpg" alt="First slide">
                    <div class="carousel-caption d-none d-md-block">
                        <h1>A Place Where The Whole Family Can Enjoy</h1>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="Images/mai_pilaf_shu.jpg" alt="Second slide">
                    <div class="carousel-caption d-none d-md-block">
                        <h1>Anyone Can Find Something To Enjoy</h1>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="Images/goku_beerus.jpg" alt="Third slide">
                    <div class="carousel-caption d-none d-md-block">
                        <h1>Even The Gods Recommend Our Resturants</h1>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <div class="card-section">
            <div class="card">
                <h4>A Menu Filled with Delicious Foods</h4>
                <asp:Image ID="firstCardImage" runat="server" CssClass="cardImage" ImageUrl="/Images/krillin_food.jpg" /><br />
                <a class="card-button" href="MainMenu.aspx">Go See The Menu</a>
            </div>

            <div class="card">
                <h4>Contact Us!</h4>
                <asp:Image ID="secondCardImage" runat="server" CssClass="cardImage" ImageUrl="/Images/contact_us.jpg" /><br />
                <a class="card-button" href="ContactPage.aspx">Contact Us!</a>
            </div>

            <div class="card">
                <h4>Learn more about us!</h4>
                <asp:Image ID="thirdCardImage" runat="server" CssClass="cardImage" ImageUrl="/Images/learn_more.jpg" /><br />
                <a class="card-button" href="AboutPage.aspx">Learn About Us!</a>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js" integrity="sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.6.0/dist/umd/popper.min.js" integrity="sha384-KsvD1yqQ1/1+IA7gi3P0tyJcT3vR+NdBTt13hSJ2lnve8agRGXTTyNaBYmCR/Nwi" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.min.js" integrity="sha384-nsg8ua9HAw1y0W1btsyWgBklPnCUAFLuTMS2G72MMONqmOymq585AcH49TLBQObG" crossorigin="anonymous"></script>
</asp:Content>
