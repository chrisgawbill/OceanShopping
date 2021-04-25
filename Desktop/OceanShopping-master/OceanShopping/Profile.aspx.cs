using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OceanShoppingLibrary;

namespace OceanShopping
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            profile_subhead.Style.Add("margin-left", "10%");
            profile_subhead.Style.Add("font-weight", "bold");
            SellItem.Visible = false;
        }

        protected void profile_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void profile_sell_item_Click(object sender, EventArgs e)
        {
            profile_subhead.Text = "Sell Item";
            SellItem.Visible = true;
        }

        protected void profile_wishlist_Click(object sender, EventArgs e)
        {
            rpt_items_other.Visible = false;
            profile_subhead.Text = "Wishlist";
            SellItem.Visible = false;

            ArrayList wishlist = (ArrayList)Session["Wishlist"];
            if (wishlist == null)
            {
                Response.Write("Nothing is in wishlist");
            }
            else
            {
                ItemActions pxy = new ItemActions();
                ArrayList wishlistItems = pxy.GetWishlistItems(wishlist);
                rpt_items_wishlist.DataSource = null;
                rpt_items_wishlist.DataSource = wishlistItems;
                rpt_items_wishlist.DataBind();
                rpt_items_wishlist.Visible = true;
            }
        }

        protected void profile_buying_Click(object sender, EventArgs e)
        {
            profile_subhead.Text = "Buying";
            SellItem.Visible = false;
            rpt_items_wishlist.Visible = false;
            rpt_items_other.Visible = true;
        }

        protected void profile_selling_Click(object sender, EventArgs e)
        {
            profile_subhead.Text = "Selling";
            SellItem.Visible = false;
            rpt_items_wishlist.Visible = false;
            rpt_items_other.Visible = true;


            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            ArrayList sellingItems = pxy.GetSellingItems(userID);

            rpt_items_other.DataSource = null;
            rpt_items_other.DataSource = sellingItems;
            rpt_items_other.DataBind();
            rpt_items_other.Visible = true;
        }

        protected void item_delete_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            RepeaterItem rItem = (RepeaterItem)btn.NamingContainer;

            ArrayList wishlist = (ArrayList)Session["Wishlist"];
            if (wishlist != null)
            {
                Label productIDLabel = (Label)rItem.FindControl("product_id");
                int productID = Int32.Parse(productIDLabel.Text);
                for(int i =0; i < wishlist.Count; i++)
                {
                    if ((int)wishlist[i] == productID)
                    {
                        wishlist.RemoveAt(i);
                    }
                }
                Session["Wishlist"] = wishlist;
                RebindWishlist();
            }
        }
        public void RebindWishlist()
        {
            ArrayList wishlist = (ArrayList)Session["Wishlist"];
            ItemActions pxy = new ItemActions();
            ArrayList wishlistItems = pxy.GetWishlistItems(wishlist);
            rpt_items_wishlist.DataSource = null;
            rpt_items_wishlist.DataSource = wishlistItems;
            rpt_items_wishlist.DataBind();
        }
    }
}