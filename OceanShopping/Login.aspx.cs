using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using OceanShoppingLibrary;

namespace OceanShopping
{
    public partial class Login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["OceanShoppingLogin"] != null)
                {
                    HttpCookie cookie = Request.Cookies["OceanShoppingLogin"];
                    string email = cookie.Values["Email"].ToString();
                    string password = cookie.Values["Password"].ToString();
                    User tempUser = GetUserInfo(email, password);
                    AddToSession(tempUser);

                    Response.Redirect("Home.aspx");
                }
                else
                {
                    login_forgot_password_div.Visible = false;
                }
            }
        }
        protected void login_submit_Click(object sender, EventArgs e)
        {
            Session.Remove("QuestionIndex");

            string email = login_email.Text;
            string password = login_password.Text;


            User tempUser = GetUserInfo(email, password);

            if (tempUser != null)
            {
                CheckBox rememberCheck = (CheckBox)login_remember;
                if (rememberCheck.Checked)
                {
                    HttpCookie myCookie = new HttpCookie("OceanShoppingLogin");
                    myCookie.Values["Email"] = email;
                    myCookie.Values["Password"] = password;
                    Response.Cookies.Add(myCookie);
                }
                AddToSession(tempUser);

                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid login. Please double check your credentials.')</script>");
            }
        }

        protected void login_create_account_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void login_forgot_password_Click(object sender, EventArgs e)
        {
            string email = login_email.Text;
            if (email != "")
            {
                login_forgot_password_div.Visible = true;

                WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/SecurityQuestions?email=" + email);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                ArrayList questionsList = new ArrayList();
                questionsList = js.Deserialize<ArrayList>(data);

                int min = 1;
                int max = 3;
                Random ran = new Random();
                int questionIndex = ran.Next(min, max);

                login_forgot_password_question.Text = questionsList[questionIndex].ToString();

                Session.Add("QuestionIndex", questionIndex);
            }
            else
            {
                Response.Write("<script>alert('Type in your email before clicking 'Forgot Password'')</script>");
            }

        }

        protected void login_forgot_password_cancel_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            login_forgot_password_div.Visible = false;
        }

        protected void login_forgot_password_submit_Click(object sender, EventArgs e)
        {
            string answer = login_forgot_password_answer.Text;
            string email = login_email.Text;
            int index = Int32.Parse(Session["QuestionIndex"].ToString());
            if (index == 0)
            {
                WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/SecurityQuestionOneCheck?email=" + email + "&answer=" + answer);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data != null)
                {
                    string password = data;
                    Response.Write("<script>alert('Password: '" + password + ")</script>");
                }
                else
                {
                    Response.Write("<script>alert('Wrong answer')</script>");
                }
            }
            else if (index == 1)
            {
                WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/SecurityQuestionTwoCheck?email=" + email + "&answer=" + answer);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data != null)
                {
                    string password = data;
                    Response.Write("<script>alert('Password: '" + password + ")</script>");
                }
                else
                {
                    Response.Write("<script>alert('Wrong answer')</script>");
                }
            }
            else
            {
                WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/SecurityQuestionThreeCheck?email=" + email + "&answer=" + answer);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data != null)
                {
                    string password = data;
                    Response.Write("<script>alert('Password: '" + password + ")</script>");
                }
                else
                {
                    Response.Write("<script>alert('Wrong answer')</script>");
                }
            }
        }
        public User GetUserInfo(string email, string password)
        {
            WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/GetUser?email=" + email + "&password=" + password);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            User tempUser = js.Deserialize<User>(data);

            return tempUser;
        }
        public void AddToSession(User tempUser)
        {
            Session.Add("UserID", tempUser.UserID);
            Session.Add("Email", tempUser.Email);
            Session.Add("First Name", tempUser.FirstName);
            Session.Add("Last Name", tempUser.LastName);
            Session.Add("Wishlist", tempUser.Wishlist);
            Session.Add("Cart", tempUser.Cart);
        }
    }
   
}