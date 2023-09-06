using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Data
{
    public struct ItemsDictionary
    {
        public Dictionary<string, double> GetPriceList() 
        {

            Dictionary<string, double> Items =  new Dictionary<string, double>()
            {
                {"A",5.00},
                {"B",3.00},
                {"C", 2.00},
                {"D",1.50}
            };

         return Items;

        }
    }
}

