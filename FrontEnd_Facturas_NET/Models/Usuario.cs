using System.Text.Json.Serialization;

namespace FrontEnd_Facturas_NET.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Factura>? Facturas { get; set; }
}
