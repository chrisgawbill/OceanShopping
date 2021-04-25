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
                if(Session["UserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                rpt_Items.Visible = false;
            }
            SellItem.Visible = false;
        }
         
        protected void profile_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void sell_item_Click(object sender, EventArgs e)
        {
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
            String searchInbox = searchTxt.Text;
            String str = "SELECT SenderID, Subject, EmailBody, CreatedTime " +
                "FROM Email WHERE Email.ReceiverID = " + Session["UserID"].ToString() + " " +
                "AND (Subject LIKE '%" + searchInbox + "%' " +
                "OR EmailBody LIKE '%" + searchInbox + "%'" +
                "OR CreatedTime LIKE '%" + searchInbox + "%')";

            DataSet myData = objDB.GetDataSet(str);
            int size = myData.Tables[0].Rows.Count;
            if (size > 0)
            {
                ArrayList inboxList = new ArrayList();
                for (int i = 0; i < size; i++)
                {
                    String senderID = myData.Tables[0].Rows[i]["SenderID"].ToString();
                    String str1 = "SELECT Avatar, UserName, CreatedEmailAddress FROM UserTable WHERE UserTable.UserID = "
                        + senderID + " ";
                    DataSet myData1 = objDB.GetDataSet(str1);

                    /*EmailLibrary.Email emailStuff = new EmailLibrary.Email();
                    emailStuff.SenderName = myData1.Tables[0].Rows[0]["UserName"].ToString();
                    emailStuff.Avatar = myData1.Tables[0].Rows[0]["Avatar"].ToString();
                    emailStuff.Subject = myData.Tables[0].Rows[i]["Subject"].ToString();
                    emailStuff.EmailBody = myData.Tables[0].Rows[i]["EmailBody"].ToString();
                    String timeCreated = myData.Tables[0].Rows[i]["CreatedTime"].ToString();
                    emailStuff.TimeCreated = DateTime.Parse(timeCreated).ToShortDateString();

                    inboxList.Add(emailStuff);*/
                }
            }
            else
            {
                Response.Write("<script>alert('Your search has returned no results.')</script>");
            }
        }
    }
}