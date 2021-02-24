<%@ Page Title="" Language="C#" MasterPageFile="/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EcommAssignment2.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>House</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">
    <link href="CSS/HomePageStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body-section">
        <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="d-block w-100" src="Images/goku_family.jpg" alt="First slide">
                    <div class="carousel-caption d-none d-md-block">
                        <h1>A Place Where The Whole Family Can Enjoy</h1>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="Images/goku_eating.jpg" alt="Second slide">
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
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <div class="card-section">
            <div class="card1">
                <asp:Image runat="server" CssClass="cardImage1" ImageUrl="/Images/krillin_food.jpg" />
                <h3>Check Out Our Wide Variety of Foods</h3>
                <p>Bulma Fast Food's menu is filled with options that come from all over the world. Check out our option and find something that is right for you.</p>
                <a class="card-button" href="MainMenu.aspx">Go to Menu</a>
            </div>
            <br />
            <div class="card2">
                <asp:Image runat="server" CssClass="cardImage2" ImageUrl="/Images/contact_us.jpg" />
                <h3>Contact Us!</h3>
                <p>We always want to hear feedback from our clients so that we can improve our services.</p>
                <a class="card-button" href="ContactPage.aspx">Contact Us</a>
            </div>
            <br />
            <div class="card3">
                <asp:Image runat="server" CssClass="cardImage3" ImageUrl="/Images/learn_more.jpg" />
                <h3>Learn More About Us!</h3>
                <p>If you are not so familier with Bulma Fast Food, check out our newsletter to get a firm grasp of who we are.</p>
                <a class="card-button" href="AboutPage.aspx">Learn More</a>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js" integrity="sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.6.0/dist/umd/popper.min.js" integrity="sha384-KsvD1yqQ1/1+IA7gi3P0tyJcT3vR+NdBTt13hSJ2lnve8agRGXTTyNaBYmCR/Nwi" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.min.js" integrity="sha384-nsg8ua9HAw1y0W1btsyWgBklPnCUAFLuTMS2G72MMONqmOymq585AcH49TLBQObG" crossorigin="anonymous"></script>
</asp:Content>
