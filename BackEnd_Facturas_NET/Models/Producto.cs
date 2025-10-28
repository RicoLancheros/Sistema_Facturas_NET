using System.ComponentModel.DataAnnotations;

namespace BackEnd_Facturas_NET.Models;

public class Producto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public int Cantidad { get; set; }

    // Relación con DetallesFactura
    public ICollection<DetalleFactura> DetallesFactura { get; set; } = new List<DetalleFactura>();
}
