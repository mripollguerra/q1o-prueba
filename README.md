# 🎓 Student Management System

Sistema web de gestión académica basado en ASP.NET Core y Razor Pages con arquitectura limpia (**Clean Architecture**), patrónes como CQRS, Repository y Unit Of Work aplicando los principios de SOLID

---

## 🚀 Tecnologías Usadas

- ASP.NET Core 8
- Razor Pages + MVC
- Entity Framework Core
- SQL Server (Docker)
- CQRS Pattern
- Clean Architecture
- Repository + Unit of Work

---

## 🧪 Cadena de conexión

Dependiendo del proveedor, cambia la cadena en `appsettings.json`:

### SQL Server

```json
"Privider":"SqlServer",
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=master;User Id=sa;Password=rootROOTmaster;TrustServerCertificate=True"
}
```

### MySQL (alternativa futura)

```json
"Privider":"Mysql",
"DbVersion": "11.4.2",
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=3306;Database=dbname;User=root;Password=root"
}
```

---

## ▶️ Cómo ejecutar el proyecto

1. Dentro del proyecto Web ejecutar el comando dotnet run 
2. Navega a: `http://localhost:5091`

---

## 🧼 Clean Architecture implementada

Separación por capas:

```
├── Domain
│   └── Entidades y lógica
├── Application
│   └── CQRS: Commands / Queries
├── Infrastructure
│   └── EF Core, Repositorios, Unit of Work
├── Web
│   └── UI Razor Pages + Controllers
```

### 🧩 Inyección de dependencias

En `Program.cs`:

```csharp
builder.Services.AddCommands(); -- Inyeccion de los comando de CQRS
builder.Services.AddQueries(); -- Inyeccion de los queries de CQRS
builder.Services.AddRepository<Q10Context>(); -- Inyeccion del contexto dinamico de EF Core
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); -- Inyeccion del Patron Unit Of Work
```

---

## ✅ Funcionalidades implementadas

### Estudiantes

- Crear, Editar, Eliminar
- Listado completo

### Materias

- Crear, Editar, Eliminar
- Listado completo

### Inscripción de Materias

- Asignar materias a estudiantes
- Validaciones:
  - No permitir duplicados
  - No permitir más de **3 materias** con más de **4 créditos**
