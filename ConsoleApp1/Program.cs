using Shared;
using System.Net.Http.Json;

using (var http = new HttpClient())
{
    string baseUrl = "https://localhost:7003";
    for (int i = 1; i <= 10; i++)
    {
        var customer = new Customer { Name = $"Customer {i}", Email = $"customer{i}@icloud.com" };
        await http.PostAsJsonAsync($"{baseUrl}/customer", customer);
    }
}
