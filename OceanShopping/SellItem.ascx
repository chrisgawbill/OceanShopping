<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SellItem.ascx.cs" Inherits="OceanShopping.SellItem" %>



<div class="contentContainer" style="margin-left: 375px;">
<div class="content" style="background-color: #0096C7; color: white; border-radius: 15px; padding: 10px 10px 10px 10px; margin-right: 375px;">

    <div class="row">
        <div class="form-group col-md-8">
            <p>
                Name:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemName"></asp:TextBox>
            </p>
            <asp:RequiredFieldValidator runat="server" ID="sell_req_itemName" ControlToValidate="sell_itemName" ErrorMessage="Please enter the name of the item you are selling" ForeColor="Red" />
        </div>
        </div>

        <div class="form-group col-md-8">
            <p>
                Description:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemDescription" TextMode="MultiLine"></asp:TextBox>
            </p>
            <asp:RequiredFieldValidator runat="server" ID="sell_req_itemDescription" ControlToValidate="sell_itemDescription" ErrorMessage="Please enter a description for the item you are selling" ForeColor="Red" />
        </div>

        <div class="form-group col-md-8">
            <p>
                Picture:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemPicture"></asp:TextBox>
            </p>
            <asp:RequiredFieldValidator runat="server" ID="sell_req_itemPicture" ControlToValidate="sell_itemPicture" ErrorMessage="Please enter a link to a picture of the item you are selling" ForeColor="Red" />
        </div>

        <div class="form-group col-md-8">
            <p>
                Category:   
                <asp:DropDownList runat="server" class="form-control" ID="sell_itemCategory">
                    <asp:ListItem>Technology</asp:ListItem>
                    <asp:ListItem>Fashion</asp:ListItem>
                    <asp:ListItem>Gardening</asp:ListItem>
                    <asp:ListItem>Household Items</asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>

        <div class="form-group col-md-8">
            <p>
                Price:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemPrice"></asp:TextBox>
            </p>
            <asp:RequiredFieldValidator runat="server" ID="sell_req_itemPrice" ControlToValidate="sell_itemPrice" ErrorMessage="Please enter a price for the item you are selling" ForeColor="Red" />
        </div>

    <div>
        <asp:Button runat="server" ID="sell_itemCancel" class="btn btn-light" Text="Cancel" OnClick="sell_itemCancel_Click" CausesValidation="false" />
        <asp:Button runat="server" ID="sell_itemSubmit" class="btn btn-light" Text="Sell" OnClick="sell_itemSubmit_Click" CausesValidation="true" />
    </div>
</div>
    </div>

<style>
    content{
        background-color: #0096C7;
        color: white;
    }
</style>