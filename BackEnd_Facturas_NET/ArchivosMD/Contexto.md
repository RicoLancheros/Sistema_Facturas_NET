# 📄 CONTEXTO DEL PROYECTO - Sistema_Facturas_NET

## 🎯 Propósito del Proyecto

**Sistema_Facturas_NET** es un proyecto de aprendizaje diseñado para desarrollar una aplicación web completa de comercio electrónico con sistema de facturación integrado. El objetivo principal es practicar y dominar tecnologías modernas del ecosistema .NET, específicamente Blazor WebAssembly y ASP.NET Core Web API.

---

## 🎓 Finalidad Educativa

Este proyecto **NO está destinado a producción**. Es un entorno de práctica para:

1. **Dominar Blazor WebAssembly**: Aprender a crear aplicaciones frontend modernas con C# en lugar de JavaScript
2. **API RESTful con .NET**: Diseñar e implementar un backend robusto siguiendo las mejores prácticas
3. **Entity Framework Core**: Trabajar con migraciones automáticas y Code-First approach
4. **Autenticación JWT**: Implementar sistemas de seguridad modernos
5. **Arquitectura de Microservicios**: Separar frontend y backend como proyectos independientes
6. **Generación de Documentos**: Crear facturas en PDF programáticamente
7. **Gestión de Estado**: Manejar carrito de compras y sesiones de usuario

---

## 🛍️ ¿Qué es el Sistema?

Una **tienda online simplificada** donde:

### Para Clientes:
- Navegan por un catálogo de productos (frutas, comidas, tecnología, etc.)
- Agregan productos a un carrito de compras
- Procesan el pago a través de una pasarela simulada
- Reciben una factura en PDF automáticamente generada

### Para Administradores:
- Gestionan el catálogo completo de productos (crear, editar, eliminar)
- Administran categorías de productos
- Visualizan todas las órdenes realizadas en el sistema
- Tienen acceso a un panel de administración

---

## 🚫 Lo que NO es el Proyecto

- ❌ No es un sistema de producción real
- ❌ No procesa pagos reales (la pasarela es simulada)
- ❌ No se desplegará en ningún servidor
- ❌ No tiene sistemas avanzados de seguridad para producción
- ❌ No incluye recuperación de contraseñas ni verificación de email
- ❌ No tiene sistema de inventario avanzado ni logística

---

## 🎯 Alcance Funcional

### ✅ Funcionalidades Incluidas

#### Gestión de Usuarios
- Registro de nuevos usuarios
- Inicio de sesión con email y contraseña
- Sistema de roles (Admin y Cliente)
- Autenticación mediante JWT tokens

#### Catálogo de Productos
- Listado de productos con imagen, nombre, precio
- Filtrado por categorías
- Búsqueda de productos (opcional)
- Vista detallada de cada producto
- Control de stock disponible

#### Carrito de Compras
- Agregar productos al carrito
- Modificar cantidades
- Eliminar productos del carrito
- Cálculo automático del total
- Persistencia del carrito en LocalStorage

#### Proceso de Compra
- Revisión del carrito antes de pagar
- Pasarela de pagos simulada con 3 métodos:
  - Tarjeta de crédito
  - Tarjeta de débito
  - PayPal (todo simulado)
- Confirmación de la orden

#### Sistema de Órdenes
- Creación de orden al confirmar pago
- Historial de órdenes del usuario
- Detalle completo de cada orden
- Estados de orden: Pendiente, Pagado, Cancelado

#### Facturación Automática
- Generación automática al confirmar orden
- Número de factura único y secuencial
- Exportación a PDF descargable
- Incluye detalle completo de productos, precios y total

#### Panel de Administración
- CRUD completo de productos
- CRUD de categorías
- Visualización de todas las órdenes
- Gestión de stock

### ❌ Funcionalidades NO Incluidas
- Sistema de envíos y seguimiento
- Métodos de pago reales
- Procesamiento de devoluciones
- Sistema de reviews o calificaciones
- Wishlist o lista de deseos
- Cupones o descuentos
- Notificaciones por email
- Chat de soporte
- Multi-idioma
- Multi-moneda

