using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Facturas_NET.Models;

public class Factura
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UsuarioId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    // Relaciones
    [ForeignKey("UsuarioId")]
    public Usuario? Usuario { get; set; }

    public ICollection<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
}
