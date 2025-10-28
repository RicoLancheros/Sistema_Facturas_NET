# Sistema de Facturas .NET

## Descripcion

Sistema de facturacion simplificado que funciona como mini e-commerce. Permite gestionar productos, usuarios y generar facturas a traves de un carrito de compras. Este proyecto fue desarrollado con fines educativos para aprender la creacion de aplicaciones web con .NET y Entity Framework Core.

## Tecnologias Implementadas

**Backend:**
- ASP.NET Core 9.0 Web API
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI

**Frontend:**
- Blazor WebAssembly
- MudBlazor (Material Design)
- HttpClient para consumo de API

**Base de Datos:**
- SQL Server 2022 en Docker
- Migraciones automaticas con EF Core

## Manual de Instalacion

### Requisitos Previos

- .NET SDK 9.0 o superior
- Docker Desktop
- Git

### Paso 1: Clonar el Repositorio

```bash
git clone https://github.com/RicoLancheros/Sistema_Facturas_NET.git
cd Sistema_Facturas_NET
```

### Paso 2: Iniciar la Base de Datos

Ejecutar el contenedor de SQL Server en Docker:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

### Paso 3: Ejecutar el Backend

```bash
cd BackEnd_Facturas_NET
dotnet restore
dotnet run
```

El backend estara disponible en: `http://localhost:5250`

Swagger UI: `http://localhost:5250/swagger`

### Paso 4: Ejecutar el Frontend

Abrir una nueva terminal:

```bash
cd FrontEnd_Facturas_NET
dotnet restore
dotnet run
```

El frontend estara disponible en el puerto indicado en la consola (generalmente `http://localhost:5102`)

## Guia de Uso

### Navegacion en la Aplicacion

**Pagina Principal (Home):**
- Muestra el catalogo de productos disponibles
- Permite agregar productos al carrito con el boton "Agregar al Carrito"
- Muestra el contador de items en el carrito en la barra de navegacion

**Carrito de Compras:**
- Visualiza todos los productos agregados
- Permite modificar cantidades
- Permite eliminar productos
- Seleccionar el cliente que realizara la compra
- Boton "Realizar Compra" para generar la factura

**Consulta de Facturas:**
- Lista todas las facturas generadas
- Boton de visualizacion (icono de ojo) para ver detalles de cada factura
- Muestra usuario, fecha, productos y total
- Opcion para eliminar facturas

**Gestion de Usuarios:**
- CRUD completo de usuarios
- Crear, editar y eliminar usuarios

**Gestion de Productos:**
- CRUD completo de productos
- Administrar nombre, descripcion y precio

### Probar los Endpoints de la API

La API incluye documentacion interactiva con Swagger. Acceder a `http://localhost:5250/swagger` para:

**Endpoints principales:**

**Usuarios:**
- GET `/api/usuarios` - Obtener todos los usuarios
- GET `/api/usuarios/{id}` - Obtener usuario por ID
- POST `/api/usuarios` - Crear nuevo usuario
- PUT `/api/usuarios/{id}` - Actualizar usuario
- DELETE `/api/usuarios/{id}` - Eliminar usuario

**Productos:**
- GET `/api/productos` - Obtener todos los productos
- GET `/api/productos/{id}` - Obtener producto por ID
- POST `/api/productos` - Crear nuevo producto
- PUT `/api/productos/{id}` - Actualizar producto
- DELETE `/api/productos/{id}` - Eliminar producto

**Facturas:**
- GET `/api/facturas` - Obtener todas las facturas con sus detalles
- GET `/api/facturas/{id}` - Obtener factura por ID
- POST `/api/facturas` - Crear nueva factura
- DELETE `/api/facturas/{id}` - Eliminar factura

**Ejemplo de creacion de factura:**

```json
POST /api/facturas
{
  "usuarioId": 1,
  "detalles": [
    {
      "productoId": 1,
      "cantidad": 2,
      "precioUnitario": 50000
    },
    {
      "productoId": 2,
      "cantidad": 1,
      "precioUnitario": 150000
    }
  ]
}
```

## Informacion Importante

### Datos de Prueba

La aplicacion incluye un inicializador de datos (`DbInitializer`) que crea automaticamente:
- 5 usuarios de ejemplo
- 6 productos de ejemplo (laptops, mouse, teclados, monitores)

Estos datos se cargan la primera vez que se ejecuta el backend.

### Configuracion de la Base de Datos

La cadena de conexion se encuentra en `BackEnd_Facturas_NET/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=FacturasDB;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true;"
}
```

Esta configuracion es solo para desarrollo local con Docker.

### Migraciones

Las migraciones de Entity Framework se aplican automaticamente al iniciar el backend. No es necesario ejecutar comandos adicionales.

### CORS

El backend esta configurado con CORS abierto para desarrollo. En produccion, esto deberia restringirse a origenes especificos.

## Estructura del Proyecto

```
Sistema_Facturas_NET/
│
├── BackEnd_Facturas_NET/     # API REST con ASP.NET Core
│   ├── Controllers/           # Controladores de la API
│   ├── Data/                  # Contexto de EF Core e inicializador
│   ├── Models/                # Entidades del dominio
│   └── Migrations/            # Migraciones de base de datos
│
└── FrontEnd_Facturas_NET/     # Aplicacion Blazor WebAssembly
    ├── Pages/                 # Componentes de paginas
    ├── Services/              # Servicios para consumo de API
    ├── Models/                # Modelos del frontend
    └── Shared/                # Componentes compartidos
```

## Autor

Rico Lancheros
