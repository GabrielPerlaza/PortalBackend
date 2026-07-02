# Portal Backend

API REST desarrollada en **ASP.NET Core** para la gestión de artículos y contenido digital. Este proyecto forma parte de un portal administrativo que permite crear, editar, visualizar y eliminar artículos, además de gestionar imágenes mediante Cloudinary.

## Tecnologías utilizadas

* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* AutoMapper
* Cloudinary
* Arquitectura por capas
* DTOs
* Patrón Repositorio

## Arquitectura

El proyecto está organizado siguiendo una arquitectura por capas para facilitar el mantenimiento y escalabilidad:

* **APIPortal**: Controladores y configuración de la API.
* **Capa_Negocio**: Lógica de negocio y servicios.
* **Capa_Datos**: Acceso a datos y repositorios.
* **Capa_DTO**: Objetos de transferencia de datos.
* **Modelos**: Entidades del dominio.
* **Utilidades**: Configuraciones compartidas y AutoMapper.

## Funcionalidades

### Gestión de artículos

* Crear artículos
* Consultar artículos
* Editar artículos
* Eliminar artículos
* Obtener detalle de un artículo

### Gestión de contenido

* Título
* Resumen
* Contenido
* Imagen de portada
* Fecha de creación

### Gestión de imágenes

* Carga de imágenes a Cloudinary
* Almacenamiento de URL de imágenes
* Asociación de imágenes a artículos

## Base de datos

El proyecto utiliza PostgreSQL como sistema gestor de base de datos.

### Migraciones

Crear migración:

```bash
dotnet ef migrations add NombreMigracion --project Capa_Datos --startup-project APIPortal
```

Actualizar base de datos:

```bash
dotnet ef database update --project Capa_Datos --startup-project APIPortal
```

## Configuración

Agregar la cadena de conexión y las credenciales de Cloudinary en `appsettings.json`.

### PostgreSQL

```json
"ConnectionStrings": {
  "cadenaSQL": "Host=localhost;Port=5432;Database=PortalDB;Username=postgres;Password=tu_password"
}
```

### Cloudinary

```json
"Cloudinary": {
  "CloudName": "tu-cloud-name",
  "ApiKey": "tu-api-key",
  "ApiSecret": "tu-api-secret"
}
```

## Ejecución

Restaurar paquetes:

```bash
dotnet restore
```

Compilar proyecto:

```bash
dotnet build
```

Ejecutar API:

```bash
dotnet run --project APIPortal
```

## Estado del proyecto

Actualmente el proyecto cuenta con:

* CRUD de artículos
* Integración con PostgreSQL
* Integración con Cloudinary
* Arquitectura por capas
* DTOs y AutoMapper

Próximamente:

* Autenticación JWT
* Gestión de usuarios
* Categorías
* Etiquetas
* Dashboard administrativo
* Roles y permisos

## Autor

Desarrollado por Gabriel Perlaza como proyecto de administración de contenido y publicación de artículos.
