<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="OceanShopping.Profile" %>

<%@ Register Src="~/SellItem.ascx" TagPrefix="uc1" TagName="SellItem" %>
<%@ Register Src="~/Cart.ascx" TagPrefix="uc1" TagName="Cart" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Manjari&display=swap" rel="stylesheet">
</head>

<body>
    <form id="form1" runat="server">

    <div id="mySidenav" class="sidenav">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a><br />
        <br />
        <strong><p style="color: white; text-align: center; position: static; padding-top: 5px; padding-bottom: 5px; font-size: 15px; background-color: white; color: black;">Accounts & Lists</p></strong>
        <br />
        <br />
        <br />
        <asp:Button runat="server" ID="profile_back" class="btn btn-light" Text="Homepage" OnClick="profile_back_Click" CausesValidation="false"/><br /><br />
        <asp:Button runat="server" ID="profile_information" class="btn btn-light" Text="Profile Information" OnClick="profile_information_Click" CausesValidation="false"/><br /><br />
        <asp:Button runat="server" ID="profile_wishlist" class="btn btn-light" Text="Wishlist" OnClick="profile_wishlist_Click" CausesValidation="false"/><br /><br />
        <asp:Button runat="server" ID="profile_buying" class="btn btn-light" Text="Buying" OnClick="profile_buying_Click" CausesValidation="false"/><br /><br />
        <asp:Button runat="server" ID="profiel_selling" class="btn btn-light" Text="Selling" OnClick="profile_selling_Click" CausesValidation="false" /><br /><br />
        <asp:Button runat="server" ID="profile_sell_item" class="btn btn-light" Text="Sell Item" OnClick="profile_sell_item_Click"/><br /><br />
        <asp:Button runat="server" ID="profile_cart" class="btn btn-light" Text="Cart" OnClick="profile_cart_Click" CausesValidation="false" /><br /><br />
    </div>
    <span style="font-size:30px;cursor:pointer" onclick="openNav()">&#9776;</span><a class="categories" href="Home.aspx" style="color: white; text-decoration: none;">Ocean</a>

        <div class="main">
            <div class="profileContainer" ID="profileContainer" runat="server" style="margin-left: 330px; margin-top: 150px;">
            <div class="col-md-8">
              <div class="card mb-3">
                <div class="card-body">
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">First Name</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                     <asp:Label ID="firstName" class="navbar-brand" style="color: black; font-size: 32px;" required="required" runat="server" /><br />
                    </div>
                  </div>
                  <hr>
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">Last Name</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                         <asp:Label ID="lastName" class="navbar-brand" style="color: black; font-size: 32px;" required="required" runat="server" /><br />
                    </div>
                  </div>
                  <hr>
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">Email</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                 <asp:Label ID="email" class="navbar-brand" style="color: black; font-size: 32px;" required="required" runat="server" /><br />
                    </div>
                  </div>
                    <hr />
                    <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">UserID</h6>
                    </div>
                    <div class="col-sm-9 text-secondary">
                             <asp:Label ID="userID" class="navbar-brand" style="color: black; font-size: 32px;" required="required" runat="server" /><br />
                    </div>
                  </div>
                </div>
              </div>
                </div>
            </div>

            <!--<asp:Label ID="profile_subhead" runat="server"></asp:Label>-->
            <uc1:SellItem runat="server" ID="SellItem" />
            <uc1:Cart runat="server" ID="Cart" />
            <asp:Repeater ID="rpt_items_wishlist" runat="server">
                <ItemTemplate>
                    <div class="item-main">
                        <div class="item-picture">
                            <asp:Image ID="item_picture" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Picture") %>' Height="100%" Width="100%" />
                        </div>
                        <div class="item-information">
                            <p>
                                Name:
                               
                                <asp:Label ID="item_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                            </p>
                            <p>
                                ProductID:
                               
                                <asp:Label ID="product_id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'></asp:Label>
                            </p>
                            <p>
                                Description:
                               
                                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                            </p>
                            <p>
                                Price:
                               
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>'></asp:Label>
                            </p>
                        </div>
                        <div class="clear"></div>
                        <div id="item_buttons" runat="server">
                            <asp:Button ID="item_delete" class="btn btn-info" runat="server" Text="Delete" OnClick="item_delete_Click" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rpt_items_other" runat="server">
                <ItemTemplate>
                    <div class="item-main">
                        <div class="item-picture">
                            <asp:Image ID="item_picture" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Picture") %>' Height="100%" Width="100%" />
                        </div>
                        <div class="item-information">
                            <p>
                                Name:
                               
                                <asp:Label ID="item_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                            </p>
                            <p>
                                ProductID:
                               
                                <asp:Label ID="product_id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'></asp:Label>
                            </p>
                            <p>
                                Description:
                               
                                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></asp:Label>
                            </p>
                            <p>
                                Price:
                               
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>'></asp:Label>
                            </p>
                        </div>
                        <div class="clear"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
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

        body{
         font-family: 'Manjari', sans-serif;
                 margin-left: 10px;
        background-color: #64DFDF;
        }

    #profile-head {
        text-align: center;
    }

    .categories {
        font-size: 32px;
        margin-left: 35px;
        text-decoration: none;
    }

    .item-main {
        width: 75%;
        border: solid;
        border-radius: 10px;
        margin-bottom: 2%;
        margin-left: 10%;
    }

    .item-picture {
        width: 20%;
        height: 100%;
        float: right;
        border-radius: 10px;
    }

    .item_information {
        width: 80%;
        float: left;
    }

    .clear {
        clear: both;
    }

    .item-main{
        background-color: white;
    }


.sidenav {
  height: 100%;
  width: 0;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: white;
  overflow-x: hidden;
  transition: 0.5s;
  padding-top: 60px;
}

.sidenav a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 25px;
  color: #64DFDF;
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

    #profile_back{
        background-color: white;
        color: black;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profile_information{
        background-color: white;
        color: black;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profile_wishlist {
        background-color: white;
        color: black;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profile_buying {
        background-color: white;
        color: black;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profiel_selling {
        background-color: white;
        color: black;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profile_sell_item {
        background-color: white;
        color: black;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profile_cart{
        background-color:white;
        color: black;
        border-style: none;
        transition-duration: 0.4s;
    }

    #profile_back:hover {
        background-color: #64DFDF;
        color: white;
                border-style: none;
    }

    #profile_information:hover {
        background-color: #64DFDF;
        color: white;
                border-style: none;
    }

    #profile_wishlist:hover {
        background-color: #64DFDF;
        color: white;
                border-style: none;
    }

    #profile_buying:hover {
        background-color: #64DFDF;
        color: white;
                border-style: none;
    }

    #profiel_selling:hover {
       background-color: #64DFDF;
        color: white;
                border-style: none;
    }

    #profile_sell_item:hover {
        background-color: #64DFDF;
        color: white;
                border-style: none;
    }

       #profile_cart:hover {
        background-color: #64DFDF;
        color: white;
                border-style: none;
    }

    #profile_cart:hover {
       background-color: #64DFDF;
        color: white;
        border-style: none;
    }
</style>
