using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OceanShoppingLibrary;

namespace OceanShopping
{
    public partial class Cart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Refresh()
        {
            rpt_Items.Visible = false;

            ArrayList cartlist = (ArrayList)Session["Cart"];
            if (cartlist == null)
            {
                Response.Write("Nothing is in your cart.");
            }
            else
            {
                ItemActions pxy = new ItemActions();
                ArrayList cartItems = pxy.GetCartItems(cartlist);
                rpt_Items.DataSource = null;
                rpt_Items.DataSource = cartItems;
                rpt_Items.DataBind();

                rpt_Items.Visible = true;
            }
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        protected void cart_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void product_delete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem rItem = (RepeaterItem)btn.NamingContainer;

            ArrayList cart = (ArrayList)Session["Cart"];
            if (cart != null)
            {
                Label productIDLabel = (Label)rItem.FindControl("product_id");
                int productID = Int32.Parse(productIDLabel.Text);
                for (int i = 0; i < cart.Count; i++)
                {
                    if ((int)cart[i] == productID)
                    {
                        cart.RemoveAt(i);
                    }
                }
                Session["Cart"] = cart;
                StoreCart(cart);
                Refresh();
            }
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
    }
}