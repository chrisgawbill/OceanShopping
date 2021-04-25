using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using OceanShoppingLibrary;
using Utilities;

namespace OceanShopping
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ItemActions : System.Web.Services.WebService
    {
        //Web Method that adds an item to the Items table through a procedure. This returns an int which is then used to determine if the operation failed or not.
        [WebMethod]
        public int sellItem(int sellerID, Item tempItem)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "OceanAddItem";
            objCommand.Parameters.AddWithValue("@sellerID", sellerID);
            objCommand.Parameters.AddWithValue("@itemName", tempItem.Name);
            objCommand.Parameters.AddWithValue("@itemDescription", tempItem.Description);
            objCommand.Parameters.AddWithValue("@itemPicture", tempItem.Picture);
            objCommand.Parameters.AddWithValue("@category", tempItem.Category);
            objCommand.Parameters.AddWithValue("@price", tempItem.Price);

            DBConnect db = new DBConnect();
            int result = db.DoUpdateUsingCmdObj(objCommand);
            ;
            return result;
        }
        //Web Method that returns all items that the user is not selling. Returns an arraylist of Items.
        [WebMethod]
        public ArrayList getAllItems(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetAllItems";
            objCommand.Parameters.AddWithValue("@userID", userID);
            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if (myData.Tables[0].Rows.Count > 0)
            {
                ArrayList tempItemList = new ArrayList();

                for (int i = 0; i < myData.Tables[0].Rows.Count; i++)
                {
                    DataRow row = myData.Tables[0].Rows[i];

                    int itemID = Int32.Parse(row["ItemID"].ToString());
                    int sellerID = Int32.Parse(row["sellerID"].ToString());
                    string name = row["itemName"].ToString();
                    string description = row["itemDescription"].ToString();
                    string picture = row["itemPicture"].ToString();
                    string category = row["category"].ToString();
                    Decimal price = Decimal.Parse(row["price"].ToString());
                    int buyerID = Int32.Parse(row["buyerID"].ToString());

                    Item tempItem = new Item();
                    tempItem.ItemID = itemID;
                    tempItem.SellerID = sellerID;
                    tempItem.Name = name;
                    tempItem.Description = description;
                    tempItem.Picture = picture;
                    tempItem.Category = category;
                    tempItem.Price = price;
                    tempItem.BuyerID = buyerID;

                    tempItemList.Add(tempItem);
                }
                return tempItemList;
            }
            return null;
        }
        //Web Method that returns items based on a category. The procedure returns all items that matches category name, items that have a buyerID of NULL, and items that the user
        //is not selling. This method then returns an arraylist of Items.
        [WebMethod]
        public ArrayList getCategoryItems(int userID, string itemCategory)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetCategoryItems";
            objCommand.Parameters.AddWithValue("@userID", userID);
            objCommand.Parameters.AddWithValue("@category", itemCategory);
            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if (myData.Tables[0].Rows.Count > 0)
            {
                ArrayList tempItemList = new ArrayList();

                for (int i = 0; i < myData.Tables[0].Rows.Count; i++)
                {
                    DataRow row = myData.Tables[0].Rows[i];

                    if(row["buyerID"].ToString().Equals(""))
                    {
                        int itemID = Int32.Parse(row["ItemID"].ToString());
                        int sellerID = Int32.Parse(row["sellerID"].ToString());
                        string name = row["itemName"].ToString();
                        string description = row["itemDescription"].ToString();
                        string picture = row["itemPicture"].ToString();
                        string category = row["category"].ToString();
                        Decimal price = Decimal.Parse(row["price"].ToString());


                        Item tempItem = new Item();
                        tempItem.ItemID = itemID;
                        tempItem.SellerID = sellerID;
                        tempItem.Name = name;
                        tempItem.Description = description;
                        tempItem.Picture = picture;
                        tempItem.Category = category;
                        tempItem.Price = price;

                        tempItemList.Add(tempItem);
                    }
                }
                return tempItemList;
            }
            return null;
        }
        //Web Method used to get items that the user is selling. The procedure looks for sellerID that matches userID given and returns a DataSet of items.
        //This method returns an arraylist of Items.
        [WebMethod]
        public ArrayList getUserItems(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetUserItems";
            objCommand.Parameters.AddWithValue("@userID", userID);
            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if (myData.Tables[0].Rows.Count > 0)
            {
                ArrayList tempItemList = new ArrayList();

                for (int i = 0; i < myData.Tables[0].Rows.Count; i++)
                {
                    DataRow row = myData.Tables[0].Rows[i];

                    int sellerID = Int32.Parse(row["sellerID"].ToString());
                    string name = row["itemName"].ToString();
                    string description = row["itemDescription"].ToString();
                    string picture = row["itemPicture"].ToString();
                    string category = row["category"].ToString();
                    Decimal price = Decimal.Parse(row["price"].ToString());
                    int buyerID = Int32.Parse(row["buyerID"].ToString());

                    Item tempItem = new Item();
                    tempItem.SellerID = sellerID;
                    tempItem.Name = name;
                    tempItem.Description = description;
                    tempItem.Picture = picture;
                    tempItem.Category = category;
                    tempItem.Price = price;
                    tempItem.BuyerID = buyerID;

                    tempItemList.Add(tempItem);
                }
                return tempItemList;
            }
            return null;
        }
        //Web Method used to get some user info based on the userID
        [WebMethod]
        public User getSellerInfo(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetUser";
            objCommand.Parameters.AddWithValue("@userID", userID);
            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if (myData.Tables[0].Rows.Count > 0)
            {
                DataRow row = myData.Tables[0].Rows[0];

                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                string email = row["email"].ToString();

                User tempUser = new User();
                tempUser.FirstName = firstName;
                tempUser.LastName = lastName;
                tempUser.Email = email;
                return tempUser;
            }
            return null;
        }
        //Web Method used to get some user info based on the userID
        [WebMethod]
        public User getBuyerInfo(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetUser";
            objCommand.Parameters.AddWithValue("@userID", userID);
            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if (myData.Tables[0].Rows.Count > 0)
            {
                DataRow row = myData.Tables[0].Rows[0];

                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();

                User tempUser = new User();
                tempUser.FirstName = firstName;
                tempUser.LastName = lastName;

                return tempUser;
            }
            return null;
        }
        // Web Method used to store a serialized wishlist arraylist
        [WebMethod]
        public int StoreWishlist(int userID, byte[] wishlist)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanUpdateWishlist";
            objCommand.Parameters.AddWithValue("@userID", userID);
            objCommand.Parameters.AddWithValue("@wishlist", wishlist);

            DBConnect db = new DBConnect();
            int result = db.DoUpdateUsingCmdObj(objCommand);
            return result;
        }
        //Web Method used to store a serialized cart arraylist
        [WebMethod]
        public int StoreCart(int userID, byte[] cart)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanUpdateCart";
            objCommand.Parameters.AddWithValue("@userID", userID);
            objCommand.Parameters.AddWithValue("@cart", cart);

            DBConnect db = new DBConnect();
            int result = db.DoUpdateUsingCmdObj(objCommand);
            return result;
        }
        //Web Method used to getting items in wishlist. We get the deserialized wishlist array and go through and get the itemID stored in it. We then use that itemID to retrieve 
        //the item from the Items table.
        [WebMethod]
        public ArrayList GetWishlistItems(ArrayList wishlist)
        {
            ArrayList wishlistItems = new ArrayList();

            for(int i = 0; i < wishlist.Count; i++)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "OceanGetItem";
                objCommand.Parameters.AddWithValue("@itemID", wishlist[i]);

                DBConnect db = new DBConnect();
                DataSet myData = db.GetDataSetUsingCmdObj(objCommand);
                if (myData.Tables[0].Rows.Count > 0)
                { 
                    DataRow row = myData.Tables[0].Rows[0];

                    int itemID = Int32.Parse(row["ItemID"].ToString());
                    int sellerID = Int32.Parse(row["sellerID"].ToString());
                    string name = row["itemName"].ToString();
                    string description = row["itemDescription"].ToString();
                    string picture = row["itemPicture"].ToString();
                    string category = row["category"].ToString();
                    Decimal price = Decimal.Parse(row["price"].ToString());

                    Item tempItem = new Item();
                    tempItem.ItemID = itemID;
                    tempItem.SellerID = sellerID;
                    tempItem.Name = name;
                    tempItem.Description = description;
                    tempItem.Picture = picture;
                    tempItem.Category = category;
                    tempItem.Price = price;

                    wishlistItems.Add(tempItem);
                }
            }
            if(wishlist.Count > 0)
            {
                return wishlistItems;
            }
            return null;
        }
        // Web Method used for retrieving items based on search. Uses UserID to make sure we are not showing items user is selling. Returns an arraylist of Items
        [WebMethod]
        public ArrayList GetSearchItems(int userID, string searchTerm)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetSearchItems";
            objCommand.Parameters.AddWithValue("@userID", userID);
            objCommand.Parameters.AddWithValue("@searchTerm", searchTerm);

            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if(myData.Tables[0].Rows.Count > 0)
            {
                ArrayList tempItemList = new ArrayList();

                for(int i = 0; i < myData.Tables[0].Rows.Count; i++)
                {
                    DataRow row = myData.Tables[0].Rows[i];
                    int itemID = Int32.Parse(row["ItemID"].ToString());
                    int sellerID = Int32.Parse(row["sellerID"].ToString());
                    string name = row["itemName"].ToString();
                    string description = row["itemDescription"].ToString();
                    string picture = row["itemPicture"].ToString();
                    string category = row["category"].ToString();
                    Decimal price = Decimal.Parse(row["price"].ToString());

                    Item tempItem = new Item();
                    tempItem.ItemID = itemID;
                    tempItem.SellerID = sellerID;
                    tempItem.Name = name;
                    tempItem.Description = description;
                    tempItem.Picture = picture;
                    tempItem.Category = category;
                    tempItem.Price = price;

                    tempItemList.Add(tempItem);
                }
                return tempItemList;
            }
            return null;
        }
        //Web Method that takes a deserialized cart arraylist and returns the items in them
        [WebMethod]
        public ArrayList GetCartItems(ArrayList cart)
        {
            ArrayList cartItems = new ArrayList();

            for (int i = 0; i < cart.Count; i++)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "OceanGetItem";
                objCommand.Parameters.AddWithValue("@itemID", cart[i]);

                DBConnect db = new DBConnect();
                DataSet myData = db.GetDataSetUsingCmdObj(objCommand);
                if (myData.Tables[0].Rows.Count > 0)
                {
                    DataRow row = myData.Tables[0].Rows[0];

                    int itemID = Int32.Parse(row["ItemID"].ToString());
                    int sellerID = Int32.Parse(row["sellerID"].ToString());
                    string name = row["itemName"].ToString();
                    string description = row["itemDescription"].ToString();
                    string picture = row["itemPicture"].ToString();
                    string category = row["category"].ToString();
                    Decimal price = Decimal.Parse(row["price"].ToString());

                    Item tempItem = new Item();
                    tempItem.ItemID = itemID;
                    tempItem.SellerID = sellerID;
                    tempItem.Name = name;
                    tempItem.Description = description;
                    tempItem.Picture = picture;
                    tempItem.Category = category;
                    tempItem.Price = price;

                    cartItems.Add(tempItem);
                }
            }
            if (cart.Count > 0)
            {
                return cartItems;
            }
            return null;
        }
        //Web Method tthat returns an arraylist of items that the user is selling
        [WebMethod]
        public ArrayList GetSellingItems(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetUserSellingItems";
            objCommand.Parameters.AddWithValue("@userID", userID);
            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if(myData.Tables[0].Rows.Count > 0)
            {
                ArrayList tempItemList = new ArrayList();
                for(int i = 0; i < myData.Tables[0].Rows.Count; i++)
                {
                    DataRow row = myData.Tables[0].Rows[i];

                    int itemID = Int32.Parse(row["ItemID"].ToString());
                    int sellerID = Int32.Parse(row["sellerID"].ToString());
                    string name = row["itemName"].ToString();
                    string description = row["itemDescription"].ToString();
                    string picture = row["itemPicture"].ToString();
                    string category = row["category"].ToString();
                    Decimal price = Decimal.Parse(row["price"].ToString());

                    Item tempItem = new Item();
                    tempItem.ItemID = itemID;
                    tempItem.SellerID = sellerID;
                    tempItem.Name = name;
                    tempItem.Description = description;
                    tempItem.Picture = picture;
                    tempItem.Category = category;
                    tempItem.Price = price;

                    tempItemList.Add(tempItem);
                }
                return tempItemList;
            }
            return null;
        }
        //Web Method that returns an arraylist of items that the user has bought
        [WebMethod]
        public ArrayList GetBoughtItems(int userID)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetUserBoughtItems";
            objCommand.Parameters.AddWithValue("@userID", userID);
            DBConnect db = new DBConnect();
            DataSet myData = db.GetDataSetUsingCmdObj(objCommand);

            if (myData.Tables[0].Rows.Count > 0)
            {
                ArrayList tempItemList = new ArrayList();
                for (int i = 0; i < myData.Tables[0].Rows.Count; i++)
                {
                    DataRow row = myData.Tables[0].Rows[i];

                    int itemID = Int32.Parse(row["ItemID"].ToString());
                    int sellerID = Int32.Parse(row["sellerID"].ToString());
                    string name = row["itemName"].ToString();
                    string description = row["itemDescription"].ToString();
                    string picture = row["itemPicture"].ToString();
                    string category = row["category"].ToString();
                    Decimal price = Decimal.Parse(row["price"].ToString());

                    Item tempItem = new Item();
                    tempItem.ItemID = itemID;
                    tempItem.SellerID = sellerID;
                    tempItem.Name = name;
                    tempItem.Description = description;
                    tempItem.Picture = picture;
                    tempItem.Category = category;
                    tempItem.Price = price;

                    tempItemList.Add(tempItem);
                }
                return tempItemList;
            }
            return null;
        }
        //Web Method that 'buys' items by adding the userID to the buyerID column in the Items table
        [WebMethod]
        public int BuyItems(int userID, ArrayList cart)
        {
            if (cart.Count > 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    int itemID = (int)cart[i];

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "OceanBuyItem";
                    objCommand.Parameters.AddWithValue("@userID", userID);
                    objCommand.Parameters.AddWithValue("@itemID", itemID);

                    DBConnect db = new DBConnect();
                    int result = db.DoUpdateUsingCmdObj(objCommand);
                    //if an update fails then the method returns i so we can then modify the cart to get rid of the succesful items bought in arraylist but not the unsuccesful ones.
                    if(result == -1)
                    {
                        return i;
                    }
                }
                return 1;
            }
            return -1;
        }
    }
}
