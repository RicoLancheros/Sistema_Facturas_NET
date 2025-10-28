# 🏗️ ARQUITECTURA DEL PROYECTO - Sistema_Facturas_NET

## 📋 Información General del Proyecto

- **Nombre del Proyecto**: Sistema_Facturas_NET
- **Tipo**: Aplicación Web Full Stack
- **Framework**: .NET 8.0
- **Patrón de Arquitectura**: Cliente-Servidor con API RESTful
- **Entorno**: Desarrollo Local (sin despliegue)
- Repositorio en github (Solo esta iniciado, no esta conectado): https://github.com/RicoLancheros/Sistema_Facturas_NET

---

## 🎯 Stack Tecnológico

### Backend (API)
- **Nombre del Proyecto**: `BackEnd_Facturas_NET`
- **Framework**: ASP.NET Core Web API 8.0
- **ORM**: Entity Framework Core 8.0
- **Base de Datos**: SQL Server (LocalDB)
- **Autenticación**: JWT (JSON Web Tokens)
- **Generación de PDFs**: QuestPDF
- **Encriptación**: BCrypt.Net-Next
- **Documentación API**: Swagger/OpenAPI

### Frontend
- **Nombre del Proyecto**: `FrontEnd_Facturas_NET`
- **Framework**: Blazor WebAssembly Standalone
- **Versión**: .NET 8.0
- **Almacenamiento Local**: Blazored.LocalStorage
- **Componentes UI**: MudBlazor (opcional)
- **HTTP Client**: System.Net.Http.Json

---

## 📁 Estructura de la Solución

```
Sistema_Facturas_NET/
│
├── BackEnd_Facturas_NET/           # Proyecto API (.NET 8.0 Web API)
│   ├── Controllers/                # Controladores de la API
│   │   ├── AuthController.cs       # Autenticación y registro
│   │   ├── ProductosController.cs  # CRUD de productos
│   │   ├── CarritoController.cs    # Gestión del carrito
│   │   ├── OrdenesController.cs    # Procesamiento de órdenes
│   │   └── FacturasController.cs   # Generación de facturas
│   │
│   ├── Data/                       # Capa de datos
│   │   ├── ApplicationDbContext.cs # DbContext de EF Core
│   │   └── DbInitializer.cs        # Datos iniciales (seed)
│   │
│   ├── Models/                     # Entidades del dominio
│   │   ├── Usuario.cs              # Entidad Usuario
│   │   ├── Producto.cs             # Entidad Producto
│   │   ├── Categoria.cs            # Entidad Categoría
│   │   ├── Orden.cs                # Entidad Orden (pedido)
│   │   ├── DetalleOrden.cs         # Detalle de cada orden
│   │   └── Factura.cs              # Entidad Factura
│   │
│   ├── DTOs/                       # Data Transfer Objects
│   │   ├── Auth/
│   │   │   ├── LoginRequestDto.cs
│   │   │   ├── RegisterRequestDto.cs
│   │   │   └── AuthResponseDto.cs
│   │   ├── Productos/
│   │   │   ├── ProductoDto.cs
│   │   │   └── CreateProductoDto.cs
│   │   ├── Carrito/
│   │   │   └── CarritoItemDto.cs
│   │   ├── Ordenes/
│   │   │   ├── CreateOrdenDto.cs
│   │   │   └── OrdenDto.cs
│   │   └── Facturas/
│   │       └── FacturaDto.cs
│   │
│   ├── Services/                   # Lógica de negocio
│   │   ├── Interfaces/
│   │   │   ├── IAuthService.cs
│   │   │   ├── IProductoService.cs
│   │   │   ├── IOrdenService.cs
│   │   │   └── IFacturaService.cs
│   │   └── Implementations/
│   │       ├── AuthService.cs
│   │       ├── ProductoService.cs
│   │       ├── OrdenService.cs
│   │       └── FacturaService.cs
│   │
│   ├── Helpers/                    # Utilidades
│   │   ├── JwtHelper.cs            # Generación de tokens JWT
│   │   └── PdfHelper.cs            # Generación de PDFs
│   │
│   ├── Migrations/                 # Migraciones de EF Core (auto-generadas)
│   │
│   ├── Program.cs                  # Configuración de la aplicación
│   ├── appsettings.json            # Configuración general
│   └── appsettings.Development.json # Configuración de desarrollo
│
│
├── FrontEnd_Facturas_NET/          # Proyecto Blazor WebAssembly
│   ├── Pages/                      # Páginas de la aplicación
│   │   ├── Index.razor             # Página principal (catálogo)
│   │   ├── Login.razor             # Página de inicio de sesión
│   │   ├── Register.razor          # Página de registro
│   │   ├── Carrito.razor           # Página del carrito
│   │   ├── Checkout.razor          # Proceso de pago
│   │   ├── MisOrdenes.razor        # Historial de órdenes
│   │   ├── DetalleOrden.razor      # Detalle de una orden
│   │   └── Admin/                  # Páginas de administración
│   │       ├── Dashboard.razor
│   │       ├── Productos.razor     # CRUD de productos
│   │       └── GestionOrdenes.razor
│   │
│   ├── Shared/                     # Componentes compartidos
│   │   ├── MainLayout.razor        # Layout principal
│   │   ├── NavMenu.razor           # Menú de navegación
│   │   └── ProductoCard.razor      # Tarjeta de producto
│   │
│   ├── Components/                 # Componentes reutilizables
│   │   ├── CarritoComponent.razor
│   │   ├── ProductoListComponent.razor
│   │   └── PasarelaPagosComponent.razor
│   │
│   ├── Models/                     # Modelos del frontend
│   │   ├── ProductoModel.cs
│   │   ├── CarritoItemModel.cs
│   │   ├── OrdenModel.cs
│   │   └── UsuarioModel.cs
│   │
│   ├── Services/                   # Servicios HTTP
│   │   ├── AuthService.cs          # Servicio de autenticación
│   │   ├── ProductoService.cs      # Servicio de productos
│   │   ├── CarritoService.cs       # Servicio del carrito
│   │   ├── OrdenService.cs         # Servicio de órdenes
│   │   └── FacturaService.cs       # Servicio de facturas
│   │
│   ├── wwwroot/                    # Archivos estáticos
│   │   ├── css/
│   │   │   └── app.css             # Estilos personalizados
│   │   ├── js/
│   │   └── index.html              # HTML principal
│   │
│   ├── Program.cs                  # Configuración de Blazor
│   ├── _Imports.razor              # Imports globales
│   └── App.razor                   # Componente raíz
│
│
└── README.md                       # Documentación del proyecto
```

