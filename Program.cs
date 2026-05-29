using Microsoft.EntityFrameworkCore;
using Poststore.Data;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
   
if(ConnectionString == null)
{
    throw new Exception("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseNpgsql(ConnectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/products", async (AppDbContext context) =>
{
    var products = await context
        .Products
        .AsNoTracking()
        .ToListAsync();
    return Results.Ok(products);
});

app.Run();
