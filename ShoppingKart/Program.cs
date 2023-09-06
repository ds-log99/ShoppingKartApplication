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
        });
}


string userInput = string.Empty;
List<string> checkoutList = new List<string>();

Console.WriteLine("Item  Price  Offer");
Console.WriteLine("--------------------");

ItemsDictionary items = new ItemsDictionary();
Dictionary<string, double> priceList = items.GetPriceList();

foreach (var key in priceList.Keys)
{
    Console.WriteLine(key + "     " + priceList[key]);
}

while (userInput != "exit")
{
    Console.WriteLine("Add item to your list: enter done whe your finished ");
    userInput = Console.ReadLine();
    checkoutList.Add(userInput.ToUpper());

    if (userInput.ToLower() == "done") 
    {
        ICheckout total = new Checkout();
        var checkoutProcess = new MyProgram(total);
        var sumPrice = checkoutProcess.GetSinglePrice(checkoutList, priceList);

        /*
        var itemToRemove = checkoutList.Single(p => p == "DONE" || p == "done");
        checkoutList.Remove(itemToRemove);

        ICheckout total = new Checkout();

        var sumPrice = total.GetSinglePriceTotal(checkoutList, priceList);
        */

        Console.WriteLine($"The total price for you items is: {sumPrice}");
        continue;
    }

    Console.WriteLine("enter exit if you would likew to close the application");
}

Console.ReadKey();