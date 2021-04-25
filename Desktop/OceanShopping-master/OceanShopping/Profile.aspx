<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="OceanShopping.Profile" %>

<%@ Register Src="~/SellItem.ascx" TagPrefix="uc1" TagName="SellItem" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <style>
        #profile-head {
            text-align: center;
        }

        .item-main {
            width: 75%;
            border: solid;
            border-radius:10px;
            margin-bottom:2%;
            margin-left:10%;
        }

        .item-picture {
            width: 20%;
            height:100%;
            float: right;
            border-radius:10px;
        }

        .item_information {
            width: 80%;
            float: left;
        }

        .clear {
            clear: both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navigation">
            <nav class="navbar navbar-dark bg-dark">
                <asp:Button runat="server" ID="profile_back" class="btn btn-light" Text="Back" OnClick="profile_back_Click" />
                <asp:Button runat="server" ID="profile_wishlist" class="btn btn-light" Text="Wishlist" OnClick="profile_wishlist_Click" />
                <asp:Button runat="server" ID="profile_buying" class="btn btn-light" Text="Buying" OnClick="profile_buying_Click" />
                <asp:Button runat="server" ID="profile_selling" class="btn btn-light" Text="Selling" OnClick="profile_selling_Click" />
                <asp:Button runat="server" ID="profile_sell_item" class="btn btn-light" Text="Sell Item" OnClick="profile_sell_item_Click" />
                <a href="#" class="btn btn-info btn-lg">
                    <span class="glyphicon glyphicon-shopping-cart"></span>Cart
            </a>
            </nav>
        </div>
        <div class="main">
            <h1 id="profile-head">Profile</h1>
            <asp:Label ID="profile_subhead" runat="server"></asp:Label>
            <uc1:SellItem runat="server" ID="SellItem" />
            <asp:Repeater ID="rpt_items_wishlist" runat="server">
                <ItemTemplate>
                    <div class="item-main">
                         <div class="item-picture">
                            <asp:Image ID="item_picture" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Picture") %>'  Height="100%" Width="100%"/>
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
                            <asp:Button ID="item_delete" class="btn btn-light" runat="server" Text="Delete" OnClick="item_delete_Click" />
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
</body>
</html>
