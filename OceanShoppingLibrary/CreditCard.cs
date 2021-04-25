using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanShoppingLibrary
{

    [Serializable]
    public class CreditCard
    {
        private byte[] creditName;
        private byte[] creditNum;
        private byte[] expirationDate;
        private byte[] cvv;

        public CreditCard()
        {

        }
        public Byte[] CreditName
        {
            get
            {
                return creditName;
            }
            set
            {
                creditName = value;
            }
        }
        public Byte[] CreditNum
        {
            get
            {
                return creditNum;
            }
            set
            {
                creditNum = value;
            }
        }
        public Byte[] ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                expirationDate = value;
            }
        }
        public Byte[] Cvv
        {
            get
            {
                return cvv;
            }
            set
            {
                cvv = value;
            }
        }
    }
}
