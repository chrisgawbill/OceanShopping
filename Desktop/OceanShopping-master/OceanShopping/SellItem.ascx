<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SellItem.ascx.cs" Inherits="OceanShopping.SellItem" %>
<div>
    <p>Name:
        <asp:TextBox runat="server" ID="sell_itemName"></asp:TextBox></p>
        <asp:RequiredFieldValidator runat="server" ID="sell_req_itemName" ControlToValidate="sell_itemName" ErrorMessage="Please enter the name of the item you are selling" ForeColor="Red" />
    <p>Description:
        <asp:TextBox runat="server" ID="sell_itemDescription" TextMode="MultiLine"></asp:TextBox></p>
        <asp:RequiredFieldValidator runat="server" ID="sell_req_itemDescription" ControlToValidate="sell_itemDescription" ErrorMessage="Please enter a description for the item you are selling" ForeColor="Red" />
    <p>Picture:
        <asp:TextBox runat="server" ID="sell_itemPicture"></asp:TextBox></p>
        <asp:RequiredFieldValidator runat="server" ID="sell_req_itemPicture" ControlToValidate="sell_itemPicture" ErrorMessage="Please enter a link to a picture of the item you are selling" ForeColor="Red" />
    <p>
        Category:
        <asp:DropDownList runat="server" ID="sell_itemCategory">
            <asp:ListItem>Technology</asp:ListItem>
            <asp:ListItem>Fashion</asp:ListItem>
            <asp:ListItem>Gardening</asp:ListItem>
            <asp:ListItem>Household Items</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>Price:
        <asp:TextBox runat="server" ID="sell_itemPrice"></asp:TextBox></p>
        <asp:RequiredFieldValidator runat="server" ID="sell_req_itemPrice" ControlToValidate="sell_itemPrice" ErrorMessage="Please enter a price for the item you are selling" ForeColor="Red" />
</div>
<div>
    <asp:Button runat="server" ID="sell_itemCancel" Text="Cancel" OnClick="sell_itemCancel_Click" CausesValidation="false"/>
    <asp:Button runat="server" ID="sell_itemSubmit" Text="Sell" OnClick="sell_itemSubmit_Click" CausesValidation="true"/>
</div>