using BackEnd_Facturas_NET.Data;
using BackEnd_Facturas_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Facturas_NET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacturasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FacturasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Facturas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
    {
        return await _context.Facturas
            .Include(f => f.Usuario)
            .Include(f => f.Detalles)
                .ThenInclude(d => d.Producto)
            .ToListAsync();
    }

    // GET: api/Facturas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Factura>> GetFactura(int id)
    {
        var factura = await _context.Facturas
            .Include(f => f.Usuario)
            .Include(f => f.Detalles)
                .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (factura == null)
        {
            return NotFound();
        }

        return factura;
    }

    // GET: api/Facturas/Usuario/5
    [HttpGet("Usuario/{usuarioId}")]
    public async Task<ActionResult<IEnumerable<Factura>>> GetFacturasByUsuario(int usuarioId)
    {
        return await _context.Facturas
            .Include(f => f.Detalles)
                .ThenInclude(d => d.Producto)
            .Where(f => f.UsuarioId == usuarioId)
            .ToListAsync();
    }

    // POST: api/Facturas
    [HttpPost]
    public async Task<ActionResult<Factura>> PostFactura(Factura factura)
    {
        // Calcular el total basado en los detalles
        factura.Total = factura.Detalles.Sum(d => d.PrecioUnitario * d.Cantidad);
        factura.Fecha = DateTime.Now;

        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();

        // Cargar las relaciones para retornar
        await _context.Entry(factura)
            .Reference(f => f.Usuario)
            .LoadAsync();

        await _context.Entry(factura)
            .Collection(f => f.Detalles)
            .LoadAsync();

        foreach (var detalle in factura.Detalles)
        {
            await _context.Entry(detalle)
                .Reference(d => d.Producto)
                .LoadAsync();
        }

        return CreatedAtAction(nameof(GetFactura), new { id = factura.Id }, factura);
    }

    // DELETE: api/Facturas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFactura(int id)
    {
        var factura = await _context.Facturas.FindAsync(id);
        if (factura == null)
        {
            return NotFound();
        }

        _context.Facturas.Remove(factura);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FacturaExists(int id)
    {
        return _context.Facturas.Any(e => e.Id == id);
    }
}
