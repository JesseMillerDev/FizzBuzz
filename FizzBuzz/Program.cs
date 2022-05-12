// See https://aka.ms/new-console-template for more information
using FizzBuzz;
using FizzBuzzLib;
using Microsoft.Extensions.Configuration;

var Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var fizzBuzzConfig = Configuration.GetSection("FizzBuzzConfig").Get<FizzBuzzConfig>();

var fizzBuzzer = new FizzBuzzer(fizzBuzzConfig);

await foreach (var result in fizzBuzzer.GetFizzBuzz(-10, 10))
{
    Console.WriteLine(result);
}

Console.ReadLine();


 