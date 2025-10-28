# 🧪 Guía de Pruebas del Backend - Sistema de Facturas

## 📋 Tabla de Contenidos
1. [Requisitos Previos](#requisitos-previos)
2. [Paso a Paso para Levantar los Servicios](#paso-a-paso-para-levantar-los-servicios)
3. [Verificar Estado de los Servicios](#verificar-estado-de-los-servicios)
4. [Probar con Swagger (Recomendado)](#probar-con-swagger)
5. [Probar con Postman](#probar-con-postman)
6. [Ejemplos de Requests](#ejemplos-de-requests)
7. [Solución de Problemas](#solución-de-problemas)

---

## 📌 Requisitos Previos

Antes de comenzar, asegúrate de tener:
- ✅ Docker Desktop instalado y ejecutándose
- ✅ .NET 9.0 SDK instalado
- ✅ Postman instalado (opcional, también puedes usar Swagger)
- ✅ Visual Studio o VS Code abierto

---

## 🚀 Paso a Paso para Levantar los Servicios

### **Paso 1: Levantar SQL Server en Docker**

Abre una terminal en la **raíz del proyecto** (donde está el archivo `docker-compose.yml`):

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET
```

Ejecuta el contenedor de SQL Server:

```bash
docker-compose up -d
```

**Salida esperada:**
```
Creating network "sistema_facturas_net_default" with the default driver
Creating sqlserver_facturas ... done
```

### **Paso 2: Verificar que el Contenedor está Corriendo**

```bash
docker ps
```

**Salida esperada:**
```
CONTAINER ID   IMAGE                                        STATUS         PORTS                    NAMES
xxxxx          mcr.microsoft.com/mssql/server:2022-latest   Up X minutes   0.0.0.0:1433->1433/tcp   sqlserver_facturas
```

✅ Si ves el contenedor `sqlserver_facturas` con estado "Up", SQL Server está corriendo correctamente.

### **Paso 3: Ejecutar el Backend**

Abre **otra terminal** y navega a la carpeta del Backend:

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET\BackEnd_Facturas_NET
```

Ejecuta el proyecto:

```bash
dotnet run
```

**Salida esperada:**
```
Compilando...
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1,196ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [FacturasDB];
...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5250
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

✅ **El backend está corriendo en:** `http://localhost:5250`

---

## ✔️ Verificar Estado de los Servicios

### **Verificar Docker SQL Server**

```bash
docker logs sqlserver_facturas
```

Deberías ver logs de SQL Server indicando que está listo para aceptar conexiones.

### **Verificar Backend**

Abre tu navegador y accede a:

```
http://localhost:5250/swagger
```

✅ Si ves la interfaz de Swagger, el backend está funcionando correctamente.

---

## 🌐 Probar con Swagger (Recomendado)

Swagger es la forma más rápida de probar tu API sin configurar nada adicional.

### **1. Acceder a Swagger**

```
http://localhost:5250/swagger
```

### **2. Probar Endpoint GET /api/Usuarios**

1. Haz clic en **GET /api/Usuarios**
2. Haz clic en **"Try it out"**
3. Haz clic en **"Execute"**

**Respuesta esperada (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Juan Pérez",
    "facturas": []
  },
  {
    "id": 2,
    "nombre": "María García",
    "facturas": []
  },
  {
    "id": 3,
    "nombre": "Carlos López",
    "facturas": []
  }
]
```

### **3. Probar Endpoint GET /api/Productos**

1. Haz clic en **GET /api/Productos**
2. Haz clic en **"Try it out"**
3. Haz clic en **"Execute"**

**Respuesta esperada (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Laptop Dell XPS 15",
    "cantidad": 10,
    "detallesFactura": []
  },
  {
    "id": 2,
    "nombre": "Mouse Logitech MX Master 3",
    "cantidad": 50,
    "detallesFactura": []
  },
  ...
]
```

---

## 📬 Probar con Postman

### **Configuración Inicial de Postman**

1. Abre Postman
2. Crea una nueva **Collection** llamada "Sistema Facturas API"
3. Configura la **Base URL**: `http://localhost:5250`

---

## 📝 Ejemplos de Requests en Postman

### **1. GET - Obtener Todos los Usuarios**

**Método:** `GET`
**URL:** `http://localhost:5250/api/Usuarios`
**Headers:** Ninguno necesario

**Respuesta Esperada (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Juan Pérez",
    "facturas": []
  },
  {
    "id": 2,
    "nombre": "María García",
    "facturas": []
  },
  {
    "id": 3,
    "nombre": "Carlos López",
    "facturas": []
  }
]
```

---

### **2. GET - Obtener Usuario por ID**

**Método:** `GET`
**URL:** `http://localhost:5250/api/Usuarios/1`

**Respuesta Esperada (200 OK):**
```json
{
  "id": 1,
  "nombre": "Juan Pérez",
  "facturas": []
}
```

---

### **3. POST - Crear un Nuevo Usuario**

**Método:** `POST`
**URL:** `http://localhost:5250/api/Usuarios`
**Headers:**
```
Content-Type: application/json
```

**Body (raw - JSON):**
```json
{
  "nombre": "Pedro Martínez"
}
```

**Respuesta Esperada (201 Created):**
```json
{
  "id": 4,
  "nombre": "Pedro Martínez",
  "facturas": []
}
```

---

### **4. PUT - Actualizar un Usuario**

**Método:** `PUT`
**URL:** `http://localhost:5250/api/Usuarios/4`
**Headers:**
```
Content-Type: application/json
```

**Body (raw - JSON):**
```json
{
  "id": 4,
  "nombre": "Pedro Martínez Actualizado"
}
```

**Respuesta Esperada (204 No Content):**
Sin cuerpo de respuesta, solo código de estado 204.

---

### **5. DELETE - Eliminar un Usuario**

**Método:** `DELETE`
**URL:** `http://localhost:5250/api/Usuarios/4`

**Respuesta Esperada (204 No Content):**
Sin cuerpo de respuesta, solo código de estado 204.

---

### **6. GET - Obtener Todos los Productos**

**Método:** `GET`
**URL:** `http://localhost:5250/api/Productos`

**Respuesta Esperada (200 OK):**
```json
[
  {
    "id": 1,
    "nombre": "Laptop Dell XPS 15",
    "cantidad": 10,
    "detallesFactura": []
  },
  {
    "id": 2,
    "nombre": "Mouse Logitech MX Master 3",
    "cantidad": 50,
    "detallesFactura": []
  }
]
```

---

### **7. POST - Crear un Nuevo Producto**

**Método:** `POST`
**URL:** `http://localhost:5250/api/Productos`
**Headers:**
```
Content-Type: application/json
```

**Body (raw - JSON):**
```json
{
  "nombre": "Monitor LG UltraWide 34\"",
  "cantidad": 15
}
```

**Respuesta Esperada (201 Created):**
```json
{
  "id": 11,
  "nombre": "Monitor LG UltraWide 34\"",
  "cantidad": 15,
  "detallesFactura": []
}
```

---

### **8. POST - Crear una Factura Completa**

**Método:** `POST`
**URL:** `http://localhost:5250/api/Facturas`
**Headers:**
```
Content-Type: application/json
```

**Body (raw - JSON):**
```json
{
  "usuarioId": 1,
  "detalles": [
    {
      "productoId": 1,
      "cantidad": 2,
      "precioUnitario": 1500000.00
    },
    {
      "productoId": 2,
      "cantidad": 1,
      "precioUnitario": 150000.00
    }
  ]
}
```

**Respuesta Esperada (201 Created):**
```json
{
  "id": 1,
  "usuarioId": 1,
  "fecha": "2025-10-27T15:30:45.123",
  "total": 3150000.00,
  "usuario": {
    "id": 1,
    "nombre": "Juan Pérez",
    "facturas": []
  },
  "detalles": [
    {
      "id": 1,
      "facturaId": 1,
      "productoId": 1,
      "cantidad": 2,
      "precioUnitario": 1500000.00,
      "factura": null,
      "producto": {
        "id": 1,
        "nombre": "Laptop Dell XPS 15",
        "cantidad": 10,
        "detallesFactura": []
      }
    },
    {
      "id": 2,
      "facturaId": 1,
      "productoId": 2,
      "cantidad": 1,
      "precioUnitario": 150000.00,
      "factura": null,
      "producto": {
        "id": 2,
        "nombre": "Mouse Logitech MX Master 3",
        "cantidad": 50,
        "detallesFactura": []
      }
    }
  ]
}
```

---

### **9. GET - Obtener Todas las Facturas**

**Método:** `GET`
**URL:** `http://localhost:5250/api/Facturas`

**Respuesta Esperada (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioId": 1,
    "fecha": "2025-10-27T15:30:45.123",
    "total": 3150000.00,
    "usuario": {
      "id": 1,
      "nombre": "Juan Pérez",
      "facturas": []
    },
    "detalles": [...]
  }
]
```

---

### **10. GET - Obtener Facturas de un Usuario**

**Método:** `GET`
**URL:** `http://localhost:5250/api/Facturas/Usuario/1`

**Respuesta Esperada (200 OK):**
```json
[
  {
    "id": 1,
    "usuarioId": 1,
    "fecha": "2025-10-27T15:30:45.123",
    "total": 3150000.00,
    "detalles": [...]
  }
]
```

---

### **11. DELETE - Eliminar una Factura**

**Método:** `DELETE`
**URL:** `http://localhost:5250/api/Facturas/1`

**Respuesta Esperada (204 No Content):**
Sin cuerpo de respuesta.

---

## 🔧 Solución de Problemas

### **Error: "Connection refused" o "No connection could be made"**

**Causa:** SQL Server en Docker no está corriendo.

**Solución:**
```bash
docker-compose up -d
docker ps  # Verificar que está corriendo
```

---

### **Error: "Login failed for user 'sa'"**

**Causa:** Contraseña incorrecta en appsettings.json

**Solución:**
Verifica que la contraseña en `appsettings.json` sea: `YourStrong@Passw0rd`

---

### **Error: "Cannot open database 'FacturasDB'"**

**Causa:** La base de datos no se creó.

**Solución:**
1. Detén el backend (Ctrl+C)
2. Elimina las migraciones: `dotnet ef database drop --force`
3. Vuelve a ejecutar: `dotnet run`

---

### **Error: "Swagger no carga"**

**Causa:** El backend no está corriendo correctamente.

**Solución:**
1. Verifica que ejecutaste `dotnet run` en la carpeta correcta
2. Verifica que veas el mensaje "Now listening on: http://localhost:5250"
3. Accede a: http://localhost:5250/swagger

---

### **Error 500 al crear una factura**

**Causa:** ProductoId o UsuarioId no existe en la base de datos.

**Solución:**
1. Primero obtén los IDs válidos con GET /api/Productos y GET /api/Usuarios
2. Usa esos IDs en tu factura

---

## 📊 Resumen de Endpoints Disponibles

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Usuarios` | Obtener todos los usuarios |
| GET | `/api/Usuarios/{id}` | Obtener usuario por ID |
| POST | `/api/Usuarios` | Crear nuevo usuario |
| PUT | `/api/Usuarios/{id}` | Actualizar usuario |
| DELETE | `/api/Usuarios/{id}` | Eliminar usuario |
| GET | `/api/Productos` | Obtener todos los productos |
| GET | `/api/Productos/{id}` | Obtener producto por ID |
| POST | `/api/Productos` | Crear nuevo producto |
| PUT | `/api/Productos/{id}` | Actualizar producto |
| DELETE | `/api/Productos/{id}` | Eliminar producto |
| GET | `/api/Facturas` | Obtener todas las facturas |
| GET | `/api/Facturas/{id}` | Obtener factura por ID |
| GET | `/api/Facturas/Usuario/{usuarioId}` | Obtener facturas de un usuario |
| POST | `/api/Facturas` | Crear nueva factura |
| DELETE | `/api/Facturas/{id}` | Eliminar factura |

---

## ✅ Checklist de Pruebas

- [ ] SQL Server corriendo en Docker (`docker ps`)
- [ ] Backend ejecutándose (`dotnet run`)
- [ ] Swagger accesible (http://localhost:5250/swagger)
- [ ] GET /api/Usuarios retorna 3 usuarios
- [ ] GET /api/Productos retorna 10 productos
- [ ] POST /api/Usuarios crea un nuevo usuario
- [ ] POST /api/Productos crea un nuevo producto
- [ ] POST /api/Facturas crea una factura completa
- [ ] GET /api/Facturas retorna la factura creada
- [ ] DELETE funciona correctamente

---

## 🎯 Próximos Pasos

Una vez que hayas probado todos los endpoints con Postman/Swagger:

1. ✅ Backend funcionando correctamente
2. ⏭️ Configurar y probar el Frontend
3. ⏭️ Conectar Frontend con Backend
4. ⏭️ Crear interfaz de usuario para gestión de facturas

---

**¡Todo listo para probar tu backend!** 🚀
