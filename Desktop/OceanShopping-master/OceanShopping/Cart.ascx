<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="OceanShopping.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Cart</h2>
            <asp:Repeater ID="rpt_Items" runat="server">
            <ItemTemplate>
                <div class="itemDiv">
                    <asp:Image ID="product_image" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Picture") %>' Height="150px" Width="100%" />
                    <asp:Label ID="product_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                    <asp:Label ID="product_price" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>'></asp:Label>
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
        </div>
    </form>
</body>
</html>
