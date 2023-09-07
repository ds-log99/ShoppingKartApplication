using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System;
using ShoppingKart.Services;
using System.Runtime.CompilerServices;

namespace ShoppingKartTest
{
    public class CheckoutTests
    {

   
        [Fact]
        public void CheckoutSinglePriceSumOk() 
        {
            //Arange 

           var mockItems =  GetMockItems();
           var mockUserInput =  GetMockUserInput();
            
            //Act
            ICheckout checkout = new Checkout();
            double checkoutTest = checkout.GetSinglePriceTotal(mockUserInput, mockItems);

            //Assert
            Assert.Equal(checkoutTest, 3.0);

        }

        [Fact]
        public void CheckOutPriceWithOfferAnyItemOk()
        {
            //Arrange
            var mockItems = GetMockItems();
            var mockUserInput = GetMockUserInputWithDuplicates();

            int testItemCount = 3;
            double offerPriceTest = 13.0; 

            //Act
            IOffers offers = new Offers();
            double anySetItemsForPriceTest = offers.anyNumberOfItemsForSetPrice(mockUserInput, mockItems, testItemCount, offerPriceTest);

            //Assert
            Assert.Equal(anySetItemsForPriceTest, offerPriceTest);
        }


        [Fact]
        public void CheckOutPriceWithOfferSetItemOk()
        {
            //Arrange
            var mockItems = GetMockItems();
            var mockUserInput = GetMockUserInputWithDuplicates();

            string itemName = "A";
            int testItemCount = 3;
            double offerPriceTest = 10.0;

            //Act
            IOffers offers = new Offers();
            double anySetItemsForPriceTest = offers.setNumberOfItemsForSetPrice(mockUserInput, mockItems, itemName, testItemCount, offerPriceTest);

            //Assert
            Assert.Equal(anySetItemsForPriceTest, offerPriceTest);
        }


        private Dictionary<string, double> GetMockItems()
        {
            Dictionary<string, double> mockItems = new Dictionary<string, double>()
            {
                {"A", 1.0 },
                {"B", 2.0 }
            };

            return mockItems;
        }

        private List<string> GetMockUserInput()
        {
            List<string> mockUserInput = new List<string>();
            mockUserInput.Add("A");
            mockUserInput.Add("B");

            return mockUserInput;
        }

        private List<string> GetMockUserInputWithDuplicates()
        {
            List<string> mockUserInput = new List<string>();
            mockUserInput.Add("A");
            mockUserInput.Add("B");
            mockUserInput.Add("A");
            mockUserInput.Add("A");

            return mockUserInput;
        }
    }
}
