using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Services
{
    public class Offers : IOffers
    {
        public string anyNumberOfItemsForSetPrice(List<string> items, Dictionary<string, double> priceList, int itemCount, double setPrice)
        {
            string resultOffer = string.Empty;
            int duplicateItems = 0;

            HashSet<string> noDuplicateItems = new HashSet<string>();

            foreach (string item in items) 
            {
                if (noDuplicateItems.Add(item) == false )
                {
                    duplicateItems++;
                }
            }



            return resultOffer;
        }
    }
}
