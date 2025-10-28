using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Facturas_NET.Models;

public class DetalleFactura
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int FacturaId { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [Required]
    public int Cantidad { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PrecioUnitario { get; set; }

    // Relaciones
    [ForeignKey("FacturaId")]
    public Factura? Factura { get; set; }

    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }
}
