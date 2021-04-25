using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanShoppingLibrary
{
    public class Item
    {
        private int itemID;
        private int sellerID;
        private string name;
        private string description;
        private string picture;
        private string category;
        private decimal price;
        private int buyerID;

        public Item() { }
        public Item(int itemID, int sellerID, string name, string description, string picture, string category, decimal price, int buyerID)
        {
            this.itemID = itemID;
            this.sellerID = sellerID;
            this.name = name;
            this.description = description;
            this.picture = picture;
            this.category = category;
            this.price = price;
            this.buyerID = buyerID;
        }
        public int ItemID
        {
            get
            {
                return itemID;
            }
            set
            {
                itemID = value;
            }
        }
        public int SellerID
        {
            get
            {
                return sellerID;
            }
            set
            {
                sellerID = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public string Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
            }
        }
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }
        public Decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public int BuyerID
        {
            get
            {
                return buyerID;
            }
            set
            {
                buyerID = value;
            }
        }
    }
}
