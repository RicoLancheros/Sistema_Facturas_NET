# 🚀 Cómo Ejecutar el Backend - Paso a Paso

Esta guía te muestra exactamente cómo levantar el backend del Sistema de Facturas desde cero.

---

## 📋 Requisitos Previos

Antes de comenzar, verifica que tienes instalado:

- ✅ **Docker Desktop** - Para SQL Server
- ✅ **.NET 9.0 SDK** - Para ejecutar el backend
- ✅ **Visual Studio Community** (opcional) o cualquier editor de código

---

## 🎯 Paso a Paso Completo

### **PASO 1: Levantar SQL Server en Docker**

#### 1.1. Abre una terminal (CMD, PowerShell o Terminal de VS)

Puedes hacerlo de varias formas:
- Presiona `Win + R`, escribe `cmd` y presiona Enter
- En Visual Studio: `Ver > Terminal` (Ctrl + `)
- Clic derecho en la carpeta del proyecto > "Abrir en Terminal"

#### 1.2. Navega a la raíz del proyecto

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET
```

**Verifica que estás en la carpeta correcta** (debe contener el archivo `docker-compose.yml`):

```bash
dir
```

Deberías ver algo como:
```
docker-compose.yml
Sistema_Facturas_NET.sln
BackEnd_Facturas_NET
FrontEnd_Facturas_NET
```

#### 1.3. Inicia el contenedor de SQL Server

```bash
docker-compose up -d
```

**Salida esperada:**
```
Creating network "sistema_facturas_net_default" with the default driver
Creating sqlserver_facturas ... done
```

#### 1.4. Verifica que el contenedor está corriendo

```bash
docker ps
```

**Deberías ver:**
```
CONTAINER ID   IMAGE                                        STATUS         PORTS                    NAMES
xxxxx          mcr.microsoft.com/mssql/server:2022-latest   Up X seconds   0.0.0.0:1433->1433/tcp   sqlserver_facturas
```

✅ **Si ves `sqlserver_facturas` con estado "Up", SQL Server está listo!**

---

### **PASO 2: Ejecutar el Backend**

#### 2.1. Abre una NUEVA terminal

**IMPORTANTE:** NO cierres la terminal anterior. Abre una nueva.

#### 2.2. Navega a la carpeta del Backend

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET\BackEnd_Facturas_NET
```

**Verifica que estás en la carpeta correcta:**

```bash
dir
```

Deberías ver:
```
BackEnd_Facturas_NET.csproj
Program.cs
Controllers
Models
Data
Migrations
```

#### 2.3. Ejecuta el Backend

```bash
dotnet run
```

#### 2.4. Espera a que compile y se ejecute

**Salida esperada (esto puede tomar 10-30 segundos):**

```
Usando la configuración de inicio de C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET\BackEnd_Facturas_NET\Properties\launchSettings.json...
Compilando...
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1,196ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [FacturasDB];
```

**Luego verás la creación de tablas:**
```
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20251027203823_InitialCreate'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      CREATE TABLE [Productos] (...)
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      CREATE TABLE [Usuarios] (...)
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      CREATE TABLE [Facturas] (...)
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      CREATE TABLE [DetallesFactura] (...)
```

**Y finalmente:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5250
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

✅ **Si ves "Now listening on: http://localhost:5250", el backend está corriendo!**

---

### **PASO 3: Verificar que Todo Funciona**

#### 3.1. Verificar la Base de Datos

En la misma terminal donde ejecutaste `dotnet run`, deberías haber visto mensajes indicando:
- ✅ Base de datos creada: `CREATE DATABASE [FacturasDB]`
- ✅ Tablas creadas: `CREATE TABLE [Usuarios]`, `[Productos]`, `[Facturas]`, `[DetallesFactura]`
- ✅ Datos insertados: `MERGE [Usuarios]`, `MERGE [Productos]`

Esto significa que:
- La base de datos **FacturasDB** fue creada en Docker
- Las 4 tablas fueron creadas
- Se insertaron 3 usuarios y 10 productos de prueba

#### 3.2. Acceder a Swagger

Abre tu navegador web y ve a:

```
http://localhost:5250/swagger
```

**Deberías ver:**
- Interfaz de Swagger UI
- 3 secciones de endpoints:
  - **Facturas** (5 endpoints)
  - **Productos** (5 endpoints)
  - **Usuarios** (5 endpoints)

✅ **Si ves la interfaz de Swagger, el backend está funcionando correctamente!**

---

## 🧪 Probar los Endpoints

### **Prueba Rápida en Swagger:**

#### 1. Probar GET /api/Usuarios

1. Haz clic en **GET /api/Usuarios**
2. Haz clic en **"Try it out"**
3. Haz clic en **"Execute"**

**Deberías ver una respuesta 200 con 3 usuarios:**
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

#### 2. Probar GET /api/Productos

1. Haz clic en **GET /api/Productos**
2. Haz clic en **"Try it out"**
3. Haz clic en **"Execute"**

**Deberías ver una respuesta 200 con 10 productos:**
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

✅ **Si ambas pruebas funcionan, tu backend está completamente operativo!**

---

## 🛑 Cómo Detener el Backend

### **Detener el Backend:**

En la terminal donde está corriendo el backend, presiona:

```
Ctrl + C
```

Verás:
```
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

### **Detener SQL Server (Docker):**

En cualquier terminal:

```bash
docker-compose down
```

**Salida esperada:**
```
Stopping sqlserver_facturas ... done
Removing sqlserver_facturas ... done
Removing network sistema_facturas_net_default
```

---

## 🔄 Cómo Volver a Iniciar Todo

Cuando quieras trabajar de nuevo con el proyecto:

### **Opción 1: Inicio Rápido (si todo ya está configurado)**

```bash
# Terminal 1 - En la raíz del proyecto
docker-compose up -d

# Terminal 2 - En la carpeta del Backend
cd BackEnd_Facturas_NET
dotnet run
```

### **Opción 2: Desde Visual Studio**

1. Abre el proyecto en Visual Studio
2. En la terminal integrada:
   ```bash
   # Primero levanta Docker
   docker-compose up -d

   # Luego ejecuta el backend
   cd BackEnd_Facturas_NET
   dotnet run
   ```

---

## ⚠️ Solución de Problemas Comunes

### **Error: "docker-compose no se reconoce como comando"**

**Solución:**
- Asegúrate de que Docker Desktop está instalado y corriendo
- Reinicia la terminal después de instalar Docker

---

### **Error: "Connection refused" o "Login failed for user 'sa'"**

**Causa:** SQL Server no está corriendo o la contraseña es incorrecta.

**Solución:**
1. Verifica que Docker está corriendo: `docker ps`
2. Si no ves `sqlserver_facturas`, ejecuta: `docker-compose up -d`
3. Verifica que la contraseña en `appsettings.json` es: `YourStrong@Passw0rd`

---

### **Error: "Port 5250 is already in use"**

**Causa:** Ya hay una instancia del backend corriendo.

**Solución:**
1. Busca la terminal donde está corriendo
2. Presiona `Ctrl + C` para detenerlo
3. Vuelve a ejecutar `dotnet run`

---

### **Error: "Port 1433 is already in use"**

**Causa:** Ya hay un SQL Server corriendo (Docker u otra instancia).

**Solución:**

**Opción 1 - Usar el contenedor existente:**
```bash
docker ps
```
Si ves `sqlserver_facturas`, solo ejecuta el backend.

**Opción 2 - Detener y reiniciar Docker:**
```bash
docker-compose down
docker-compose up -d
```

---

### **La base de datos no se crea**

**Solución:**
1. Detén el backend (`Ctrl + C`)
2. Elimina el contenedor:
   ```bash
   docker-compose down -v
   ```
3. Vuelve a iniciar todo:
   ```bash
   docker-compose up -d
   cd BackEnd_Facturas_NET
   dotnet run
   ```

---

## 📊 Resumen Visual

```
┌─────────────────────────────────────────────────────────┐
│  TERMINAL 1 (Raíz del Proyecto)                         │
├─────────────────────────────────────────────────────────┤
│  > docker-compose up -d                                 │
│  ✅ SQL Server corriendo en puerto 1433                 │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│  TERMINAL 2 (BackEnd_Facturas_NET)                      │
├─────────────────────────────────────────────────────────┤
│  > dotnet run                                           │
│  ✅ Backend corriendo en http://localhost:5250         │
│  ✅ Base de datos FacturasDB creada                     │
│  ✅ Tablas creadas (Usuarios, Productos, etc.)          │
│  ✅ Datos de prueba insertados                          │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│  NAVEGADOR                                              │
├─────────────────────────────────────────────────────────┤
│  http://localhost:5250/swagger                          │
│  ✅ Swagger UI funcionando                              │
│  ✅ Endpoints disponibles para probar                   │
└─────────────────────────────────────────────────────────┘
```

---

## ✅ Checklist de Verificación

Usa este checklist cada vez que levantes el backend:

- [ ] Docker Desktop está abierto y corriendo
- [ ] Ejecuté `docker-compose up -d` en la raíz del proyecto
- [ ] Verifiqué que el contenedor está corriendo con `docker ps`
- [ ] Ejecuté `dotnet run` en la carpeta `BackEnd_Facturas_NET`
- [ ] Vi el mensaje "Now listening on: http://localhost:5250"
- [ ] Abrí http://localhost:5250/swagger en el navegador
- [ ] Probé GET /api/Usuarios y obtengo 3 usuarios
- [ ] Probé GET /api/Productos y obtengo 10 productos

Si todos los items están marcados: **¡Tu backend está completamente operativo!** 🎉

---

## 📚 Archivos de Referencia

Para más información, consulta estos archivos:

- **Backend_Test_Guia.md** - Guía completa de pruebas con Postman
- **INSTRUCCIONES_DOCKER.md** - Detalles sobre Docker
- **README_DOCKER.md** - Documentación completa de Docker
- **Checklist.md** - Seguimiento del progreso del proyecto

---

**¡Listo para desarrollar!** 🚀
