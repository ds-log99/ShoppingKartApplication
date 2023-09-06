using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingKart;
using ShoppingKart.Data;
using ShoppingKart.Services;
using System.Globalization;


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

foreach (var key in priceList.Keys)
{
    if (priceOffers.GetType != null)
    {
        foreach (var offer in priceOffers.GetOffers())
        {
            Console.WriteLine(key + "     " + priceList[key] + "     " + offer);
        }
    }
    else Console.WriteLine(key + "     " + priceList[key]);
}

while (userInput != "exit")
{
    Console.WriteLine("Add item to your list: enter done when you're finished ");
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

        var sumPriceWithOffers = checkoutProcess.GetPriceWithOffer(checkoutList, priceList, 3, 13.0);

        Console.WriteLine($"The total price for you items is: {sumPrice}");
        Console.WriteLine($"The total price for you items including the offer is: {sumPriceWithOffers}");


        continue;
    }

    Console.WriteLine("enter exit if you would likew to close the application");
}

Console.ReadKey();