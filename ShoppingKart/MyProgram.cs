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
        private readonly IOffers offers;

        public MyProgram( ICheckout checkout, IOffers offers)
        {
            this.checkout = checkout;
            this.offers = offers;
        }

        public double GetSinglePrice(List<string> checkoutItems, Dictionary<string, double> priceList) 
        {
          
            return checkout.GetSinglePriceTotal(checkoutItems, priceList);
        }

        public double GetPriceWithOffer(List<string> checkoutItems, Dictionary<string, double> priceList, int itemCount, double price)
        {

            return offers.anyNumberOfItemsForSetPrice(checkoutItems, priceList, itemCount, price);
        }

        public double GetPriceWithOfferSetItems(List<string> checkoutItems, Dictionary<string, double> priceList, string itemName, int itemCount, double price)
        {

            return offers.setNumberOfItemsForSetPrice(checkoutItems, priceList, itemName, itemCount, price);
        }
    }
}
