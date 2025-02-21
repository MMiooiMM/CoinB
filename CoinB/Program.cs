using CoinB.Data;
using CoinB.Endpoints;
using CoinB.Services;
using Microsoft.EntityFrameworkCore;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapCategoryEndpoints();
app.MapTransactionEndpoints();

app.Run();