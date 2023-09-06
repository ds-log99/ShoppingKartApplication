using ShoppingKart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart
{
    public class MyProgram
    {
        private readonly ICheckout checkout;
        public MyProgram( ICheckout checkout)
        {
            this.checkout = checkout;
        }

        public double GetSinglePrice(List<string> checkoutItems, Dictionary<string, double> priceList) 
        {
            var itemToRemove = checkoutItems.Single(p => p == "DONE" || p == "done");
            checkoutItems.Remove(itemToRemove);

            return checkout.GetSinglePriceTotal(checkoutItems, priceList);
        }
    }
}
