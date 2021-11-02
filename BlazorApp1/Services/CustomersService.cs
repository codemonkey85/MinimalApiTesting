using Shared;

namespace BlazorApp1.Services;

public class CustomersService
{
    private readonly HttpClient HttpClient;

    public CustomersService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public async Task<Customer[]> GetCustomers() => await HttpClient.GetFromJsonAsync<Customer[]>($"customers") ?? Array.Empty<Customer>();

    public async Task<Customer?> GetCustomer(long customerId) => await HttpClient.GetFromJsonAsync<Customer>($"customers/{customerId}");

    public async Task CreateCustomer(Customer customer) => await HttpClient.PostAsJsonAsync($"customers", customer);

    public async Task UpdateCustomer(Customer customer) => await HttpClient.PutAsJsonAsync($"customers", customer);

    public async Task DeleteCustomer(long customerId) => await HttpClient.DeleteAsync($"customers/{customerId}");
}
