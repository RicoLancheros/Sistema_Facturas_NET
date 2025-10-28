using BackEnd_Facturas_NET.Models;

namespace BackEnd_Facturas_NET.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        // Asegurar que la base de datos esté creada
        context.Database.EnsureCreated();

        // Si ya hay usuarios, significa que ya se inicializó
        if (context.Usuarios.Any())
        {
            return;
        }

        // Usuarios de prueba
        var usuarios = new Usuario[]
        {
            new Usuario { Nombre = "Juan Pérez" },
            new Usuario { Nombre = "María García" },
            new Usuario { Nombre = "Carlos López" }
        };

        context.Usuarios.AddRange(usuarios);
        context.SaveChanges();

        // Productos de prueba
        var productos = new Producto[]
        {
            new Producto { Nombre = "Laptop Dell", Cantidad = 10 },
            new Producto { Nombre = "Mouse Logitech", Cantidad = 50 },
            new Producto { Nombre = "Teclado Mecánico", Cantidad = 25 },
            new Producto { Nombre = "Monitor Samsung 24\"", Cantidad = 15 },
            new Producto { Nombre = "Webcam HD", Cantidad = 30 },
            new Producto { Nombre = "Audífonos Bluetooth", Cantidad = 40 },
            new Producto { Nombre = "Disco Duro 1TB", Cantidad = 20 },
            new Producto { Nombre = "Memoria RAM 16GB", Cantidad = 35 },
            new Producto { Nombre = "Impresora HP", Cantidad = 8 },
            new Producto { Nombre = "Cable HDMI", Cantidad = 100 }
        };

        context.Productos.AddRange(productos);
        context.SaveChanges();
    }
}
