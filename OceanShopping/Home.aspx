<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OceanShopping.Home" %>

<%@ Register Src="~/SellItem.ascx" TagPrefix="uc1" TagName="SellItem" %>
<%@ Register Src="~/Cart.ascx" TagPrefix="uc2" TagName="Cart" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Manjari&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">

        <div id="mySidenav" class="sidenav">
            <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a><br />
            <br />
            <strong>
                <p style="color: white; text-align: center; position: static; padding-top: 5px; padding-bottom: 5px; font-size: 15px; background-color: white; color: black;">Homepage</p>
            </strong>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button runat="server" ID="profile_button" class="btn btn-light" Text="Profile" OnClick="profile_button_Click" /><br />
            <br />
            <asp:Button runat="server" ID="sell_item" class="btn btn-light" Text="Sell Item" OnClick="sell_item_Click" /><br />
            <br />
            <asp:Button runat="server" ID="home_cart" class="btn btn-light" Text="Cart" OnClick="cart_Click"></asp:Button><br />
            <br />
            <asp:Button runat="server" ID="login_button" class="btn btn-light" Text="Logout" OnClick="login_button_Click" /><br />
            <br />
        </div>

        <span style="font-size: 30px; cursor: pointer" onclick="openNav()">&#9776;</span><a class="introduction" style="color: black;">Welcome back,   </a>
        <asp:Label ID="UserName" class="navbar-brand" Style="color: black; font-size: 32px;" required="required" runat="server" />

        <div class="main" runat="server" id="test_main">
            <div>
                <div>
                    <h2 style="color: white;">Categories</h2>
                    <asp:Button ID="category_technology" class="btn btn-light" runat="server" OnClick="category_technology_Click" Text="Technology" />
                    <asp:Button ID="category_fashion" class="btn btn-light" runat="server" OnClick="category_fashion_Click" Text="Fashion" />
                    <asp:Button ID="category_gardening" class="btn btn-light" runat="server" OnClick="category_gardening_Click" Text="Gardening" />
                    <asp:Button ID="category_householdItems" class="btn btn-light" runat="server" OnClick="category_householdItems_Click" Text="Household Items" />
                    <asp:Button ID="category_music" class="btn btn-light" runat="server" OnClick="category_music_Click" Text="Music" />
                </div>
            </div>
            <br />


            <div class="searchItm">
                <div class="input-group">
                    <div class="input-group-append">
                        <asp:TextBox ID="searchTxt" class="form-control" placeholder="Explore our endless products!" runat="server" />
                        <div class="input-group-append">
                           <asp:Button ID="btnSearch" type="button" class="btn btn-dark" Text="Search" runat="server" OnClick="btnSearch_Click" />
                        </div>
        </div>
        </div>
            </div>
        </div>



        <br />
        <uc1:SellItem runat="server" ID="SellItem" />
        <uc2:Cart runat="server" ID="Cart" />
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

    <script>
        function openNav() {
            document.getElementById("mySidenav").style.width = "250px";
        }

        function closeNav() {
            document.getElementById("mySidenav").style.width = "0";
        }
   </script>

</body>
</html>

<style>
    body {
        font-family: 'Manjari', sans-serif;
        margin-left: 10px;
  background-color: white;
    }

    .introduction {
        font-size: 32px;
        margin-left: 35px;
        text-decoration: none;
    }

    .itemDiv {
        height: 25%;
        width: 10%;
        float: left;
        margin-top: 2%;
        border: solid;
        border-radius: 10px;
    }

    #searchTxt{
        width: 575px;
    }

    .main {
        width: 50%;
        margin: 50px auto;
        margin-top: 17%;
        background-color: #0096C7;
        padding: 25px 25px 25px 25px;
        border-radius: 15px;
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

    .sidenav {
        height: 100%;
        width: 0;
        position: fixed;
        z-index: 1;
        top: 0;
        left: 0;
        background-color: #0096C7;
        overflow-x: hidden;
        transition: 0.5s;
        padding-top: 60px;
    }

        .sidenav a {
            padding: 8px 8px 8px 32px;
            text-decoration: none;
            font-size: 25px;
            color: white;
            display: block;
            transition: 0.3s;
        }

            .sidenav a:hover {
                color: #f1f1f1;
            }

        .sidenav .closebtn {
            position: absolute;
            top: 0;
            right: 25px;
            font-size: 36px;
            margin-left: 50px;
        }

    #profile_button {
        background-color: #0096C7;
        color: white;
        border-style: none;
        transition-duration: 0.4s;
    }

    #login_button {
        background-color: #0096C7;
        color: white;
        border-style: none;
        transition-duration: 0.4s;
    }

    #sell_item {
        background-color: #0096C7;
        color: white;
        border-style: none;
        transition-duration: 0.4s;
    }

    #home_cart {
        background-color: #0096C7;
        color: white;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profile_button:hover {
        background-color:  white;
        color: black;
        border-style: none;
    }

    #login_button:hover {
        background-color:  white;
        color:  black;
        border-style: none;
    }

    #sell_item:hover {
        background-color:  white;
        color:  black;
        border-style: none;
    }

    #home_cart:hover {
        background-color:  white;
        color:  black;
        border-style: none;
    }

    @media screen and (max-height: 450px) {
        .sidenav {
            padding-top: 15px;
        }

            .sidenav a {
                font-size: 18px;
            }
    }
</style>