---

## 🏗️ Arquitectura Técnica

### Modelo Cliente-Servidor

```
┌─────────────────────────────────────┐
│   FrontEnd_Facturas_NET             │
│   (Blazor WebAssembly)              │
│   Puerto: https://localhost:7002    │
│                                      │
│   - Páginas Razor                   │
│   - Componentes UI                  │
│   - Servicios HTTP                  │
│   - LocalStorage (Carrito)          │
└───────────────┬─────────────────────┘
                │
                │ HTTP/REST API
                │ + JWT Token
                │
┌───────────────▼─────────────────────┐
│   BackEnd_Facturas_NET              │
│   (ASP.NET Core Web API)            │
│   Puerto: https://localhost:7001    │
│                                      │
│   - Controladores REST              │
│   - Entity Framework Core           │
│   - Servicios de Negocio            │
│   - Generación de PDFs              │
└───────────────┬─────────────────────┘
                │
                │ Entity Framework
                │ + Migrations
                │
┌───────────────▼─────────────────────┐
│   SQL Server LocalDB                │
│   Database: FacturasDB              │
│                                      │
│   - Usuarios                        │
│   - Productos                       │
│   - Categorías                      │
│   - Órdenes                         │
│   - Facturas                        │
└─────────────────────────────────────┘
```

---

## 📊 Modelo de Datos Simplificado

### Entidades Principales

**Usuario** → Representa a los usuarios del sistema
- Almacena credenciales (email y contraseña hasheada)
- Define el rol (Admin o Cliente)
- Se relaciona con las órdenes que crea

**Categoría** → Clasifica los productos
- Nombre de la categoría (Frutas, Tecnología, etc.)
- Descripción opcional

**Producto** → Los artículos a la venta
- Información básica: nombre, descripción, precio
- Stock disponible
- URL de imagen
- Pertenece a una categoría
- Tiene un estado activo/inactivo

**Orden** → Representa una compra realizada
- Pertenece a un usuario
- Contiene múltiples productos (detalles)
- Tiene un total calculado
- Estado de la orden
- Método de pago usado

**DetalleOrden** → Línea de productos en una orden
- Relaciona Orden con Producto
- Cantidad comprada
- Precio unitario al momento de la compra
- Subtotal calculado

**Factura** → Documento fiscal de la orden
- Se genera automáticamente al confirmar orden
- Número único y secuencial
- Ruta al archivo PDF generado
- Relación 1:1 con Orden

---

## 🔐 Sistema de Autenticación

### Flujo de Autenticación

1. **Registro**:
   - Usuario completa formulario (nombre, email, contraseña)
   - Backend valida datos y hasea contraseña con BCrypt
   - Se crea usuario con rol "Cliente" por defecto
   - Retorna token JWT

2. **Login**:
   - Usuario envía email y contraseña
   - Backend valida credenciales
   - Genera token JWT con claims (id, email, rol)
   - Frontend almacena token en LocalStorage
   - Token expira en 60 minutos

3. **Autorización**:
   - Cada petición al backend incluye el token en header
   - Backend valida token y verifica permisos
   - Rutas de Admin requieren rol específico

### Roles del Sistema

**Cliente** (por defecto):
- Ver catálogo de productos
- Agregar al carrito
- Realizar compras
- Ver sus propias órdenes
- Descargar sus facturas

**Admin** (creado manualmente en seed):
- Todo lo que puede hacer un Cliente
- Crear, editar, eliminar productos
- Gestionar categorías
- Ver todas las órdenes del sistema
- Acceder al panel de administración

---

## 💳 Pasarela de Pagos (Simulada)

### ¿Cómo Funciona?

**NO se procesa ningún pago real**. Es una simulación educativa:

1. Usuario selecciona método de pago:
   - Tarjeta de Crédito
   - Tarjeta de Débito
   - PayPal

