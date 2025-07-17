
using Calculator.Context;
using Calculator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ContextData>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.
                        AddPolicy("FrontendConnection",policy=>policy.WithOrigins("http://127.0.0.1:5500","http://localhost:5173").    
                        AllowAnyMethod().
                        AllowAnyHeader().
                        AllowCredentials())
                        );

builder.Services.AddTransient<ICalciService, CalciService>();
var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("FrontendConnection");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

﻿using System.Net.Http;
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

