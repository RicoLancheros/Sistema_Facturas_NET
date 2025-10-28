using FrontEnd_Facturas_NET.Models;
using System.Net.Http.Json;

namespace FrontEnd_Facturas_NET.Services;

public class UsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Usuario>?> GetUsuariosAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/Usuarios");
    }

    public async Task<Usuario?> GetUsuarioAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Usuario>($"api/Usuarios/{id}");
    }

    public async Task<Usuario?> CreateUsuarioAsync(Usuario usuario)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Usuarios", usuario);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Usuario>();
    }

    public async Task UpdateUsuarioAsync(int id, Usuario usuario)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Usuarios/{id}", usuario);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Usuarios/{id}");
        response.EnsureSuccessStatusCode();
    }
}
