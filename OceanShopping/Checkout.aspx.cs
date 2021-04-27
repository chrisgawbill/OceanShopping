using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OceanShoppingLibrary;

namespace OceanShopping
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                GetCreditCard();
                FillPlaceholder();
            }
         }
        public void FillPlaceholder()
        {

            ArrayList cart = new ArrayList();
            cart = (ArrayList)Session["Cart"];
            if (cart.Count > 0)
            {
                checkout_items_placeholder.Controls.Clear();

                Table tblRecords = new Table();
                checkout_items_placeholder.Controls.Add(tblRecords);

                ItemActions pxy = new ItemActions();
                ArrayList cartItems = pxy.GetCartItems(cart);
                Decimal totalPrice = 0;

                checkout_cart_header.Text = "Cart(" + cartItems.Count + ")";

                for (int i = 0; i < cartItems.Count; i++)
                {
                    Item tempItem = (Item)cartItems[i];

                    TableRow row = new TableRow();
                    TableCell productName = new TableCell();
                    TableCell productPrice = new TableCell();

                    productName.Text = tempItem.Name;
                    productPrice.Text = "$" + tempItem.Price.ToString();

                    totalPrice += tempItem.Price;

                    row.Cells.Add(productName);
                    row.Cells.Add(productPrice);

                    tblRecords.Rows.Add(row);
                }
                checkout_price.Text = "$" + totalPrice.ToString();
            }
            else
            {
                Response.Write("<script>alert('Cart is empty')</script>");
            }
        }

        protected void checkout_submit_Click(object sender, EventArgs e)
        {
            int userID = Int32.Parse(Session["UserID"].ToString());
            ArrayList cart = (ArrayList)Session["Cart"];
            ItemActions pxy = new ItemActions();
            int result = pxy.BuyItems(userID, cart);
            if(result == -1)
            {
                Response.Write("<script>alert('Something went wrong when ordering')</script>");
            }else if(result == 1)
            {
                ArrayList wishlist = (ArrayList)Session["Wishlist"];
                for(int i = 0; i < wishlist.Count; i++)
                {
                    for(int b = 0; b < cart.Count; b++)
                    {
                        if ((int)wishlist[i] == (int)cart[b])
                        {
                            wishlist.RemoveAt(i);
                        }
                    }
                    Session["Wishlist"] = wishlist;
                    StoreWishlist(wishlist);
                }
                cart.Clear();
                Session["Cart"] = cart;
                StoreCart(cart);
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Some items did not get checked out, modifying cart')</script>");
                for(int i = 0; i < result; i++)
                {
                    cart.RemoveAt(i);
                }
                Session["Cart"] = cart;
                StoreCart(cart);
            }

        }

        protected void checkout_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        public void StoreCart(ArrayList cart)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, cart);
            byte[] byteListArray;
            byteListArray = memStream.ToArray();

            int userID = Int32.Parse(Session["UserID"].ToString());

            ItemActions pxy = new ItemActions();
            pxy.StoreCart(userID, byteListArray);
        }
        public void StoreWishlist(ArrayList wishlist)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            serializer.Serialize(memStream, wishlist);
            byte[] byteListArray;
            byteListArray = memStream.ToArray();

            int userID = Int32.Parse(Session["UserID"].ToString());

            ItemActions pxy = new ItemActions();
            pxy.StoreWishlist(userID, byteListArray);
        }
        public void GetCreditCard()
        {
            int userID = Int32.Parse(Session["UserID"].ToString());
            ItemActions pxy = new ItemActions();
            User tempUser = pxy.GetCreditCard(userID);
            User keyUser = pxy.GetKeyVector(userID);
            Byte[] key = keyUser.Key;
            Byte[] vector = keyUser.Vector;

            CreditCard tempCredit = DeserializeObject(tempUser.CreditCard);

            checkout_credit_name.Text =  DecryptField(tempCredit.CreditName, key, vector);
            checkout_credit_num.Text = DecryptField(tempCredit.CreditNum, key, vector);
            checkout_credit_cvv.Text = DecryptField(tempCredit.Cvv, key, vector);
            string expirationDate = DecryptField(tempCredit.ExpirationDate, key, vector);
            String[] expirationDateArray = expirationDate.Split('/');

            checkout_payment_month.SelectedValue = expirationDateArray[0];
            checkout_payment_year.SelectedValue = expirationDateArray[1];
        }
        public String DecryptField(byte[] test, byte[] key, byte[] vector)
        {
            RijndaelManaged myRijndael = new RijndaelManaged();

            Byte[] txtBytes;

            UTF8Encoding encoder = new UTF8Encoding();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myDecryptionStream = new CryptoStream(myMemoryStream, myRijndael.CreateDecryptor(key, vector), CryptoStreamMode.Write);

            myDecryptionStream.Write(test, 0, test.Length);
            myDecryptionStream.FlushFinalBlock();

            myMemoryStream.Position = 0;
            txtBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(txtBytes, 0, txtBytes.Length);

            myDecryptionStream.Close();
            myMemoryStream.Close();

            return encoder.GetString(txtBytes);
        }
        public CreditCard DeserializeObject(Byte[] test)
        {
            BinaryFormatter deserializeCredit = new BinaryFormatter();
            MemoryStream memStreamCredit = new MemoryStream(test);

            CreditCard tempCredit = new CreditCard();
            tempCredit = (CreditCard)deserializeCredit.Deserialize(memStreamCredit);

            return tempCredit;
        }
    }
}