2. Completa un formulario con datos ficticios:
   - Número de tarjeta (cualquier número)
   - Fecha de vencimiento
   - CVV
   - Nombre del titular

3. Al confirmar:
   - Frontend valida formato básico
   - Envía orden al backend
   - Backend **siempre aprueba** la transacción
   - Crea la orden en BD con estado "Pagado"
   - Genera factura automáticamente
   - Retorna confirmación al frontend

### Métodos de Pago Simulados
- **Tarjeta de Crédito**: Acepta cualquier número de 16 dígitos
- **Tarjeta de Débito**: Acepta cualquier número de 16 dígitos
- **PayPal**: Solo requiere email (no valida)

---

## 🧾 Sistema de Facturación

### Generación Automática de Facturas

Cuando una orden se marca como "Pagado":

1. **Trigger**: Al confirmar pago en el checkout
2. **Proceso**:
   - Se crea registro en tabla Facturas
   - Se genera número único (ej: FACT-2025-00001)
   - Se usa QuestPDF para crear documento
   - Se incluye logo, datos del cliente, detalle de productos
   - Se calcula subtotal, impuestos (opcional) y total
   - Se guarda PDF en disco
   - Se almacena ruta en base de datos
3. **Descarga**: Usuario puede descargar desde su historial

### Estructura de la Factura PDF

```
┌─────────────────────────────────────┐
│  LOGO        Sistema de Facturas    │
│                                      │
│  Factura N°: FACT-2025-00001        │
│  Fecha: 27/10/2025                  │
│                                      │
│  Cliente:                            │
│  Juan Pérez                         │
│  juan@email.com                     │
│                                      │
│  ──────────────────────────────────│
│  Detalle de Productos               │
│  ──────────────────────────────────│
│  Cant | Producto    | P.Unit | Sub  │
│   2   | Manzanas    | $1.50  | $3.00│
│   1   | iPhone 15   |$999.00 |$999  │
│  ──────────────────────────────────│
│                     Subtotal: $1,002│
│                     IVA 19%:  $190  │
│                     TOTAL:   $1,192 │
└─────────────────────────────────────┘
```

---

## 🛒 Gestión del Carrito

### Almacenamiento Local

El carrito se gestiona completamente en el **frontend** usando LocalStorage:

**Ventajas**:
- No requiere autenticación para agregar productos
- Persiste entre sesiones del navegador
- No consume recursos del servidor
- Rápido y responsive

**Estructura del Carrito**:
```json
{
  "items": [
    {
      "productoId": 1,
      "nombre": "Manzanas",
      "precio": 1.50,
      "cantidad": 2,
      "imagenUrl": "/images/manzanas.jpg"
    }
  ],
  "total": 3.00
}
```

**Flujo**:
1. Usuario agrega producto → Se guarda en LocalStorage
2. Usuario modifica cantidad → Se actualiza LocalStorage
3. Usuario va a checkout → Se envía todo al backend
4. Backend valida stock y precios antes de crear orden

---

## 🎨 Diseño de Interfaz

### Principios de Diseño

- **Simplicidad**: Interfaz clara y fácil de usar
- **Responsive**: Funciona en desktop, tablet y móvil
- **Moderna**: Diseño actual con Bootstrap 5 / MudBlazor
- **Intuitiva**: Navegación lógica y flujos claros

### Páginas Principales

1. **Home / Catálogo**: Grid de productos con filtros
2. **Detalle de Producto**: Información completa + botón agregar
3. **Carrito**: Lista de items con opciones de edición
4. **Checkout**: Formulario de pago simulado
5. **Mis Órdenes**: Historial de compras
6. **Admin Dashboard**: Panel de gestión (solo Admin)

### Componentes Clave

- **ProductoCard**: Tarjeta con imagen, nombre, precio, botón
- **NavBar**: Menú con links y carrito (muestra cantidad de items)
- **CarritoSidebar**: Panel lateral con resumen del carrito
- **ModalConfirmacion**: Para confirmar acciones críticas

---

## 🔄 Flujo Completo de Usuario

