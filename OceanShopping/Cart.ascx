<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="OceanShopping.Cart" %>



<div class="contentContainer" style="margin-left: 330px;">
<div class="content" style="background-color: white; color: black; border-radius: 10px; padding: 10px 10px 10px 10px; margin-right: 330px;">


    <h2>Cart</h2>
    <asp:Repeater ID="rpt_Items" runat="server">
        <ItemTemplate>
            <div class="itemDiv">
                <asp:Image ID="product_image" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Picture") %>' Height="150px" Width="100%" />
                <asp:Label ID="product_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                <p>
                    Price: 
                    <asp:Label ID="product_price" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>'></asp:Label>
                </p>
                <p>
                    ProductID:
                    <asp:Label ID="product_id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'></asp:Label>
                </p>
                <div>
                    <asp:Button ID="product_delete" runat="server" class="btn btn-light" Text="Delete" OnClick="product_delete_Click" />
                </div>
            </div>
            <br />
        </ItemTemplate>
    </asp:Repeater>

            <div class="buttons">
        <asp:Button ID="checkout_btn" runat="server" class="btn btn-light" Text="Checkout" OnClick="checkout_Click" />
        <asp:Button ID="cart_back" runat="server" class="btn btn-light" Text="Back" OnClick="cart_back_Click" />
    </div>

    </div>
    </div>

<style>
    .itemDiv{
       padding-right: 750px;
       padding-bottom: 50px;
       border-style: none;

    }

    .itemDiv img{
        float: right;
        padding-bottom: 50px 50px 50px 50px;
    }

    .buttons{
        padding-top:10px;
    }
</style>
