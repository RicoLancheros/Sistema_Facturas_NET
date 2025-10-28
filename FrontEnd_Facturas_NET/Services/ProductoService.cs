using FrontEnd_Facturas_NET.Models;
using System.Net.Http.Json;

namespace FrontEnd_Facturas_NET.Services;

public class ProductoService
{
    private readonly HttpClient _httpClient;

    public ProductoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Producto>?> GetProductosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Producto>>("api/Productos");
    }

    public async Task<Producto?> GetProductoAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Producto>($"api/Productos/{id}");
    }

    public async Task<Producto?> CreateProductoAsync(Producto producto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Productos", producto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Producto>();
    }

    public async Task UpdateProductoAsync(int id, Producto producto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Productos/{id}", producto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteProductoAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Productos/{id}");
        response.EnsureSuccessStatusCode();
    }
}
