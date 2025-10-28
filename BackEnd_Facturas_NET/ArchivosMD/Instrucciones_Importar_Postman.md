# 📬 Cómo Importar la Colección de Postman

Esta guía te muestra cómo importar la colección de endpoints del Sistema de Facturas en Postman.

---

## 📁 Archivo a Importar

**Ubicación:**
```
BackEnd_Facturas_NET/ArchivosMD/Sistema_Facturas_API.postman_collection.json
```

**Ruta completa:**
```
C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET\BackEnd_Facturas_NET\ArchivosMD\Sistema_Facturas_API.postman_collection.json
```

---

## 🚀 Paso a Paso para Importar

### **Paso 1: Abrir Postman**

1. Inicia Postman en tu computadora
2. Si es la primera vez que lo usas, crea una cuenta o usa el modo "Skip signing in to use Postman"

---

### **Paso 2: Importar la Colección**

#### **Opción A - Importar por Archivo (Recomendado)**

1. Haz clic en el botón **"Import"** en la esquina superior izquierda
2. Se abrirá una ventana de importación
3. Haz clic en **"Upload Files"** o simplemente arrastra el archivo JSON
4. Navega hasta:
   ```
   C:\Users\1\Desktop\SENA\SextoSemestre\JohanBack\Sistema_Facturas_NET\BackEnd_Facturas_NET\ArchivosMD\Sistema_Facturas_API.postman_collection.json
   ```
5. Selecciona el archivo y haz clic en **"Abrir"**
6. Postman detectará automáticamente el archivo como una colección
7. Haz clic en **"Import"**

#### **Opción B - Arrastrar y Soltar**

1. Abre el explorador de archivos de Windows
2. Navega hasta la carpeta `ArchivosMD`
3. Arrastra el archivo `Sistema_Facturas_API.postman_collection.json` directamente a la ventana de Postman
4. Postman detectará el archivo automáticamente
5. Haz clic en **"Import"**

---

### **Paso 3: Verificar la Importación**

Una vez importada, deberías ver en la barra lateral izquierda:

```
📁 Collections
  └─ Sistema Facturas API
      ├─ 📁 Usuarios (5 requests)
      │   ├─ GET - Obtener Todos los Usuarios
      │   ├─ GET - Obtener Usuario por ID
      │   ├─ POST - Crear Nuevo Usuario
      │   ├─ PUT - Actualizar Usuario
      │   └─ DELETE - Eliminar Usuario
      │
      ├─ 📁 Productos (5 requests)
      │   ├─ GET - Obtener Todos los Productos
      │   ├─ GET - Obtener Producto por ID
      │   ├─ POST - Crear Nuevo Producto
      │   ├─ PUT - Actualizar Producto
      │   └─ DELETE - Eliminar Producto
      │
      └─ 📁 Facturas (6 requests)
          ├─ GET - Obtener Todas las Facturas
          ├─ GET - Obtener Factura por ID
          ├─ GET - Obtener Facturas por Usuario
          ├─ POST - Crear Factura Completa
          ├─ POST - Crear Factura con Múltiples Productos
          └─ DELETE - Eliminar Factura
```

**Total: 16 endpoints listos para usar!**

---

## ✅ Probar los Endpoints

### **Antes de Probar: Asegúrate de que el Backend esté Corriendo**

```bash
# Terminal 1 - Levantar Docker
docker-compose up -d

# Terminal 2 - Ejecutar Backend
cd BackEnd_Facturas_NET
dotnet run
```

Deberías ver:
```
Now listening on: http://localhost:5250
```

---

### **Prueba 1: GET Todos los Usuarios**

1. En Postman, expande la carpeta **"Usuarios"**
2. Haz clic en **"GET - Obtener Todos los Usuarios"**
3. Haz clic en el botón azul **"Send"**

**Resultado esperado (200 OK):**
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

✅ Si ves esta respuesta, todo está funcionando correctamente!

---

### **Prueba 2: GET Todos los Productos**

1. Expande la carpeta **"Productos"**
2. Haz clic en **"GET - Obtener Todos los Productos"**
3. Haz clic en **"Send"**

**Resultado esperado (200 OK):**
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

✅ Deberías ver 10 productos!

---

### **Prueba 3: POST Crear una Factura**

1. Expande la carpeta **"Facturas"**
2. Haz clic en **"POST - Crear Factura Completa"**
3. Verifica que en la pestaña **"Body"** esté seleccionado **"raw"** y **"JSON"**
4. El JSON ya está precargado:
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
5. Haz clic en **"Send"**

**Resultado esperado (201 Created):**
```json
{
  "id": 1,
  "usuarioId": 1,
  "fecha": "2025-10-27T...",
  "total": 3150000.00,
  "usuario": { ... },
  "detalles": [ ... ]
}
```

