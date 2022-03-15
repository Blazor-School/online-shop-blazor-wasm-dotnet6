using OnlineShop.Models;
using System.Net.Http.Json;

namespace OnlineShop.States;

public class CartState
{
    private readonly HttpClient _httpClient;

    public List<Product> SelectedItems { get; set; } = new();

    public CartState(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddProductToCartAsync(Guid productId)
    {
        if (SelectedItems.Any(p => p.Id == productId) is false)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("sample-data/products.json") ?? new();
            var product = products.First(p => p.Id == productId);
            SelectedItems.Add(product);
        }
    }
}