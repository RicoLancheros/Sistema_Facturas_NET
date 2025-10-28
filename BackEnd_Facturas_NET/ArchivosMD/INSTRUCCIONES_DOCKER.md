# 🐳 Instrucciones para Ejecutar Docker SQL Server

## 📍 PASO 1: Ubicarte en la Carpeta del Proyecto

Abre una terminal (PowerShell o CMD) y navega a la raíz del proyecto:

```bash
cd C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET
```

## 🚀 PASO 2: Levantar el Contenedor de SQL Server

Ejecuta el siguiente comando:

```bash
docker-compose up -d
```

**Explicación:**
- `docker-compose up` → Levanta los servicios definidos en `docker-compose.yml`
- `-d` → Modo "detached" (en segundo plano)

Este comando:
- Descargará la imagen de SQL Server 2022 (solo la primera vez, ~600MB)
- Creará un contenedor llamado `sqlserver_facturas`
- Lo expondrá en el puerto `1433`
- Creará un volumen persistente para los datos

## ✅ PASO 3: Verificar que el Contenedor Está Corriendo

Ejecuta:

```bash
docker ps
```

Deberías ver algo como esto:

```
CONTAINER ID   IMAGE                                        STATUS          PORTS                    NAMES
xxxxxxxxxxxx   mcr.microsoft.com/mssql/server:2022-latest   Up X seconds    0.0.0.0:1433->1433/tcp   sqlserver_facturas
```

## ⏳ Tiempo de Espera

**Primera vez:** La descarga puede tomar entre 5-15 minutos dependiendo de tu conexión.

**Siguientes veces:** El contenedor arrancará en segundos.

## 📊 Comandos Útiles Adicionales

### Ver logs del contenedor (si hay problemas):
```bash
docker logs sqlserver_facturas
```

### Detener el contenedor:
```bash
docker-compose down
```

### Reiniciar el contenedor:
```bash
docker-compose restart
```

### Eliminar contenedor y datos:
```bash
docker-compose down -v
```

## 🔑 Credenciales de SQL Server

- **Server:** `localhost,1433`
- **Usuario:** `sa`
- **Contraseña:** `YourStrong@Passw0rd`
- **Base de Datos:** `FacturasDB` (se creará automáticamente)

## ⚠️ Problemas Comunes

### Error: "port is already allocated"
→ El puerto 1433 ya está en uso. Detén cualquier SQL Server local o cambia el puerto en `docker-compose.yml`

### Error: "docker daemon is not running"
→ Asegúrate de que Docker Desktop esté abierto y corriendo

### Contenedor se detiene inmediatamente
→ Revisa los logs: `docker logs sqlserver_facturas`

## ✅ Una Vez el Contenedor Esté Corriendo

Continúa con los siguientes pasos del proyecto:

1. Crear la migración de Entity Framework
2. Ejecutar el Backend
3. La base de datos se creará automáticamente

---

**Archivo ubicado en:** `Sistema_Facturas_NET/INSTRUCCIONES_DOCKER.md`
