using System;
using System.Globalization;
using CurrencyConverter;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

decimal usd, eur;

Console.WriteLine(" Currency Converter Setup ");

usd = ReadRate("Enter UAH to USD rate : ");
eur = ReadRate("Enter UAH to EUR rate : ");

Converter converter = new Converter(usd, eur);
Console.WriteLine("Converter created successfully.");

bool running = true;
while (running)
{
    Console.WriteLine(" Select operation ");
    Console.WriteLine("1. Convert UAH to USD");
    Console.WriteLine("2. Convert UAH to EUR");
    Console.WriteLine("3. Convert USD to UAH");
    Console.WriteLine("4. Convert EUR to UAH");
    Console.WriteLine("5. Exit");
    Console.Write("Enter option (1-5): ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Convert(converter, "UAH", "USD", converter.UahToUsd);
            break;
        case "2":
            Convert(converter, "UAH", "EUR", converter.UahToEur);
            break;
        case "3":
            Convert(converter, "USD", "UAH", converter.UsdToUah);
            break;
        case "4":
            Convert(converter, "EUR", "UAH", converter.EurToUah);
            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

static decimal ReadRate(string message)
{
    decimal rate;
    while (true)
    {
        Console.Write(message);
        if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out rate) && rate > 0)
        {
            return rate;
        }
        Console.WriteLine("Invalid input. Please enter a positive number.");
    }
}

static void Convert(Converter converter, string fromCurrency, string toCurrency, Func<decimal, decimal> conversionFunc)
{
    decimal amount;
    while (true)
    {
        Console.Write($"Enter amount in {fromCurrency}: ");
        if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out amount) && amount >= 0)
        {
            break;
        }
        Console.WriteLine("Invalid input. Please enter a non-negative number.");
    }

    decimal result = conversionFunc(amount);
    Console.WriteLine($"{amount} {fromCurrency} = {result:F2} {toCurrency}");
}

