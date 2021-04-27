<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="OceanShopping.Cart" %>



<div class="contentContainer" style="margin-left: 330px;">
<div class="content" style="background-color: white; color: black; border-radius: 10px; padding: 10px 10px 10px 10px; margin-right: 330px;">


    <h2>Cart</h2>
    <asp:Repeater ID="rpt_Items" runat="server">
        <ItemTemplate>
            <div class="itemDiv">
                <div class="picture">
                <asp:Image ID="product_image" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Picture") %>' Height="100%" Width="100%" /><hr />
                    </div>
               <strong> <asp:Label ID="product_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label> </strong>
                <hr />
                <p>
                    Price: 
                    <asp:Label ID="product_price" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>'></asp:Label>
                    <hr />
                </p>
                <p>
                    ProductID:
                    <asp:Label ID="product_id" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'></asp:Label>
                    <hr />
                </p>
                <div>
                    <asp:Button ID="product_delete" runat="server" class="btn btn-danger" Text="Delete" OnClick="product_delete_Click" />
                    <hr />
                </div>
            </div>
            <br />
        </ItemTemplate>
    </asp:Repeater>

            <div class="buttons">
        <asp:Button ID="checkout_btn" runat="server" class="btn btn-info" Text="Checkout" OnClick="checkout_Click" />
        <asp:Button ID="cart_back" runat="server" class="btn btn-info" Text="Back" OnClick="cart_back_Click" />
    </div>

    </div>
    </div>

<style>
    .itemDiv {
        width: 75%;
        border: none;
        border-radius: 10px;
        margin-bottom: 2%;
        margin-left: 10%;
    }

    .info {
        width: 80%;
        float: left;
    }

    .clear {
        clear: both;
    }
        .buttons{
        padding-top:10px;
    }
</style>
