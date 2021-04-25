<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OceanShopping.Home" %>

<%@ Register Src="~/SellItem.ascx" TagPrefix="uc1" TagName="SellItem" %>
<%@ Register Src="~/Cart.ascx" TagPrefix="uc2" TagName="Cart" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <style>
        .itemDiv {
            height: 25%;
            width: 10%;
            float: left;
            margin-top: 2%;
            border: solid;
            border-radius: 10px;
        }

        .main {
            width: 50%;
            margin: 50px auto;
            margin-top:20%;
        }


        .has-search .form-control {
            padding-left: 2.375rem;
        }

        .has-search .form-control-feedback {
            position: absolute;
            z-index: 2;
            display: block;
            width: 2.375rem;
            height: 2.375rem;
            line-height: 2.375rem;
            text-align: center;
            pointer-events: none;
            color: #aaa;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="navigation">
            <nav class="navbar navbar-dark bg-dark">
                <asp:Button runat="server" ID="profile_button" class="btn btn-light" Text="Profile" OnClick="profile_button_Click" />
                <asp:Button runat="server" ID="login_button" class="btn btn-light" Text="Login" OnClick="login_button_Click" />
                <asp:Button runat="server" ID="sell_item" class="btn btn-light" Text="Sell Item" OnClick="sell_item_Click" />
                <asp:Button runat="server" ID="home_cart" class="btn btn-light" Text="Cart" OnClick="cart_Click">
                </asp:Button>
                <span class="glyphicon glyphicon-shopping-cart"></span>Cart
            </nav>
        </div>

        <div class="main" runat="server" id="test_main">
            <div>
                <div>
                    <h2>Categories</h2>
                    <asp:Button ID="category_technology" class="btn btn-info" runat="server" OnClick="category_technology_Click" Text="Technology" />
                    <asp:Button ID="category_fashion" class="btn btn-info" runat="server" OnClick="category_fashion_Click" Text="Fashion" />
                    <asp:Button ID="category_gardening" class="btn btn-info" runat="server" OnClick="category_gardening_Click" Text="Gardening" />
                    <asp:Button ID="category_householdItems" class="btn btn-info" runat="server" OnClick="category_householdItems_Click" Text="Household Items" />
                    <asp:Button ID="category_music" class="btn btn-info" runat="server" OnClick="category_music_Click" Text="Music" />
                </div>
            </div>
            <br />


            <div class="searchItm">
                <div class="input-group">
                    <asp:TextBox ID="searchTxt" class="form-control" placeholder="Search..." runat="server" />
                    <div class="input-group-append">
                        <asp:Button ID="btnSearch" type="button" class="btn btn-primary" runat="server" OnClick="btnSearch_Click">     
                        </asp:Button>
                    </div>
                </div>
            </div>
        </div>

        <br />
        <uc1:SellItem runat="server" ID="SellItem" />
        <uc2:Cart runat="server" id="Cart" />
        <asp:Repeater ID="rpt_Items" runat="server">
            <ItemTemplate>
                <div class="itemDiv">
                    <asp:Image ID="product_image" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Picture") %>' Height="150px" Width="100%" />
                    <asp:Label ID="product_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                    <asp:Label ID="product_price" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>'></asp:Label>
                    <p>
                                Description:
                                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                    </p>
                    <p>
                        ProductID:
                    <asp:Label ID="product_id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'></asp:Label>
                    </p>
                    <div>
                        <asp:Button ID="product_wishlist" runat="server" Text="Wishlist" OnClick="product_wishlist_Click" />
                        <asp:Button ID="product_cart" runat="server" Text="Cart" OnClick="product_cart_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <br />


    </form>
</body>
</html>
