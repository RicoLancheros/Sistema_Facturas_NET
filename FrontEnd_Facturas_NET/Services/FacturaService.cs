using FrontEnd_Facturas_NET.Models;
using System.Net.Http.Json;

namespace FrontEnd_Facturas_NET.Services;

public class FacturaService
{
    private readonly HttpClient _httpClient;

    public FacturaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Factura>?> GetFacturasAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Factura>>("api/Facturas");
    }

    public async Task<Factura?> GetFacturaAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Factura>($"api/Facturas/{id}");
    }

    public async Task<List<Factura>?> GetFacturasByUsuarioAsync(int usuarioId)
    {
        return await _httpClient.GetFromJsonAsync<List<Factura>>($"api/Facturas/Usuario/{usuarioId}");
    }

    public async Task<Factura?> CreateFacturaAsync(Factura factura)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Facturas", factura);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Factura>();
    }

    public async Task DeleteFacturaAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Facturas/{id}");
        response.EnsureSuccessStatusCode();
    }
}
