<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="OceanShopping.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>

    <form id="form1" runat="server">

        <div class="cart" style="float: right;">
            <div class="col-25">
                <div class="container" id="cartContainer">
                    <asp:Label runat="server" ID="checkout_cart_header"></asp:Label>
                    <br />
                    <asp:PlaceHolder runat="server" ID="checkout_items_placeholder"></asp:PlaceHolder>
                    <hr>
                    <p>Total Price: <asp:Label runat="server" ID="checkout_price"></asp:Label></p>
                </div>
            </div>
        </div>

        <div class="checkout" style="float: left;">
            <div class="row">
                <div class="col-75">
                    <div class="container">
                        <div class="row">
                            <div class="col-50">
                                <h3>Billing Address</h3>
                                <label for="fname"><i class="fa fa-user"></i>Full Name</label>
                                <input type="text" id="fname" name="firstname" placeholder="John M. Doe">
                                <label for="email"><i class="fa fa-envelope"></i>Email</label>
                                <input type="text" id="email" name="email" placeholder="john@example.com">
                                <label for="adr"><i class="fa fa-address-card-o"></i>Address</label>
                                <input type="text" id="adr" name="address" placeholder="542 W. 15th Street">
                                <label for="city"><i class="fa fa-institution"></i>City</label>
                                <input type="text" id="city" name="city" placeholder="New York">

                                <div class="row">
                                    <div class="col-50">
                                        <label for="state">State</label>
                                        <input type="text" id="state" name="state" placeholder="NY">
                                    </div>
                                    <div class="col-50">
                                        <label for="zip">Zip</label>
                                        <input type="text" id="zip" name="zip" placeholder="10001">
                                    </div>
                                </div>
                            </div>

                            <div class="col-50">
                                <h3>Payment</h3>
                                <label for="fname">Accepted Cards</label>
                                <div class="icon-container">
                                    <i class="fa fa-cc-visa" style="color: navy;"></i>
                                    <i class="fa fa-cc-amex" style="color: blue;"></i>
                                    <i class="fa fa-cc-mastercard" style="color: red;"></i>
                                    <i class="fa fa-cc-discover" style="color: orange;"></i>
                                </div>
                                <label for="cname">Name on Card</label>
                                <asp:TextBox runat="server" ID="checkout_credit_name" class="form-control" />
                                <label for="ccnum">Credit card number</label>
                                <asp:TextBox runat="server" ID="checkout_credit_num" class="form-control"></asp:TextBox>
                                <label for="cvv">CVV</label>
                                <asp:TextBox runat="server" ID="checkout_credit_cvv" class="form-control"></asp:TextBox>
                                <label for="expmonth">Expiration Date</label>
                                <div class="row">
                                    <div class="form-group col-50">
                                        <asp:DropDownList ID="checkout_payment_month" runat="server" class="form-control">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-50">
                                        <asp:DropDownList ID="checkout_payment_year" runat="server" class="form-control">
                                            <asp:ListItem Value="21">2021</asp:ListItem>
                                            <asp:ListItem Value="22">2022</asp:ListItem>
                                            <asp:ListItem Value="23">2023</asp:ListItem>
                                            <asp:ListItem Value="24">2024</asp:ListItem>
                                            <asp:ListItem Value="25">2025</asp:ListItem>
                                            <asp:ListItem Value="26">2026</asp:ListItem>
                                            <asp:ListItem Value="27">2027</asp:ListItem>
                                            <asp:ListItem Value="28">2028</asp:ListItem>
                                            <asp:ListItem Value="29">2029</asp:ListItem>
                                            <asp:ListItem Value="30">2030</asp:ListItem>
                                            <asp:ListItem Value="31">2031</asp:ListItem>
                                            <asp:ListItem Value="32">2032</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <label>
                            <input type="checkbox" checked="checked" name="sameadr">
                            Shipping address same as billing
                        </label>
                        <asp:Button runat="server" ID="checkout_back" Text="Back" class="btn btn-light" OnClick="checkout_back_Click" />
                        <asp:Button runat="server" ID="checkout_submit" Text="Buy Items" class="btn btn-light" OnClick="checkout_submit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>


</body>
</html>


<style>
    body {
        font-family: Arial;
        font-size: 17px;
        padding: 8px;
    }

    * {
        box-sizing: border-box;
    }

    .row {
        display: -ms-flexbox; /* IE10 */
        display: flex;
        -ms-flex-wrap: wrap; /* IE10 */
        flex-wrap: wrap;
        margin: 0 -16px;
    }

    .col-25 {
        -ms-flex: 25%; /* IE10 */
        flex: 25%;
    }

    .col-50 {
        -ms-flex: 50%; /* IE10 */
        flex: 50%;
    }

    .col-75 {
        -ms-flex: 75%; /* IE10 */
        flex: 75%;
    }

    .col-25,
    .col-50,
    .col-75 {
        padding: 0 16px;
    }

    .container {
        background-color: #f2f2f2;
        padding: 5px 20px 15px 20px;
        border: 1px solid lightgrey;
        border-radius: 3px;
    }

    input[type=text] {
        width: 100%;
        margin-bottom: 20px;
        padding: 12px;
        border: 1px solid #ccc;
        border-radius: 3px;
    }

    label {
        margin-bottom: 10px;
        display: block;
    }

    .icon-container {
        margin-bottom: 20px;
        padding: 7px 0;
        font-size: 24px;
    }

    .btn {
        background-color: #4CAF50;
        color: white;
        padding: 12px;
        margin: 10px 0;
        border: none;
        width: 100%;
        border-radius: 3px;
        cursor: pointer;
        font-size: 17px;
    }

        .btn:hover {
            background-color: #45a049;
        }

    a {
        color: #2196F3;
    }

    hr {
        border: 1px solid lightgrey;
    }

    span.price {
        float: right;
        color: grey;
    }

    #cartContainer{
        width: 250px;
    }

    /* Responsive layout - when the screen is less than 800px wide, make the two columns stack on top of each other instead of next to each other (also change the direction - make the "cart" column go on top) */
    @media (max-width: 800px) {
        .row {
            flex-direction: column-reverse;
        }

        .col-25 {
            margin-bottom: 20px;
        }
    }
</style>
