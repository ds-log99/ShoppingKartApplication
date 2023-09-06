using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingKart.Data;
using System.Globalization;

using IHost host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;


IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
           
        });
}


string userInput = string.Empty;
string[] checkoutList;

Console.WriteLine("Item  Price  Offer");
Console.WriteLine("--------------------");

ItemsDictionary items = new ItemsDictionary();
Dictionary<string, double> priceList = items.GetPriceList();

foreach (var key in priceList.Keys)
{
    Console.WriteLine(key + "     " + priceList[key]);
}

Console.ReadKey();