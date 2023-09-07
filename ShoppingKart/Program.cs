using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingKart;
using ShoppingKart.Data;
using ShoppingKart.Services;
using System.Globalization;

/*
 * For this test I tried my best to use good design principles following SOLID and DRY 
 * for the UI I the table does not appear exaclty as in the challange edescription with more time i would've taken a different approach such as using string formatting approach and another
 * way I am thinking of is using Linq to query whats in the list and format using string formatting approach 
 * I impelemented dependency injection for the main funcitonality of the program 
 * I have attempted to unit test using xUnit the main funcitonalities of the app with more time i could've created more tests to check different scenarious 
 */


using IHost host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;
IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddTransient<ICheckout, Checkout>();
            services.AddTransient<IOffers, Offers>();
        });
}

string userInput = string.Empty;
List<string> checkoutList = new List<string>();

Console.WriteLine("Item  Price  Offer");
Console.WriteLine("--------------------");

ItemsDictionary items = new ItemsDictionary();
OffersList priceOffers = new OffersList();
Dictionary<string, double> priceList = items.GetPriceList();
if (priceOffers.GetType != null)
{
    foreach (var offer in priceOffers.GetOffers())
    {
        Console.WriteLine("\t" + "        " + offer);
    }
}
foreach (var key in priceList.Keys)
{
    Console.WriteLine(key + "     " + priceList[key]);
  
}


while (userInput.ToLower() != "exit")
{
    Console.WriteLine("Scan item to your shopping cart: enter done when you're finished ");
    userInput = Console.ReadLine();
    checkoutList.Add(userInput.ToUpper());

    if (userInput.ToLower() == "done") 
    {
        var itemToRemove = checkoutList.Single(p => p == "DONE" || p == "done");
        checkoutList.Remove(itemToRemove);

        ICheckout total = new Checkout();
        IOffers totalWithOffers = new Offers();

        var checkoutProcess = new MyProgram(total, totalWithOffers);
        var sumPrice = checkoutProcess.GetSinglePrice(checkoutList, priceList);

        var anyItemsForPriceOffer = checkoutProcess.GetPriceWithOffer(checkoutList, priceList, 4, 13.0);
        var setItemsForPriceOffer = checkoutProcess.GetPriceWithOfferSetItems(checkoutList, priceList, "A", 3, 10.0);
        
        Console.WriteLine($"The total price for you're items is: £{sumPrice}");
        if (anyItemsForPriceOffer != 0 ) Console.WriteLine($"The total price for you're items including the offer is: £{anyItemsForPriceOffer}");
        if(setItemsForPriceOffer != 0 && anyItemsForPriceOffer == 0 ) Console.WriteLine($"The total price for you're items including the offer is: £{setItemsForPriceOffer}");

        checkoutList.Clear();
        continue;
    }

    Console.WriteLine("enter exit if you would likew to close the application");
}

Console.ReadKey();