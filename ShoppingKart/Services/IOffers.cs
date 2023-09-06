using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Services
{
    public interface IOffers
    {
        public string anyNumberOfItemsForSetPrice(List<string> items, Dictionary<string, double> priceList, int itemCount, double setPrice);
    }
}