✅ La factura se creó correctamente!

---

## 🎯 Endpoints Incluidos

### **Usuarios (5 endpoints)**
| Método | Nombre | Descripción |
|--------|--------|-------------|
| GET | Obtener Todos los Usuarios | Lista completa de usuarios |
| GET | Obtener Usuario por ID | Usuario específico |
| POST | Crear Nuevo Usuario | Crea un usuario |
| PUT | Actualizar Usuario | Modifica un usuario |
| DELETE | Eliminar Usuario | Elimina un usuario |

### **Productos (5 endpoints)**
| Método | Nombre | Descripción |
|--------|--------|-------------|
| GET | Obtener Todos los Productos | Lista completa de productos |
| GET | Obtener Producto por ID | Producto específico |
| POST | Crear Nuevo Producto | Crea un producto |
| PUT | Actualizar Producto | Modifica un producto |
| DELETE | Eliminar Producto | Elimina un producto |

### **Facturas (6 endpoints)**
| Método | Nombre | Descripción |
|--------|--------|-------------|
| GET | Obtener Todas las Facturas | Lista completa de facturas |
| GET | Obtener Factura por ID | Factura específica |
| GET | Obtener Facturas por Usuario | Facturas de un usuario |
| POST | Crear Factura Completa | Crea factura básica |
| POST | Crear Factura con Múltiples Productos | Ejemplo con 3+ productos |
| DELETE | Eliminar Factura | Elimina una factura |

---

## 📝 Notas Importantes

### **URLs Preconfiguradas**
Todos los endpoints ya tienen la URL base configurada:
```
http://localhost:5250
```

Si tu backend corre en otro puerto, puedes cambiar la variable:
1. Haz clic derecho en la colección "Sistema Facturas API"
2. Selecciona "Edit"
3. Ve a la pestaña "Variables"
4. Cambia el valor de `base_url`

---

### **Headers Automáticos**
Los endpoints POST y PUT ya tienen el header configurado:
```
Content-Type: application/json
```

No necesitas agregar nada manualmente.

---

### **Bodies Precargados**
Todos los requests POST y PUT vienen con ejemplos de JSON listos para usar. Solo tienes que hacer clic en "Send".

---

### **Descripciones Incluidas**
Cada endpoint tiene una descripción detallada. Para verla:
1. Selecciona un endpoint
2. Mira el panel derecho donde dice "Description"

---

## 🔧 Solución de Problemas

### **Error: "Could not get any response"**

**Causa:** El backend no está corriendo.

**Solución:**
```bash
cd BackEnd_Facturas_NET
dotnet run
```

---

### **Error: "Connection refused"**

**Causa:** Docker SQL Server no está corriendo.

**Solución:**
```bash
docker-compose up -d
```

---

### **Error 404: "Not Found"**

**Causa:** La URL está mal escrita.

**Solución:**
Verifica que la URL sea exactamente:
```
http://localhost:5250/api/Usuarios
```

---

### **Error 500: "Internal Server Error"**

**Causas comunes:**
1. El usuarioId o productoId no existen
2. La base de datos no se creó correctamente

**Solución:**
1. Primero ejecuta GET /api/Usuarios y GET /api/Productos
2. Usa los IDs que aparecen en las respuestas
3. Si persiste, reinicia el backend

---

## 📊 Flujo de Prueba Recomendado

Sigue este orden para probar todos los endpoints:

1. ✅ **GET /api/Usuarios** - Ver usuarios existentes
2. ✅ **GET /api/Productos** - Ver productos existentes
3. ✅ **POST /api/Usuarios** - Crear un nuevo usuario
4. ✅ **POST /api/Productos** - Crear un nuevo producto
5. ✅ **POST /api/Facturas** - Crear una factura completa
6. ✅ **GET /api/Facturas** - Ver la factura creada
7. ✅ **GET /api/Facturas/Usuario/1** - Ver facturas de un usuario
8. ✅ **PUT /api/Usuarios/4** - Actualizar el usuario creado
9. ✅ **DELETE /api/Facturas/1** - Eliminar la factura
10. ✅ **DELETE /api/Usuarios/4** - Eliminar el usuario

---

## 🎉 ¡Listo!

Ahora tienes todos los endpoints del Sistema de Facturas listos para probar en Postman.

**Ventajas de usar esta colección:**
- ✅ 16 endpoints preconfigurados
- ✅ URLs correctas
- ✅ Headers automáticos
- ✅ JSON de ejemplo incluidos
- ✅ Descripciones detalladas
- ✅ Organizados por categorías

---

## 📚 Documentos Relacionados

- **Backend_Test_Guia.md** - Guía completa de pruebas
- **Como_Ejecutar_Backend.md** - Cómo levantar el backend
- **Checklist.md** - Estado del proyecto

---

**¡Feliz testing!** 🚀