---

## 🗄️ Modelo de Base de Datos

### Entidades Principales

#### 1. **Usuario**
```
Id (int, PK)
Nombre (string)
Email (string, unique)
PasswordHash (string)
Rol (string) - "Admin" o "Cliente"
FechaRegistro (DateTime)
```

#### 2. **Categoria**
```
Id (int, PK)
Nombre (string)
Descripcion (string)
```

#### 3. **Producto**
```
Id (int, PK)
Nombre (string)
Descripcion (string)
Precio (decimal)
Stock (int)
ImagenUrl (string)
CategoriaId (int, FK)
FechaCreacion (DateTime)
Activo (bool)
```

#### 4. **Orden**
```
Id (int, PK)
UsuarioId (int, FK)
FechaOrden (DateTime)
Total (decimal)
Estado (string) - "Pendiente", "Pagado", "Cancelado"
MetodoPago (string) - "TarjetaCredito", "TarjetaDebito", "PayPal"
```

#### 5. **DetalleOrden**
```
Id (int, PK)
OrdenId (int, FK)
ProductoId (int, FK)
Cantidad (int)
PrecioUnitario (decimal)
Subtotal (decimal)
```

#### 6. **Factura**
```
Id (int, PK)
OrdenId (int, FK)
NumeroFactura (string, unique)
FechaEmision (DateTime)
RutaPDF (string)
```

### Relaciones
- Usuario 1:N Orden
- Orden 1:N DetalleOrden
- Producto 1:N DetalleOrden
- Categoria 1:N Producto
- Orden 1:1 Factura

---

## ⚙️ Configuración de Entity Framework Core

### Connection String (appsettings.json)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FacturasDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

### Migraciones
```bash
# Crear migración inicial
dotnet ef migrations add InitialCreate --project BackEnd_Facturas_NET

# Aplicar migración a la base de datos
dotnet ef database update --project BackEnd_Facturas_NET
```

---

## 🔐 Sistema de Autenticación

### JWT Configuration (appsettings.json)
```json
{
  "JwtSettings": {
    "SecretKey": "MiClaveSecretaSuperSegura12345678901234567890",
    "Issuer": "BackEnd_Facturas_NET",
    "Audience": "FrontEnd_Facturas_NET",
    "ExpirationMinutes": 60
  }
}
```

### Roles del Sistema
- **Admin**: Gestión completa de productos, visualización de todas las órdenes
- **Cliente**: Compra de productos, gestión de carrito, visualización de sus órdenes

---

## 🌐 Configuración de CORS

### Backend (Program.cs)
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        policy =>
        {
            policy.WithOrigins("https://localhost:7XXX") // Puerto del frontend
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});
```

---

## 📦 Paquetes NuGet Requeridos

### BackEnd_Facturas_NET
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.x" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.x" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.x" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.x" />
<PackageReference Include="BCrypt.Net-Next" Version="4.0.x" />
<PackageReference Include="QuestPDF" Version="2024.x.x" />
```

