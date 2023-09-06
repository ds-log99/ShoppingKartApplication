using ShoppingKart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Services
{
    public class Checkout : ICheckout
    {
        double ICheckout.GetSinglePriceTotal(List<string> itemsList, Dictionary<string, double> priceList)
        {
            double priceTotal = 0;
            //var itemsName = priceList.Keys.ToList(); 
            var checkoutItems = itemsList; 

            OuterLoop:
                for (int i = 0; i <= checkoutItems.Count; i++)
                {
                    for (int j = 0; j <= priceList.Count; j++)
                    {
                        var item = priceList.ElementAt(j);
                        string itemName = item.Key;
                        double itemPrice = item.Value;

                    if (checkoutItems.Count > 0)
                    {
                        if (itemName == checkoutItems[i])
                        {
                            priceTotal += itemPrice;

                            var checkoutListItem = checkoutItems.ElementAt(i);
                            var itemToRemove = checkoutItems.FirstOrDefault(p => p == checkoutListItem);
                            checkoutItems.Remove(itemToRemove.ToString());
                            goto OuterLoop;
                        }
                        if (priceList.ContainsKey(checkoutItems[i]) != true )
                        {
                            var checkoutListItem = checkoutItems.ElementAt(i);
                            var itemToRemove = checkoutItems.Single(p => p == checkoutListItem);
                            checkoutItems.Remove(itemToRemove);

                            goto OuterLoop;
                        }
                    }
                    else break;
                    
                    }
                }

            return priceTotal;
        }
    }
}
