using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OceanShoppingLibrary;
using System.Data.SqlClient;
using System.Data;
using Utilities;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

namespace OceanShoppingAPI.Controllers
{
    [Route("api/OceanShoppingAPI")]
    public class OceanShopping : Controller
    {
        [HttpGet("GetUser")]
        public User getUser(string email, string password)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanLogin";
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@password", password);
            DBConnect objDB = new DBConnect();
            DataSet myData = objDB.GetDataSetUsingCmdObj(objCommand);

            User tempUser = new User();

            if (myData.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < myData.Tables[0].Rows.Count; i++)
                {
                    DataRow row = myData.Tables[0].Rows[i];

                    tempUser.UserID = Int32.Parse(row["UserID"].ToString());
                    tempUser.FirstName = row["firstName"].ToString();
                    tempUser.LastName = row["lastName"].ToString();
                    tempUser.Email = row["email"].ToString();

                    string wishlist = row["wishlist"].ToString();
                    //deserialize wishlist and cart and add it to user
                    if (wishlist != "")
                    {
                        byte[] byteArrayWishlist = (byte[])row["wishlist"];
   
                        BinaryFormatter desearilizerWishlist = new BinaryFormatter();
                        MemoryStream memStreamWishlist = new MemoryStream(byteArrayWishlist);

                        ArrayList wishListArray = new ArrayList();
                        wishListArray = (ArrayList)desearilizerWishlist.Deserialize(memStreamWishlist);

                        tempUser.Wishlist = wishListArray;
                    }
                    else
                    {
                        tempUser.Wishlist = null;
                    }

                    string cart = row["cart"].ToString();
                    if (cart != "")
                    {
                        byte[] byteArrayCart = (byte[])row["cart"];
                        BinaryFormatter desearilizerCart = new BinaryFormatter();
                        MemoryStream memStreamCart = new MemoryStream(byteArrayCart);

                        ArrayList cartArray = new ArrayList();
                        cartArray = (ArrayList)desearilizerCart.Deserialize(memStreamCart);

                        tempUser.Cart = cartArray;
                    }
                    else
                    {
                        tempUser.Cart = null;
                    }
                }
            }
            else
            {
                tempUser = null;
            }
            return tempUser;
        }
        [HttpPost("AddUser")]
        public int addUser([FromBody] User tempUser)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanAddUser";
            objCommand.Parameters.AddWithValue("@firstName", tempUser.FirstName);
            objCommand.Parameters.AddWithValue("@lastName", tempUser.LastName);
            objCommand.Parameters.AddWithValue("@email", tempUser.Email);
            objCommand.Parameters.AddWithValue("@password", tempUser.Password);
            objCommand.Parameters.AddWithValue("@billingAddress", tempUser.BillingAddress);
            objCommand.Parameters.AddWithValue("@deliverAddress", tempUser.DeliverAddress);
            objCommand.Parameters.AddWithValue("@securityQuestionOne", tempUser.SecurityQuestionOne);
            objCommand.Parameters.AddWithValue("@securityAnswerOne", tempUser.SecurityAnswerOne);
            objCommand.Parameters.AddWithValue("@securityQuestionTwo", tempUser.SecurityQuestionTwo);
            objCommand.Parameters.AddWithValue("@securityAnswerTwo", tempUser.SecurityAnswerTwo);
            objCommand.Parameters.AddWithValue("@securityQuestionThree", tempUser.SecurityQuestionThree);
            objCommand.Parameters.AddWithValue("@securityAnswerThree", tempUser.SecurityAnswerThree);

            DBConnect objDB = new DBConnect();
            int result = objDB.DoUpdateUsingCmdObj(objCommand);
            return result;
        }
        [HttpGet("CheckEmail")]
        public int checkEmail(string email)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanCheckEmail";
            objCommand.Parameters.AddWithValue("@email", email);
            DBConnect objDB = new DBConnect();
            DataSet myData = objDB.GetDataSetUsingCmdObj(objCommand);
            if (myData.Tables[0].Rows.Count > 0)
            {
                return 0;
            }
            return 1;
        }
        [HttpGet("CheckPassword")]
        public int checkPassword(string password)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanCheckPassword";
            objCommand.Parameters.AddWithValue("@password", password);
            DBConnect objDB = new DBConnect();
            DataSet myData = objDB.GetDataSetUsingCmdObj(objCommand);
            if (myData.Tables[0].Rows.Count > 0)
            {
                return 0;
            }
            return 1;
        }
        [HttpGet("SecurityQuestions")]
        public ArrayList getQuestions(string email)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanGetQuestions";
            objCommand.Parameters.AddWithValue("@email", email);
            DBConnect objDB = new DBConnect();
            DataSet myData = objDB.GetDataSetUsingCmdObj(objCommand);
            if (myData.Tables[0].Rows.Count > 0)
            {
               ArrayList tempQuestionList = new ArrayList();

               DataRow row = myData.Tables[0].Rows[0];
               tempQuestionList.Add(row["securityQuestionOne"].ToString());
               tempQuestionList.Add(row["securityQuestionTwo"].ToString());
               tempQuestionList.Add(row["securityQuestionThree"].ToString());
               return tempQuestionList;
             }
            return null;
        }
        [HttpGet("SecurityQuestionOneCheck")]
        public string checkSecurityQuestionOne(string email, string answer)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanSecurityOne";
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@answer", answer);
            DBConnect objDB = new DBConnect();
            DataSet myData = objDB.GetDataSetUsingCmdObj(objCommand);
            if (myData.Tables[0].Rows.Count > 0)
            {
                DataRow row = myData.Tables[0].Rows[0];
                string password = row["password"].ToString();
                return password;
            }
            return null;
        }
        [HttpGet("SecurityQuestionTwoCheck")]
        public string checkSecurityQuestionTwo(string email, string answer)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanSecurityTwo";
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@answer", answer);
            DBConnect objDB = new DBConnect();
            DataSet myData = objDB.GetDataSetUsingCmdObj(objCommand);
            if (myData.Tables[0].Rows.Count > 0)
            {
                DataRow row = myData.Tables[0].Rows[0];
                string password = row["password"].ToString();
                return password;
            }
            return null;
        }
        [HttpGet("SecurityQuestionThreeCheck")]
        public string checkSecurityQuestionThree(string email, string answer)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "OceanSecurityThree";
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@answer", answer);
            DBConnect objDB = new DBConnect();
            DataSet myData = objDB.GetDataSetUsingCmdObj(objCommand);
            if (myData.Tables[0].Rows.Count > 0)
            {
                DataRow row = myData.Tables[0].Rows[0];
                string password = row["password"].ToString();
                return password;
            }
            return null;
        }
    }
}
