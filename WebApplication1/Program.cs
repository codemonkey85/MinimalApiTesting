using Microsoft.EntityFrameworkCore;
using Shared;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<HelloService>(new HelloService());
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase(nameof(AppDbContext)));

//var dbContext = builder.Services.BuildServiceProvider().GetService<AppDbContext>();

var app = builder.Build();

// var dbContext = app.Services.GetRequiredService<AppDbContext>();
// var dbContext = app.Services.GetService<AppDbContext>();
var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

app.MapGet("/", () => "Hello World!");

app.MapGet("/{Name}", (string Name) => $"Hello {Name}!");

app.MapGet("/hello", (HttpContext context, HelloService helloService) => helloService.SayHello(context.Request.Query["name"].ToString()));

app.MapGet("/customer", () => new Customer { Name = "Michael Bond", Email = "codemonkey8510@icloud.com" });

app.MapGet("/customers", () => dbContext.Customers);

app.MapPost("/customer", (Customer customer) =>
{
    dbContext?.Customers?.Add(customer);
    dbContext?.SaveChanges();
});

app.Run();