### Caso de Uso: Cliente Realiza una Compra

```
1. Usuario visita la página → Ve catálogo de productos

2. Navega por categorías → Selecciona "Tecnología"

3. Ve productos de tecnología → Click en "iPhone 15"

4. Ve detalle del producto → Click en "Agregar al Carrito"
   ├─ Producto se agrega a LocalStorage
   └─ Badge del carrito muestra: 1 item

5. Continúa comprando → Agrega "AirPods Pro"
   └─ Badge del carrito muestra: 2 items

6. Click en icono del carrito → Ve resumen de items

7. Click en "Proceder al Pago" → Redirige a Checkout

8. Completa formulario de pago:
   ├─ Selecciona "Tarjeta de Crédito"
   ├─ Ingresa datos ficticios
   └─ Click en "Confirmar Pago"

9. Frontend envía orden al backend:
   ├─ Backend valida stock disponible
   ├─ Backend crea Orden en BD
   ├─ Backend genera Factura en PDF
   └─ Backend retorna confirmación + ID de orden

10. Usuario ve página de confirmación:
    ├─ Mensaje de éxito
    ├─ Número de orden
    └─ Botón para descargar factura

11. Usuario va a "Mis Órdenes":
    ├─ Ve historial de compras
    ├─ Click en orden reciente
    └─ Ve detalle completo + descargar factura

12. Carrito se vacía automáticamente
```

---

## 👨‍💼 Caso de Uso: Administrador Gestiona Productos

```
1. Admin hace login con credenciales especiales

2. Ve menú con opción "Admin" → Click en "Panel Admin"

3. Ve dashboard con opciones:
   ├─ Gestionar Productos
   ├─ Gestionar Categorías
   └─ Ver Órdenes

4. Click en "Gestionar Productos" → Ve tabla con todos los productos

5. Click en "Nuevo Producto":
   ├─ Completa formulario (nombre, descripción, precio, stock, categoría)
   ├─ Sube imagen (URL)
   └─ Click en "Guardar"

6. Backend crea producto en BD → Frontend actualiza lista

7. Admin edita producto existente:
   ├─ Click en botón "Editar"
   ├─ Modifica stock de 50 a 100
   └─ Click en "Actualizar"

8. Admin desactiva producto:
   ├─ Click en botón "Desactivar"
   └─ Producto ya no aparece en catálogo de clientes

9. Admin revisa órdenes:
   ├─ Ve tabla con todas las órdenes
   ├─ Filtra por fecha o estado
   └─ Ve detalle de cada orden
```

---

## 🔧 Tecnologías y Herramientas

### Backend
- **Lenguaje**: C# 12
- **Framework**: ASP.NET Core 8.0 Web API
- **ORM**: Entity Framework Core 8.0
- **Base de Datos**: SQL Server LocalDB
- **Autenticación**: JWT Bearer Tokens
- **Encriptación**: BCrypt para contraseñas
- **PDF**: QuestPDF
- **Documentación**: Swagger/OpenAPI

### Frontend
- **Lenguaje**: C# 12 (Razor syntax)
- **Framework**: Blazor WebAssembly .NET 8.0
- **HTTP**: HttpClient con System.Net.Http.Json
- **Estado**: Blazored.LocalStorage
- **UI**: Bootstrap 5 + MudBlazor (opcional)
- **Enrutamiento**: Blazor Router

### Herramientas de Desarrollo
- **IDE**: Visual Studio Community 2022
- **Control de Versiones**: Git (local, sin GitHub)
- **Base de Datos**: SQL Server Management Studio (opcional)
- **Testing**: Navegador web (Chrome, Edge)

---

## 📝 Convenciones y Buenas Prácticas

### Código
- Usar `async/await` para operaciones asíncronas
- DTOs para transferencia de datos entre frontend y backend
- Servicios para encapsular lógica de negocio
- Repository pattern (opcional, puede ser directo con DbContext)
- Manejo de excepciones con try-catch y mensajes claros
- Validación de datos tanto en frontend como backend

