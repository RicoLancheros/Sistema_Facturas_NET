using FrontEnd_Facturas_NET.Models;

namespace FrontEnd_Facturas_NET.Services;

public class CarritoService
{
    public event Action? OnChange;

    private List<ItemCarrito> _items = new();

    public List<ItemCarrito> ObtenerItems() => _items;

    public int ObtenerCantidadTotal() => _items.Sum(x => x.Cantidad);

    public decimal ObtenerTotal() => _items.Sum(x => x.Cantidad * x.PrecioUnitario);

    public void AgregarAlCarrito(Producto producto, int cantidad = 1, decimal precio = 0)
    {
        var itemExistente = _items.FirstOrDefault(x => x.ProductoId == producto.Id);

        if (itemExistente != null)
        {
            itemExistente.Cantidad += cantidad;
        }
        else
        {
            _items.Add(new ItemCarrito
            {
                ProductoId = producto.Id,
                ProductoNombre = producto.Nombre,
                Cantidad = cantidad,
                PrecioUnitario = precio
            });
        }

        NotificarCambio();
    }

    public void ActualizarCantidad(int productoId, int cantidad)
    {
        var item = _items.FirstOrDefault(x => x.ProductoId == productoId);
        if (item != null)
        {
            if (cantidad <= 0)
            {
                _items.Remove(item);
            }
            else
            {
                item.Cantidad = cantidad;
            }
            NotificarCambio();
        }
    }

    public void EliminarDelCarrito(int productoId)
    {
        var item = _items.FirstOrDefault(x => x.ProductoId == productoId);
        if (item != null)
        {
            _items.Remove(item);
            NotificarCambio();
        }
    }

    public void LimpiarCarrito()
    {
        _items.Clear();
        NotificarCambio();
    }

    private void NotificarCambio() => OnChange?.Invoke();
}

public class ItemCarrito
{
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}
