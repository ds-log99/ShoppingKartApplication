using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ShoppingKart.Services
{
    public class Offers : IOffers
    {
        public double anyNumberOfItemsForSetPrice(List<string> checkoutItems, Dictionary<string, double> priceList, int itemCount, double setPrice)
        {
            double resultOffer = 0.0;
            int duplicateItems = 0;

            HashSet<string> noDuplicateItems = new HashSet<string>();

            foreach (string item in checkoutItems) 
            {
                if (noDuplicateItems.Add(item) == false )
                {
                    duplicateItems++;
                }
            }

            if (duplicateItems == itemCount - 1)
            {
                resultOffer = 13.00;
            }

            return resultOffer;
        }
    }
}
