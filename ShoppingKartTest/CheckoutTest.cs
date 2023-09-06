using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System;
using ShoppingKart.Services;

namespace ShoppingKartTest
{
    public class CheckoutTest
    {

        [Fact]
        public void CheckoutSinglePriceSumOk() 
        {
            //Arange 
            Dictionary<string, double> mockItems = new Dictionary<string, double>() 
            {
                {"A", 1.0 },
                {"B", 2.0 }
            };

            List<string> userInputTest = new List<string>();
            userInputTest.Add("A");
            userInputTest.Add("B");

            //Act
            ICheckout checkout = new Checkout();
            double checkoutTest = checkout.GetSinglePriceTotal(userInputTest, mockItems);

            //Assert
            Assert.Equal(checkoutTest, 3.0);

        }
    }
}
