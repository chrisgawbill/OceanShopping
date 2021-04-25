using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanShoppingLibrary
{
    public class User
    {
        private int userID;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string billingAddress;
        private string deliverAddress;
        private string securityQuestionOne;
        private string securityAnswerOne;
        private string securityQuestionTwo;
        private string securityAnswerTwo;
        private string securityQuestionThree;
        private string securityAnswerThree;
        private ArrayList wishlist;
        private ArrayList cart;

        public User() { }

        public User(int userID, string firstName, string lastName, string email, string password, string billingAddress, string deliverAddress, 
            string securityQuestionOne, string securityAnswerOne, string securityQuestionTwo, string securityAnswerTwo, 
            string securityQuestionThree, string securityAnswerThree, ArrayList wishlist, ArrayList cart)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.billingAddress = billingAddress;
            this.deliverAddress = deliverAddress;
            this.securityQuestionOne = securityAnswerOne;
            this.securityAnswerOne = securityAnswerOne;
            this.securityQuestionTwo = securityQuestionTwo;
            this.securityAnswerTwo = securityAnswerTwo;
            this.securityQuestionThree = securityQuestionThree;
            this.securityAnswerThree = securityAnswerThree;
            this.wishlist = wishlist;
            this.cart = cart;
        }
        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string BillingAddress
        {
            get
            {
                return billingAddress;
            }
            set
            {
                billingAddress = value;
            }
        }
        public string DeliverAddress
        {
            get
            {
                return deliverAddress;
            }
            set
            {
                deliverAddress = value;
            }
        }
        public string SecurityQuestionOne
        {
            get
            {
                return securityQuestionOne;
            }
            set
            {
                securityQuestionOne = value;
            }
        }
        public string SecurityAnswerOne
        {
            get
            {
                return securityAnswerOne;
            }
            set
            {
                securityAnswerOne = value;
            }
        }
        public string SecurityQuestionTwo
        {
            get
            {
                return securityQuestionTwo;
            }
            set
            {
                securityQuestionTwo = value;
            }
        }
        public string SecurityAnswerTwo
        {
            get
            {
                return securityAnswerTwo;
            }
            set
            {
                securityAnswerTwo = value;
            }
        }
        public string SecurityQuestionThree
        {
            get
            {
                return securityQuestionThree;
            }
            set
            {
                securityQuestionThree = value;
            }
        }
        public string SecurityAnswerThree
        {
            get
            {
                return securityAnswerThree;
            }
            set
            {
                securityAnswerThree = value;
            }
        }
        public ArrayList Wishlist
        {
            get
            {
                return wishlist;
            }
            set
            {
                wishlist = value;
            }
        }
        public ArrayList Cart
        {
            get
            {
                return cart;
            }
            set
            {
                cart = value;
            }
        }
    }
}
