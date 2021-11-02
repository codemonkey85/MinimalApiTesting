using Microsoft.EntityFrameworkCore;
using Shared;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(nameof(AppDbContext)));
var app = builder.Build();
var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

app.MapGet("/", () => "Hello World!");

#region Customers

const string customerApi = "/customer";
app.MapGet(customerApi, () => dbContext.Customers);
app.MapGet($"{customerApi}/{{customerId}}", (long customerId) => dbContext.Customers.FirstOrDefault(c => c.Id == customerId));
app.MapPost(customerApi, (Customer customer) =>
{
    dbContext.Customers.Add(customer);
    dbContext.SaveChanges();
});
app.MapPut(customerApi, (Customer customer) =>
{
    dbContext.Entry(customer).State = EntityState.Modified;
    dbContext.SaveChanges();
});
app.MapDelete(customerApi, (long customerId) =>
{
    var customer = dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
    if (customer == null)
    {
        return;
    }
    dbContext.Customers.Remove(customer);
    dbContext.SaveChanges();
});

#endregion

app.Run();
