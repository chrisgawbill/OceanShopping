using OceanShoppingLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OceanShopping
{
    public partial class Home : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showAccountDetails();
                if (Session["UserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                rpt_Items.Visible = false;
            }
            test_main.Visible = true;
            SellItem.Visible = false;
            Cart.Visible = false;
        }

        public void showAccountDetails()
        {
            UserName.Text = Session["First Name"].ToString();
        }
         
        protected void profile_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void sell_item_Click(object sender, EventArgs e)
        {
            Cart.Visible = false;
            SellItem.Visible = true;
        }

        protected void category_technology_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            ArrayList tempItemList = pxy.getCategoryItems(userID, "Technology");

            rpt_Items.DataSource = null;
            rpt_Items.DataSource = tempItemList;
            rpt_Items.DataBind();
            rpt_Items.Visible = true;

            test_main.Style.Add("margin-top", "5%");

        }

        protected void category_fashion_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            ArrayList tempItemList = pxy.getCategoryItems(userID, "Fashion");

            rpt_Items.DataSource = null;
            rpt_Items.DataSource = tempItemList;
            rpt_Items.DataBind();
            rpt_Items.Visible = true;

            test_main.Style.Add("margin-top", "5%");
        }

        protected void category_gardening_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            ArrayList tempItemList = pxy.getCategoryItems(userID, "Gardening");

            rpt_Items.DataSource = null;
            rpt_Items.DataSource = tempItemList;
            rpt_Items.DataBind();
            rpt_Items.Visible = true;

            test_main.Style.Add("margin-top", "5%");
        }

        protected void category_householdItems_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            ArrayList tempItemList = pxy.getCategoryItems(userID, "Household Items");

            rpt_Items.DataSource = null;
            rpt_Items.DataSource = tempItemList;
            rpt_Items.DataBind();
            rpt_Items.Visible = true;

            test_main.Style.Add("margin-top", "5%");
        }

        protected void searchBar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void category_music_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            ArrayList tempItemList = pxy.getCategoryItems(userID, "Music");

            rpt_Items.DataSource = null;
            rpt_Items.DataSource = tempItemList;
            rpt_Items.DataBind();
            rpt_Items.Visible = true;
        }

        protected void product_wishlist_Click(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem rItem = (RepeaterItem)btn.NamingContainer;

            ArrayList wishlist =(ArrayList)Session["Wishlist"];
            if(wishlist == null)
            {
                wishlist = new ArrayList();
            }
            Label productIDLabel = (Label)rItem.FindControl("product_id");
            int productID = Int32.Parse(productIDLabel.Text);
            wishlist.Add(productID);
            byte[] byteWishlist = SerializeItem(wishlist);
            int userID = Int32.Parse(Session["UserID"].ToString());

            ItemActions pxy = new ItemActions();
            int result = pxy.StoreWishlist(userID, byteWishlist);
            if(result != -1)
            {
                Session["Wishlist"] = wishlist;
                Response.Write("<script>alert('Item was sucesffully added to wishlist')</script>");
            }
            else
            {
                Response.Write("<script>alert('Something went wrong when adding item to wishlist')</script>");
            }
        }

        protected void product_cart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem rItem = (RepeaterItem)btn.NamingContainer;

            ArrayList cart = (ArrayList)Session["Cart"];
            if (cart == null)
            {
                cart = new ArrayList();
            }
            Label productIDLabel = (Label)rItem.FindControl("product_id");
            int productID = Int32.Parse(productIDLabel.Text);
            cart.Add(productID);
            byte[] byteCart = SerializeItem(cart);
            int userID = Int32.Parse(Session["UserID"].ToString());

            ItemActions pxy = new ItemActions();
            int result = pxy.StoreCart(userID, byteCart);
            if (result != -1)
            {
                Session["Cart"] = cart;
                Response.Write("<script>alert('Item was sucesffully added to cart')</script>");
            }
            else
            {
                Response.Write("<script>alert('Something went wrong when adding item to cart')</script>");
            }
        }

        public byte[] SerializeItem(ArrayList list)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, list);
            byte[] byteListArray;
            byteListArray = memStream.ToArray();

            return byteListArray;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ItemActions pxy = new ItemActions();
            int userID = Int32.Parse(Session["UserID"].ToString());
            string searchTerm = searchTxt.Text;
                  
            ArrayList array = pxy.GetSearchItems(userID, searchTerm);
            rpt_Items.DataSource = null;
            rpt_Items.DataSource = array;
            rpt_Items.DataBind();
        }

        protected void cart_Click(object sender, EventArgs e)
        {
            SellItem.Visible = false;
            test_main.Visible = false;
            rpt_Items.Visible = false;
            Cart.Visible = true;
            Cart.Refresh();
        }

    }
}