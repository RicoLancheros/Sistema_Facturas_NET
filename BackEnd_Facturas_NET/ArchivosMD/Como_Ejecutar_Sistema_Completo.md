# 🚀 Cómo Ejecutar el Sistema Completo - Backend + Frontend

Esta guía te muestra cómo levantar todo el sistema: Docker SQL Server + Backend API + Frontend Blazor.

---

## 📋 Requisitos Previos

- ✅ Docker Desktop ejecutándose
- ✅ .NET 9.0 SDK instalado
- ✅ Visual Studio Community (opcional)
- ✅ 3 terminales abiertas (o 3 pestañas en una terminal)

---

## 🎯 Paso a Paso Completo

### **TERMINAL 1: Levantar SQL Server en Docker**

#### 1. Navega a la raíz del proyecto

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET
```

#### 2. Inicia el contenedor de SQL Server

```bash
docker-compose up -d
```

**Salida esperada:**
```
Creating sqlserver_facturas ... done
```

#### 3. Verifica que está corriendo

```bash
docker ps
```

✅ **Deberías ver `sqlserver_facturas` con estado "Up"**

---

### **TERMINAL 2: Ejecutar el Backend**

#### 1. Navega a la carpeta del Backend

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET\BackEnd_Facturas_NET
```

#### 2. Ejecuta el Backend

```bash
dotnet run
```

**Salida esperada:**
```
Compilando...
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      CREATE DATABASE [FacturasDB];
...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5250
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

✅ **Backend corriendo en:** `http://localhost:5250`

✅ **Swagger disponible en:** `http://localhost:5250/swagger`

---

### **TERMINAL 3: Ejecutar el Frontend**

#### 1. Navega a la carpeta del Frontend

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET\FrontEnd_Facturas_NET
```

#### 2. Ejecuta el Frontend

```bash
dotnet run
```

**Salida esperada:**
```
Compilando...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5xxx
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

✅ **Frontend corriendo en:** `http://localhost:5xxx` (el puerto exacto aparecerá en la terminal)

**IMPORTANTE:** Copia la URL completa que aparece en la terminal y ábrela en tu navegador.

---

## 🌐 Acceder al Sistema

### **Abrir el Frontend en el Navegador**

Una vez que el Frontend esté corriendo, abre tu navegador y ve a la URL que apareció en la terminal, por ejemplo:

```
http://localhost:5174
```

**Deberías ver:**
- ✅ Página de inicio con 4 cards (Usuarios, Productos, Facturas, Nueva Factura)
- ✅ Menú lateral con navegación
- ✅ Barra superior con título "Sistema de Facturas"

---

## 🧪 Probar el Sistema Completo

### **1. Probar la Página de Inicio**

Al abrir el Frontend, verás el dashboard con:
- Card de **Usuarios** → Botón "Ver Usuarios"
- Card de **Productos** → Botón "Ver Productos"
- Card de **Facturas** → Botón "Ver Facturas"
- Card de **Nueva Factura** → Botón "Crear Factura"

---

### **2. Gestionar Usuarios**

1. Haz clic en **"Ver Usuarios"** o en **"Usuarios"** en el menú lateral
2. Verás una tabla con 3 usuarios precargados:
   - Juan Pérez
   - María García
   - Carlos López
3. **Crear un nuevo usuario:**
   - Haz clic en **"Nuevo Usuario"**
   - Escribe un nombre (ej: "Pedro Martínez")
   - Haz clic en **"Guardar"**
   - ✅ Deberías ver el nuevo usuario en la tabla
4. **Editar un usuario:**
   - Haz clic en el ícono de **lápiz** (editar)
   - Cambia el nombre
   - Haz clic en **"Guardar"**
5. **Eliminar un usuario:**
   - Haz clic en el ícono de **basura** (eliminar)
   - El usuario desaparecerá de la tabla

---

### **3. Gestionar Productos**

1. Haz clic en **"Productos"** en el menú lateral
2. Verás una tabla con 10 productos precargados (Laptop Dell, Mouse Logitech, etc.)
3. **Crear un nuevo producto:**
   - Haz clic en **"Nuevo Producto"**
   - Nombre: "Teclado Mecánico RGB"
   - Cantidad: 20
   - Haz clic en **"Guardar"**
4. **Editar un producto:**
   - Haz clic en el ícono de **lápiz**
   - Cambia la cantidad o el nombre
   - Haz clic en **"Guardar"**
5. **Nota:** Los productos tienen un indicador de color según la cantidad:
   - 🟢 Verde: Más de 10 unidades
   - 🟡 Amarillo: Entre 6 y 10 unidades
   - 🔴 Rojo: Menos de 6 unidades

---

### **4. Crear una Factura Completa**

1. Haz clic en **"Nueva Factura"** en el menú lateral
2. **Seleccionar usuario:**
   - Despliega el select "Seleccionar Usuario"
   - Elige un usuario (ej: Juan Pérez)
3. **Agregar productos:**
   - **Producto:** Selecciona "Laptop Dell XPS 15"
   - **Cantidad:** 2
   - **Precio Unitario:** 1500000
   - Haz clic en el botón **"+"** (agregar)
   - El producto aparecerá en la tabla de abajo
4. **Agregar más productos:**
   - **Producto:** Selecciona "Mouse Logitech MX Master 3"
   - **Cantidad:** 1
   - **Precio Unitario:** 150000
   - Haz clic en **"+"**
5. **Verificar el total:**
   - Deberías ver en la parte inferior:
     ```
     Total: $3,150,000
     ```
   - Este total se calcula automáticamente: (2 × 1,500,000) + (1 × 150,000) = 3,150,000
