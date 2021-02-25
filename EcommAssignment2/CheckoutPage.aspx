<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="EcommAssignment2.CheckoutPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="CSS/CheckoutPageStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-55">
                <div class="container">
                    <div class="row">
                        <div class="col-30">
                            <h3>Shipping Address</h3>
                            <label for="fname"><i class="fa fa-user"></i>&nbsp;Full Name</label>
                            <asp:TextBox ID="nameCheckOutText" runat="server"></asp:TextBox>

                            <label for="adr"><i class="fa fa-address-card-o"></i>&nbsp;Address</label>
                            <asp:TextBox ID="addressCheckOutText" runat="server"></asp:TextBox>

                            <label for="city"><i class="fa fa-institution"></i>&nbsp;City</label>
                            <asp:TextBox ID="cityCheckOutText" runat="server"></asp:TextBox>

                            <label for="zip"><i class="fa fa-map-pin"></i>&nbsp;Postal Code</label>
                            <asp:TextBox ID="postalCodeText" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-45">
                <div class="container">
                    <h4>Cart&nbsp;<span class="price" style="color: black"><i class="fa fa-shopping-cart">&nbsp;</i><asp:Label ID="checkOutCartNumber" runat="server" Text="0"></asp:Label></span></h4>
                    <div id="itemCheckOutList" runat="server">
                    </div>
                    <h3>Subtotal:<span class="price" style="color: black"><asp:Label ID="subtotalLabel" runat="server" Text=""></asp:Label></span></h3>
                    <h3>Taxes:<span class="price" style="color: black"><asp:Label ID="taxesLabel" runat="server" Text=""></asp:Label></span></h3>
                    <h3>Shipping:<span class="price" style="color: black"><asp:Label ID="shippingCostLabel" runat="server" Text=""></asp:Label></span></h3>
                    <h3>Total<span class="price" style="color: black"><asp:Label ID="checkOutPriceLabel" runat="server" Text=""></asp:Label></span></h3>
                    <asp:Button ID="payCheckOutButton" CssClass="btn" runat="server" Text="Place Order" OnClick="payCheckOutButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
