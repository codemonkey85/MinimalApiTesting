using Shared;
using System.Net.Http.Json;

//Console.WriteLine("Press Enter to send a POST request");
//Console.ReadLine();
using (var http = new HttpClient())
{
    string baseUrl = "https://localhost:7003";
    for (int i = 1; i <= 10; i++)
    {
        var customer = new Customer { Name = $"Customer {i}", Email = $"customer{i}@icloud.com" };
        await http.PostAsJsonAsync($"{baseUrl}/customer", customer);
    }
    //var customers = await http.GetFromJsonAsync<Customer[]>($"{baseUrl}/customers");
    //Console.WriteLine("Done!");
}