### Base de Datos
- Migraciones de EF Core para crear y actualizar esquema
- Seed data para usuarios y productos iniciales
- Nombres en español para tablas y columnas
- Convenciones de naming de SQL Server

### API
- Endpoints RESTful estándar (GET, POST, PUT, DELETE)
- HTTP Status Codes apropiados (200, 201, 400, 401, 404, 500)
- Respuestas consistentes en JSON
- Versionado de API (opcional: /api/v1/)

### Frontend
- Componentes reutilizables
- Separación de lógica y presentación
- Loading states para operaciones asíncronas
- Mensajes de error amigables al usuario
- Confirmaciones antes de acciones destructivas

---

## 🎓 Objetivos de Aprendizaje

Al completar este proyecto, habrás practicado:

### Habilidades de Backend
- ✅ Crear API RESTful desde cero
- ✅ Implementar autenticación y autorización
- ✅ Trabajar con Entity Framework Core
- ✅ Crear y aplicar migraciones de base de datos
- ✅ Diseñar modelos de datos relacionales
- ✅ Implementar lógica de negocio en servicios
- ✅ Generar documentos PDF programáticamente
- ✅ Configurar CORS para comunicación entre proyectos

### Habilidades de Frontend
- ✅ Desarrollar con Blazor WebAssembly
- ✅ Crear componentes Razor reutilizables
- ✅ Consumir API REST desde C#
- ✅ Manejar estado con LocalStorage
- ✅ Implementar autenticación en el cliente
- ✅ Crear interfaces responsive
- ✅ Navegar entre páginas con Blazor Router

### Habilidades Full Stack
- ✅ Diseñar arquitectura Cliente-Servidor
- ✅ Comunicación entre frontend y backend
- ✅ Gestión de sesiones y tokens
- ✅ Implementar flujo completo de e-commerce
- ✅ Debugging de aplicaciones multi-proyecto
- ✅ Testing manual de funcionalidades

---

## ⚠️ Limitaciones Conocidas

### Por Diseño (No son bugs)
- La pasarela de pagos es completamente simulada
- No hay validación de tarjetas reales
- Los usuarios solo pueden ser Admin si se crean manualmente
- No hay recuperación de contraseñas
- No hay verificación de email
- El stock no se reserva durante el proceso de compra
- No hay manejo de transacciones distribuidas

### Simplificaciones Educativas
- JWT almacenado en LocalStorage (en producción usar HttpOnly cookies)
- Sin refresh tokens
- Sin rate limiting
- Sin protección contra XSS/CSRF avanzada
- Sin logging estructurado
- Sin métricas ni monitoreo
- Sin caching
- Sin compresión de respuestas

---

## 🚀 Entorno de Ejecución

### Requisitos del Sistema
- Windows 10/11
- Visual Studio Community 2022 (versión 17.8+)
- .NET 8.0 SDK
- SQL Server LocalDB (incluido con VS)
- Mínimo 8GB RAM
- 5GB espacio en disco

### Configuración
- Ambos proyectos corren simultáneamente
- Backend en puerto HTTPS (ej: 7001)
- Frontend en puerto HTTPS (ej: 7002)
- Base de datos se crea automáticamente en primera ejecución
- Datos iniciales (seed) se cargan automáticamente

### Testing
- Todo se prueba localmente en localhost
- Se usa navegador web para interactuar
- Swagger para probar API directamente
- Sin necesidad de herramientas externas

---

## 📚 Recursos de Aprendizaje

### Documentación Oficial
- ASP.NET Core: https://docs.microsoft.com/aspnet/core
- Blazor: https://docs.microsoft.com/aspnet/core/blazor
- Entity Framework Core: https://docs.microsoft.com/ef/core
- QuestPDF: https://www.questpdf.com/documentation/getting-started

### Conceptos Clave a Investigar
- REST API design principles
- JWT authentication flow
- Code-First migrations en EF Core
- Component lifecycle en Blazor
- Dependency Injection en .NET
- Repository pattern
- DTO pattern

