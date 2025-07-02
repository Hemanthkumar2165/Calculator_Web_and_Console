using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using static ConsoleCalci.Reposistory;

Console.WriteLine("Welcome To Use Calci");

DoCalculation();

static void DoCalculation()
{
    HttpClient httpClient = new HttpClient();

    Console.Write("Enter first number: ");
    decimal operand1 = Convert.ToDecimal(Console.ReadLine());

    Console.Write("Enter second number: ");
    decimal operand2 = Convert.ToDecimal(Console.ReadLine());

    Console.Write("Enter the Operator: ");
    char symbol = Convert.ToChar(Console.ReadLine());

    var request = new
    {
        Operand1 = operand1,
        Operand2 = operand2,
        Symbol = symbol
    };

    var response = httpClient
        .PostAsJsonAsync("https://localhost:7147/api/Calcis/AddCalculation", request)
        .GetAwaiter()
        .GetResult();

    if (response.IsSuccessStatusCode)
    {
        decimal result = response.Content
            .ReadFromJsonAsync<decimal>()
            .GetAwaiter()
            .GetResult();

        Console.WriteLine($"{operand1} {symbol} {operand2} = {result}");
    }
    else
    {
        Console.WriteLine("There is an error.");
    }
}