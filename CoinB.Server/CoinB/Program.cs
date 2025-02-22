using CoinB.Data;
using CoinB.Endpoints;
using CoinB.Helpers;
using CoinB.Middlewares;
using CoinB.Services;
using Microsoft.EntityFrameworkCore;

var bbCode = CodeGeneratorHelper.GenerateRandomCode(16);

Console.WriteLine($"Generated BB code: {bbCode}");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CoinBDbContext>(options =>
{
    options.UseSqlite("Data Source=coinb.db");
});

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseMiddleware<HeaderVerificationMiddleware>(bbCode);

app.MapCategoryEndpoints();
app.MapTransactionEndpoints();
app.MapAccountEndpoints();

app.Run();