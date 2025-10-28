namespace FrontEnd_Facturas_NET.Models;

public class DetalleFactura
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public Producto? Producto { get; set; }
}