### FrontEnd_Facturas_NET
```xml
<PackageReference Include="Blazored.LocalStorage" Version="4.5.x" />
<PackageReference Include="MudBlazor" Version="7.x.x" />
```

---

## 🔌 Endpoints de la API

### Autenticación (`/api/auth`)
- `POST /register` - Registro de usuarios
- `POST /login` - Inicio de sesión (retorna JWT)

### Productos (`/api/productos`)
- `GET /` - Listar todos los productos activos
- `GET /{id}` - Obtener producto por ID
- `GET /categoria/{categoriaId}` - Productos por categoría
- `POST /` - Crear producto (Admin)
- `PUT /{id}` - Actualizar producto (Admin)
- `DELETE /{id}` - Eliminar producto (Admin)

### Categorías (`/api/categorias`)
- `GET /` - Listar todas las categorías
- `POST /` - Crear categoría (Admin)

### Órdenes (`/api/ordenes`)
- `GET /` - Listar órdenes del usuario autenticado
- `GET /{id}` - Detalle de una orden
- `POST /` - Crear nueva orden
- `GET /admin/todas` - Todas las órdenes (Admin)

### Facturas (`/api/facturas`)
- `GET /{ordenId}` - Obtener factura de una orden
- `GET /{ordenId}/pdf` - Descargar PDF de la factura

---

## 🎨 Flujo de Usuario

### Cliente
1. **Registro/Login** → Autenticación JWT
2. **Navegación** → Catálogo de productos
3. **Selección** → Agregar productos al carrito (LocalStorage)
4. **Checkout** → Revisar carrito y proceder al pago
5. **Pasarela de Pagos** → Simulación de pago
6. **Confirmación** → Creación de orden en la base de datos
7. **Factura** → Generación automática de PDF

### Administrador
1. **Login** → Acceso con rol Admin
2. **Dashboard** → Panel de administración
3. **Gestión de Productos** → CRUD completo
4. **Gestión de Categorías** → Crear/Editar categorías
5. **Visualización de Órdenes** → Ver todas las órdenes del sistema

---

## 🚀 Configuración de Puertos

### Desarrollo Local
- **Backend API**: `https://localhost:7001` (ajustar según configuración)
- **Frontend Blazor**: `https://localhost:7002` (ajustar según configuración)

### Configurar Proyectos de Inicio Múltiples
En Visual Studio:
1. Click derecho en la solución → Properties
2. Startup Project → Multiple startup projects
3. Establecer ambos proyectos en "Start"

---

## 🛠️ Comandos Útiles de Entity Framework

```bash
# Crear una nueva migración
dotnet ef migrations add NombreDeLaMigracion -p BackEnd_Facturas_NET

# Aplicar migraciones pendientes
dotnet ef database update -p BackEnd_Facturas_NET

# Revertir última migración
dotnet ef database update NombreMigracionAnterior -p BackEnd_Facturas_NET

# Eliminar última migración (sin aplicar)
dotnet ef migrations remove -p BackEnd_Facturas_NET

# Ver el SQL que generará una migración
dotnet ef migrations script -p BackEnd_Facturas_NET

# Eliminar la base de datos
dotnet ef database drop -p BackEnd_Facturas_NET
```

---

## 📝 Convenciones de Código

### Nombres
- **Clases**: PascalCase (ej: `ProductoController`, `AuthService`)
- **Métodos**: PascalCase (ej: `GetAllProductos`, `CreateOrden`)
- **Propiedades**: PascalCase (ej: `Nombre`, `PrecioUnitario`)
- **Parámetros y variables**: camelCase (ej: `productoId`, `userName`)
- **Constantes**: UPPER_CASE (ej: `MAX_ITEMS_CARRITO`)

### DTOs
- Sufijo `Dto` para Data Transfer Objects
- Prefijo según acción: `CreateProductoDto`, `UpdateProductoDto`

### Servicios
- Interfaz: `I` + nombre del servicio (ej: `IProductoService`)
- Implementación: nombre del servicio (ej: `ProductoService`)

---

## 🔒 Seguridad

### Contraseñas
- Encriptación con BCrypt
- Nunca almacenar contraseñas en texto plano
- Salt rounds: 12

### JWT
- Token en el header: `Authorization: Bearer {token}`
- Expiración: 60 minutos
- Almacenamiento en LocalStorage del frontend

### Validaciones
- Validación de datos en DTOs con Data Annotations
- Validación de autorización en controladores con `[Authorize]`
- Validación de roles con `[Authorize(Roles = "Admin")]`

---

## 📊 Datos de Prueba (Seed Data)

