using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontEnd_Facturas_NET;
using FrontEnd_Facturas_NET.Services;
using MudBlazor.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient para conectarse al backend
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5250/")
});

// Agregar servicios personalizados
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddSingleton<CarritoService>();

// Agregar MudBlazor
builder.Services.AddMudServices();

// Agregar LocalStorage
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
