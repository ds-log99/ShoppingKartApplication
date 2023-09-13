using ShoppingKart.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Services
{
    public class Checkout : ICheckout
    {
        double ICheckout.GetSinglePriceTotal(List<string> checkoutItems, Dictionary<string, double> priceList)
        {
            double priceTotal = 0;
            List<string> itemsList = checkoutItems.ToList();

            /*
            foreach (var item in itemsList)
            {
                var itemPrice = priceList.FirstOrDefault(x => x.Key == item).Value;
                if (itemPrice != 0)
                {
                    priceTotal += itemPrice;
                }
              
            } */
            
        OuterLoop:
                for (int i = 0; i <= itemsList.Count; i++)
                {
                    for (int j = 0; j <= priceList.Count; j++)
                    {
                        var item = priceList.ElementAt(j);
                        string itemName = item.Key;
                        double itemPrice = item.Value;

                    if (itemsList.Count > 0)
                    {
                        if (itemName == itemsList[i])
                        {
                            priceTotal += itemPrice;

                            var checkoutListItem = itemsList.ElementAt(i);
                            var itemToRemove = itemsList.FirstOrDefault(p => p == checkoutListItem);
                            itemsList.Remove(itemToRemove!);
                            goto OuterLoop;
                        }
                        if (priceList.ContainsKey(itemsList[i]) != true )
                        {
                            var checkoutListItem = itemsList.ElementAt(i);
                            var itemToRemove = itemsList.Single(p => p == checkoutListItem);
                            itemsList.Remove(itemToRemove);

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