### Usuarios Iniciales
```
Admin:
- Email: admin@facturas.com
- Password: Admin123!
- Rol: Admin

Cliente:
- Email: cliente@facturas.com
- Password: Cliente123!
- Rol: Cliente
```

### Categorías Iniciales
- Frutas
- Comida
- Tecnología
- Electrónica
- Hogar

### Productos de Ejemplo
Mínimo 10 productos distribuidos en diferentes categorías con datos realistas.

---

## 🎯 Funcionalidades Principales

### Módulo de Productos
- ✅ Listado de productos con filtros por categoría
- ✅ Búsqueda de productos
- ✅ Detalle de producto
- ✅ CRUD completo (Admin)
- ✅ Control de stock

### Módulo de Carrito
- ✅ Agregar productos al carrito
- ✅ Modificar cantidad
- ✅ Eliminar productos
- ✅ Calcular total
- ✅ Persistencia en LocalStorage

### Módulo de Órdenes
- ✅ Crear orden desde el carrito
- ✅ Historial de órdenes del usuario
- ✅ Detalle de orden
- ✅ Estados de orden

### Módulo de Facturación
- ✅ Generación automática al completar orden
- ✅ Número de factura único y secuencial
- ✅ Exportación a PDF
- ✅ Descarga de factura

### Pasarela de Pagos (Simulada)
- ✅ Selección de método de pago
- ✅ Formulario de datos de pago
- ✅ Validación básica
- ✅ Confirmación de pago (simulado - siempre exitoso)

---

## 🧪 Testing (Opcional)

### Pruebas Recomendadas
- Unit tests para servicios
- Integration tests para API endpoints
- End-to-end tests para flujos críticos (login, compra)

### Frameworks Sugeridos
- xUnit para tests del backend
- bUnit para tests de componentes Blazor

---

## 📱 Responsive Design

El frontend debe ser responsive y funcionar correctamente en:
- Desktop (1920x1080 y superiores)
- Tablet (768px - 1024px)
- Mobile (320px - 767px)

---

## 🎨 Diseño UI/UX

### Framework CSS
- Bootstrap 5 (incluido por defecto)
- Opcionalmente MudBlazor para componentes más avanzados

### Paleta de Colores Sugerida
- Primario: #007bff (azul)
- Secundario: #6c757d (gris)
- Éxito: #28a745 (verde)
- Peligro: #dc3545 (rojo)
- Advertencia: #ffc107 (amarillo)

### Componentes Clave
- Navbar con logo y menú
- Cards para productos
- Modals para confirmaciones
- Toasts para notificaciones
- Loading spinners para operaciones async

---

## 📖 Documentación Adicional

- Swagger UI disponible en: `https://localhost:7001/swagger`
- Documentación de QuestPDF: https://www.questpdf.com/
- Documentación de Blazored.LocalStorage: https://github.com/Blazored/LocalStorage
- Documentación de MudBlazor: https://mudblazor.com/

---

## 🔄 Workflow de Desarrollo

1. **Modelos** → Definir entidades en `Models/`
2. **DbContext** → Configurar en `Data/ApplicationDbContext.cs`
3. **Migración** → Crear y aplicar con EF Core
4. **DTOs** → Crear objetos de transferencia
5. **Servicios** → Implementar lógica de negocio
6. **Controladores** → Crear endpoints REST
7. **Frontend Services** → Crear servicios HTTP
8. **Páginas Blazor** → Crear UI y conectar con servicios
9. **Estilos** → Aplicar CSS y diseño responsive
10. **Testing** → Probar todas las funcionalidades

---

## ⚠️ Notas Importantes

- Este proyecto es **únicamente para aprendizaje**, no está optimizado para producción
- La pasarela de pagos es **simulada** - no procesa pagos reales, Solo va a ser un boton de "Aceptar pago" y ya.
- No se implementa recuperación de contraseñas ni verificación de email
- Los tokens JWT se almacenan en LocalStorage (en producción usar cookies HttpOnly)
- SQL Server LocalDB es suficiente para desarrollo local
- No se requiere despliegue ni configuración de servidores

---

## 🎓 Objetivos de Aprendizaje

Este proyecto permite practicar:
- ✅ Arquitectura Cliente-Servidor
- ✅ API RESTful con ASP.NET Core
- ✅ Entity Framework Core y Migraciones
- ✅ Autenticación y Autorización con JWT
- ✅ Blazor WebAssembly
- ✅ Gestión de estado en el frontend
- ✅ CORS y comunicación entre proyectos
- ✅ Patrones de diseño (Repository, Service Layer)
- ✅ CRUD completo
- ✅ Manejo de relaciones en bases de datos

---

**Versión de Arquitectura**: 1.0  
**Última Actualización**: Octubre 2025  
**Framework Target**: .NET 8.0