6. **Crear la factura:**
   - Haz clic en **"Crear Factura"**
   - ✅ Verás un mensaje de éxito
   - Serás redirigido a la página de **Facturas**

---

### **5. Ver Facturas Creadas**

1. Haz clic en **"Facturas"** en el menú lateral
2. Verás una tabla con todas las facturas creadas
3. **Información mostrada:**
   - ID de la factura
   - Nombre del usuario
   - Fecha y hora
   - Total (en color verde)
   - Cantidad de productos (chip con "X items")
4. **Ver detalles de una factura:**
   - Haz clic en el ícono de **ojo** (ver)
   - Se abrirá un diálogo con:
     - Usuario
     - Fecha completa
     - Tabla de productos con cantidad, precio unitario y subtotal
     - Total resaltado en grande

---

## 📊 Diagrama de Flujo del Sistema

```
┌─────────────────────────────────────────────────────────┐
│  Docker SQL Server                                      │
│  Puerto: 1433                                           │
│  Base de Datos: FacturasDB                              │
└──────────────────┬──────────────────────────────────────┘
                   │
                   ↓
┌─────────────────────────────────────────────────────────┐
│  Backend ASP.NET Core Web API                           │
│  Puerto: http://localhost:5250                          │
│  Endpoints: /api/Usuarios, /api/Productos, /api/Facturas│
│  Swagger: http://localhost:5250/swagger                 │
└──────────────────┬──────────────────────────────────────┘
                   │
                   ↓ HTTP Requests
┌─────────────────────────────────────────────────────────┐
│  Frontend Blazor WebAssembly                            │
│  Puerto: http://localhost:5xxx                          │
│  Páginas: Home, Usuarios, Productos, Facturas           │
│  Interfaz: MudBlazor (Material Design)                  │
└─────────────────────────────────────────────────────────┘
                   │
                   ↓
┌─────────────────────────────────────────────────────────┐
│  Navegador Web                                          │
│  Usuario final interactúa con la aplicación             │
└─────────────────────────────────────────────────────────┘
```

---

## 🛑 Cómo Detener el Sistema

### **Detener cada componente:**

1. **Frontend** (Terminal 3):
   ```
   Ctrl + C
   ```

2. **Backend** (Terminal 2):
   ```
   Ctrl + C
   ```

3. **Docker SQL Server** (Terminal 1):
   ```bash
   docker-compose down
   ```

---

## 🔄 Cómo Reiniciar el Sistema

Para volver a trabajar con el proyecto:

```bash
# Terminal 1 - Docker
docker-compose up -d

# Terminal 2 - Backend
cd BackEnd_Facturas_NET
dotnet run

# Terminal 3 - Frontend
cd FrontEnd_Facturas_NET
dotnet run
```

---

## ⚠️ Solución de Problemas

### **Error: "Failed to connect to localhost:5250"**

**Causa:** El Backend no está corriendo.

**Solución:**
1. Abre la Terminal 2
2. Verifica que veas el mensaje "Now listening on: http://localhost:5250"
3. Si no, ejecuta `dotnet run` en la carpeta `BackEnd_Facturas_NET`

---

### **Error: "CORS policy"**

**Causa:** El Backend no tiene CORS configurado correctamente.

**Solución:**
1. Verifica que el Backend esté corriendo en `http://localhost:5250`
2. Verifica que el Frontend esté configurado para conectarse a esa URL (Program.cs:14)

---

### **Error: La página se ve sin estilos**

**Causa:** MudBlazor no se cargó correctamente.

**Solución:**
1. Detén el Frontend (`Ctrl + C`)
2. Ejecuta:
   ```bash
   dotnet clean
   dotnet build
   dotnet run
   ```

---

### **Error: "No se pueden cargar los usuarios/productos"**

**Causa:** La base de datos no tiene datos o el Backend no está conectado.

**Solución:**
1. Verifica que Docker esté corriendo: `docker ps`
2. Verifica que el Backend esté corriendo
3. Abre Swagger: http://localhost:5250/swagger
4. Prueba GET /api/Usuarios
5. Si no hay datos, detén el Backend y vuelve a ejecutarlo (creará los datos)

---

## ✅ Checklist de Verificación

Usa este checklist para asegurarte de que todo funciona:

- [ ] Docker SQL Server está corriendo (`docker ps` muestra `sqlserver_facturas`)
- [ ] Backend está corriendo (Terminal 2 muestra "Now listening on: http://localhost:5250")
- [ ] Frontend está corriendo (Terminal 3 muestra "Now listening on: http://localhost:XXXX")
- [ ] Puedo abrir el Frontend en el navegador
- [ ] Veo la página de inicio con 4 cards
- [ ] Puedo navegar a "Usuarios" y veo 3 usuarios
- [ ] Puedo crear un nuevo usuario
- [ ] Puedo navegar a "Productos" y veo 10 productos
- [ ] Puedo crear un nuevo producto
- [ ] Puedo crear una factura con múltiples productos
- [ ] Puedo ver la factura creada en "Facturas"
- [ ] Puedo ver los detalles de la factura

Si todos los items están marcados: **¡Tu sistema está completamente operativo!** 🎉

---

## 📚 Archivos de Referencia

- **Backend_Test_Guia.md** - Pruebas con Postman/Swagger
- **Como_Ejecutar_Backend.md** - Solo Backend
- **Checklist.md** - Estado completo del proyecto
- **Sistema_Facturas_API.postman_collection.json** - Colección de Postman

---

**¡Disfruta tu Sistema de Facturas!** 🚀
