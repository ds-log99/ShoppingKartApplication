using ShoppingKart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Services
{
    public interface ICheckout
    {
        public double GetSinglePriceTotal(List<string> checkoutItems, Dictionary<string, double> priceList);
    }
}
