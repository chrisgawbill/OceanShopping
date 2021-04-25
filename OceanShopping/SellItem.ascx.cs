using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OceanShoppingLibrary;

namespace OceanShopping
{
    public partial class SellItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sell_itemCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void sell_itemSubmit_Click(object sender, EventArgs e)
        {
            Item tempItem = getItemDetails();
            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            int result = pxy.sellItem(userID, tempItem);

            if(result != -1)
            {
                Response.Write("Item Listed!");
            }
            else
            {
                Response.Write("Problem Occured When Listing Your Item");
            }
        }
        public Item getItemDetails()
        {
            string name = sell_itemName.Text;
            string description = sell_itemDescription.Text;
            string picture = sell_itemPicture.Text;
            string category = sell_itemCategory.Text;
            Decimal price = Decimal.Parse(sell_itemPrice.Text);

            Item tempItem = new Item();
            tempItem.Name = name;
            tempItem.Description = description;
            tempItem.Picture = picture;
            tempItem.Category = category;
            tempItem.Price = price;

            return tempItem;
        }
    }
}