using BackEnd_Facturas_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Facturas_NET.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<DetalleFactura> DetallesFactura { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de relaciones

        // Usuario -> Factura (1:N)
        modelBuilder.Entity<Factura>()
            .HasOne(f => f.Usuario)
            .WithMany(u => u.Facturas)
            .HasForeignKey(f => f.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        // Factura -> DetalleFactura (1:N)
        modelBuilder.Entity<DetalleFactura>()
            .HasOne(d => d.Factura)
            .WithMany(f => f.Detalles)
            .HasForeignKey(d => d.FacturaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Producto -> DetalleFactura (1:N)
        modelBuilder.Entity<DetalleFactura>()
            .HasOne(d => d.Producto)
            .WithMany(p => p.DetallesFactura)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índices
        modelBuilder.Entity<Factura>()
            .HasIndex(f => f.UsuarioId);

        modelBuilder.Entity<DetalleFactura>()
            .HasIndex(d => d.FacturaId);

        modelBuilder.Entity<DetalleFactura>()
            .HasIndex(d => d.ProductoId);
    }
}
