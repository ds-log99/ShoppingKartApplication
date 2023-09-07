using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Services
{
    public interface IOffers
    {
        public double anyNumberOfItemsForSetPrice(List<string> checkoutItems, Dictionary<string, double> priceList, int itemCount, double setPrice);
    }
}
