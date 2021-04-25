using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using OceanShoppingLibrary;

namespace OceanShopping
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                create_billing_state.Visible = false;
                create_deliver_state.Visible = false;
            }
        }

        protected void create_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void create_submit_Click(object sender, EventArgs e)
        {
            string email = create_email.Text;
            string password = create_password.Text;

            if (isLoginValid(email, password))
            {
                string firstName = create_firstName.Text;
                string lastName = create_lastName.Text;

                string billingStreet = create_billing_street.Text;
                string billingCity = create_billing_city.Text;
                string billingCountry = create_billing_country.SelectedValue;
                string billingZip = create_billing_zip.Text;
                string billingState = null;
                string billingAddress = null;

                if (billingCountry.Equals("US"))
                {
                    billingState = create_billing_state.SelectedValue;
                    billingAddress = billingStreet + "," + billingCity + "," + billingState + " " + billingZip + "," + billingCountry;
                }
                else
                {
                    billingAddress = billingStreet + "," + billingCity + "," + billingZip + "," + billingCountry;
                }

                string deliverStreet = create_deliver_street.Text;
                string deliverCity = create_deliver_city.Text;
                string deliverCountry = create_deliver_country.SelectedValue;
                string deliverZip = create_deliver_zip.Text;
                string deliverState = null;
                string deliverAddress = null;

                if (deliverCountry.Equals("US"))
                {
                    deliverState = create_deliver_state.SelectedValue;
                    deliverAddress = deliverStreet + "," + deliverCountry + "," + deliverState + " " + deliverZip + "," + deliverCountry;
                }
                else
                {
                    deliverAddress = deliverStreet + "," + deliverCity + "," + deliverZip + "," + deliverCountry;
                }

                string securityQuestionOne = create_securityQuestion_one.Text;
                string securityAnswerOne = create_securityAnswer_one.Text;
                string securityQuestionTwo = create_securityQuestion_two.Text;
                string securityAnswerTwo = create_securityAnswer_two.Text;
                string securityQuestionThree = create_securityQuestion_three.Text;
                string securityAnswerThree = create_securityAnswer_three.Text;

                User tempUser = new User();
                tempUser.FirstName = firstName;
                tempUser.LastName = lastName;
                tempUser.Email = email;
                tempUser.Password = password;
                tempUser.BillingAddress = billingAddress;
                tempUser.DeliverAddress = deliverAddress;
                tempUser.SecurityQuestionOne = securityQuestionOne;
                tempUser.SecurityAnswerOne = securityAnswerOne;
                tempUser.SecurityQuestionTwo = securityQuestionTwo;
                tempUser.SecurityAnswerTwo = securityAnswerTwo;
                tempUser.SecurityQuestionThree = securityQuestionThree;
                tempUser.SecurityAnswerThree = securityAnswerThree;

                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonUser = js.Serialize(tempUser);

                WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/AddUser");
                request.Method = "POST";
                request.ContentLength = jsonUser.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonUser);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream dataStreamTwo = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStreamTwo);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                js = new JavaScriptSerializer();
                int result = js.Deserialize<int>(data);

                if(result != 1)
                {
                    Response.Write("An Error ocured when creating your account");
                }
                //SendVerificationEmail(email);
                Response.Redirect("Login.aspx");

            }
        }
        public Boolean isLoginValid(string email, string password)
        {
            if (CheckEmail(email))
            {
                if (CheckPassword(password))
                {
                    return true;
                }
                else
                {
                    Response.Write("Password is already taken");
                }
            }
            else
            {
                Response.Write("Email is already taken");
            }
            return false;
        }
        public Boolean CheckEmail(string email)
        {
            WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/CheckEmail?email=" + email);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            int result = js.Deserialize<int>(data);

            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public Boolean CheckPassword(string password)
        {
            WebRequest request = WebRequest.Create("https://localhost:44367/api/OceanShoppingAPI/CheckPassword?password=" + password);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            int result = js.Deserialize<int>(data);

            if (result == 0)
            {
                return false;
            }
            return true;
        }
        protected void BillingCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (create_billing_country.SelectedValue.Equals("US"))
            {
                create_billing_state.Visible = true;
            }
            else
            {
                create_billing_state.Visible = false;
            }
        }

        protected void DeliverCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (create_deliver_country.SelectedValue.Equals("US"))
            {
                create_deliver_state.Visible = true;
            }
            else
            {
                create_deliver_state.Visible = false;
            }
        }
        /*
        public void SendVerificationEmail(string email)
        {
            MailAddress from = new MailAddress("gawbillchris@gmail.com");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from ,to);
            message.Body = "This is a message";
            message.Subject = "Ocean Shopping Verification";
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential();
            client.Host = "smtp.gmail.com";
            client.Port = 465;
            try
            {
                client.Send(message);
            }
            catch(Exception e)
            {
                Response.Write("There was an error");
            }
        }
        */
    }
}