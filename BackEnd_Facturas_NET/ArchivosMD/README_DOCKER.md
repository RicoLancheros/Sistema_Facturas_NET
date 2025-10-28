# Sistema de Facturas .NET - Configuración Docker

## Requisitos Previos
- Docker Desktop instalado
- .NET 9 SDK instalado
- Visual Studio 2022 o VS Code

## Pasos para Iniciar el Proyecto

### 1. Levantar SQL Server en Docker

Desde la raíz del proyecto, ejecuta:

```bash
docker-compose up -d
```

Esto levantará un contenedor de SQL Server en el puerto 1433 con:
- Usuario: `sa`
- Contraseña: `YourStrong@Passw0rd`
- Base de datos: Se creará automáticamente al ejecutar la API

### 2. Verificar que el Contenedor está Corriendo

```bash
docker ps
```

Deberías ver el contenedor `sqlserver_facturas` en ejecución.

### 3. Crear la Migración Inicial

Desde la carpeta `BackEnd_Facturas_NET`:

```bash
cd BackEnd_Facturas_NET
dotnet ef migrations add InitialCreate
```

### 4. Ejecutar el Backend

Desde la carpeta `BackEnd_Facturas_NET`:

```bash
dotnet run
```

La API estará disponible en:
- HTTPS: `https://localhost:7001`
- Swagger: `https://localhost:7001/swagger`

### 5. Ejecutar el Frontend

Desde la carpeta `FrontEnd_Facturas_NET`:

```bash
cd ../FrontEnd_Facturas_NET
dotnet run
```

El frontend estará disponible en:
- HTTPS: `https://localhost:7002`

## Estructura Simplificada del Proyecto

### Modelos (4 tablas básicas)

1. **Usuario**
   - Id
   - Nombre

2. **Producto**
   - Id
   - Nombre
   - Cantidad

3. **Factura**
   - Id
   - UsuarioId
   - Fecha
   - Total

4. **DetalleFactura**
   - Id
   - FacturaId
   - ProductoId
   - Cantidad
   - PrecioUnitario

## Comandos Útiles de Docker

### Detener el contenedor
```bash
docker-compose down
```

### Ver logs del contenedor
```bash
docker logs sqlserver_facturas
```

### Eliminar el contenedor y volúmenes
```bash
docker-compose down -v
```

### Acceder al SQL Server con cliente
```bash
docker exec -it sqlserver_facturas /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd
```

## Datos de Prueba

Al iniciar la aplicación, se crearán automáticamente:
- 3 usuarios de prueba
- 10 productos de ejemplo

## Troubleshooting

### Error de conexión a la base de datos
1. Verifica que Docker esté corriendo: `docker ps`
2. Verifica la contraseña en `appsettings.json`
3. Asegúrate de que el puerto 1433 no esté en uso

### Error al crear migración
1. Asegúrate de tener EF Core Tools instalado:
   ```bash
   dotnet tool install --global dotnet-ef
   ```
2. Verifica que estés en la carpeta `BackEnd_Facturas_NET`

## Arquitectura Simplificada

- **Sin autenticación JWT** - Solo CORS habilitado
- **Sin DTOs** - Trabajo directo con modelos
- **Sin servicios complejos** - Controladores directos con DbContext
- **Base de datos en Docker** - SQL Server containerizado
