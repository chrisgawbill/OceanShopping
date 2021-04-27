<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SellItem.ascx.cs" Inherits="OceanShopping.SellItem" %>



<div class="contentContainer" style="margin-left: 375px;">
<div class="content" style="background-color: white; color: black; border-radius: 15px; padding: 50px 50px 50px 50px; margin-right: 375px;">

    <div class="row">
        <div class="form-group col-md-8">

            <strong><h3 style="text-align:center; margin-left: 200px;">Looking to sell?</h3><br /><br /></strong>
            <p>
                Name:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemName"></asp:TextBox>
            </p><hr />
            <asp:RequiredFieldValidator runat="server" ID="sell_req_itemName" ControlToValidate="sell_itemName" ErrorMessage="Please enter the name of the item you are selling" ForeColor="Red" />
        </div>
        </div>

        <div class="form-group col-md-8">
            <p>
                Description:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemDescription" TextMode="MultiLine"></asp:TextBox>
            </p><hr />
            <asp:RequiredFieldValidator runat="server" ID="sell_req_itemDescription" ControlToValidate="sell_itemDescription" ErrorMessage="Please enter a description for the item you are selling" ForeColor="Red" />
        </div>

        <div class="form-group col-md-8">
            <p>
                Picture:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemPicture"></asp:TextBox>
            </p><hr />
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
                     <asp:ListItem>Music</asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>

        <div class="form-group col-md-8">
            <p>
                Price:
       
                <asp:TextBox runat="server" class="form-control" ID="sell_itemPrice"></asp:TextBox>
            </p><hr />
            <asp:RequiredFieldValidator runat="server" ID="sell_req_itemPrice" ControlToValidate="sell_itemPrice" ErrorMessage="Please enter a price for the item you are selling" ForeColor="Red" />
        </div>

    <div>
        <asp:Button runat="server" ID="sell_itemSubmit" class="btn btn-info" Text="Sell" OnClick="sell_itemSubmit_Click" CausesValidation="true" />
        <asp:Button runat="server" ID="sell_itemCancel" class="btn btn-danger" Text="Cancel" OnClick="sell_itemCancel_Click" CausesValidation="false" />
    </div>
</div>
    </div>

<style>
    content{
        background-color: #0096C7;
        color: white;
        font-size: 15px;
        text-align: center;
    }

    content img{
        border-style: solid;
        border-color: black;
    }

</style>