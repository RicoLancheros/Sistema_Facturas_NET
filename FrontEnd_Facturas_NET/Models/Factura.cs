namespace FrontEnd_Facturas_NET.Models;

public class Factura
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public Usuario? Usuario { get; set; }
    public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
}