---

## 🎯 Roadmap de Desarrollo

### Fase 1: Setup (Día 1)
- Crear proyectos
- Configurar conexión a BD
- Instalar paquetes NuGet

### Fase 2: Backend Base (Días 2-3)
- Crear modelos de datos
- Configurar DbContext
- Crear y aplicar migración inicial
- Implementar seed data

### Fase 3: Autenticación (Día 4)
- Implementar registro y login
- Configurar JWT
- Crear middleware de autenticación

### Fase 4: API de Productos (Días 5-6)
- CRUD de productos
- CRUD de categorías
- Endpoints con autorización

### Fase 5: Frontend Base (Días 7-8)
- Páginas de login y registro
- Catálogo de productos
- Detalle de producto

### Fase 6: Carrito (Días 9-10)
- Componente de carrito
- LocalStorage service
- Gestión de items

### Fase 7: Checkout (Días 11-12)
- Proceso de pago simulado
- Creación de órdenes
- Confirmación de compra

### Fase 8: Facturación (Días 13-14)
- Generación de PDFs
- Descarga de facturas
- Historial de órdenes

### Fase 9: Admin Panel (Días 15-16)
- Dashboard administrativo
- Gestión de productos
- Visualización de órdenes

### Fase 10: Diseño y Testing (Días 17-18)
- Aplicar estilos
- Hacer responsive
- Testing completo de funcionalidades

---

## 💡 Consejos para Claude Code

### Al Generar Código
- Usar nombres de variables y métodos en español
- Comentar secciones complejas
- Incluir manejo de excepciones
- Validar datos de entrada
- Usar async/await consistentemente

### Al Crear Migraciones
- Nombrar migraciones descriptivamente (ej: CrearTablaProductos)
- Verificar que las relaciones estén correctamente configuradas
- Incluir índices en campos que se consultarán frecuentemente

### Al Implementar Servicios
- Crear interfaces primero (IProductoService)
- Implementar después (ProductoService)
- Inyectar dependencias por constructor
- Retornar DTOs, no entidades directamente

### Al Crear Componentes Blazor
- Mantener componentes pequeños y enfocados
- Usar parámetros para componentes reutilizables
- Manejar loading y error states
- Implementar dispose si es necesario

---

## 🤝 Colaboración con el Desarrollador

El desarrollador está trabajando en **Visual Studio Community 2022** y te pedirá que generes:

1. **Código de clases completas** (Models, Services, Controllers)
2. **Componentes Blazor completos** (.razor files)
3. **Configuraciones** (Program.cs, appsettings.json)
4. **Comandos de terminal** (para migraciones de EF Core)
5. **Explicaciones** de cómo funciona cada parte

**No es necesario**:
- Crear tests unitarios (a menos que se pida)
- Implementar features avanzados no mencionados
- Optimizaciones prematuras
- Despliegue o DevOps

---

## ✅ Criterios de Éxito

El proyecto está completo cuando:

- ✅ Un cliente puede registrarse, navegar productos, comprar y obtener factura
- ✅ Un administrador puede gestionar el catálogo completo
- ✅ La base de datos se crea automáticamente con migraciones
- ✅ La autenticación funciona correctamente con JWT
- ✅ Las facturas se generan en PDF y son descargables
- ✅ La interfaz es responsive y usable
- ✅ No hay errores en la consola del navegador ni del servidor
- ✅ Todos los endpoints de la API responden correctamente

---

## 🎉 Resultado Final Esperado

Un sistema completo de e-commerce con facturación que:
- Se ejecuta localmente sin problemas
- Tiene una interfaz moderna y funcional
- Procesa compras de principio a fin
- Genera documentación fiscal (facturas)
- Permite administración de productos
- Sirve como portfolio de aprendizaje .NET

---

**Versión del Documento**: 1.0  
**Fecha**: Octubre 2025  
**Target**: Claude Code AI Assistant  
**Desarrollador**: Trabajando con Visual Studio Community 2022