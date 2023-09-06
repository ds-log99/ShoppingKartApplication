using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Data
{
    public struct OffersList
    {
        public List<string> GetOffers()
        {
            List<string> offers = new List<string>() 
            {
                "buy any 3 items for 13.00"
            };
            
            return offers;
        }
    }
}
