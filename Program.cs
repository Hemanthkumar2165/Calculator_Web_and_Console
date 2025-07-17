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
