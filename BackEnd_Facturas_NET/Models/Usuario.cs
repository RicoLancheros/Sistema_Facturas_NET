using System.ComponentModel.DataAnnotations;

namespace BackEnd_Facturas_NET.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    // Relación con Facturas
    public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
