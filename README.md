# La Bóveda de Uru

**Aplicación desplegada:** [La Bóveda de Uru](https://bovedadeuru.runasp.net)

## CI/CD y despliegue

La aplicación está desplegada en **MonsterASP.NET**, donde se encuentra alojada y accesible mediante una URL pública.

- **Plataforma de alojamiento:** MonsterASP.NET.
- **Framework:** ASP.NET Core / Blazor Server.
- **Integración con código:** GitHub.
- **Compilación:** GitHub Actions.
- **Acceso público:** https://bovedadeuru.runasp.net

Para actualizar la aplicación, se envían los cambios al repositorio de GitHub y se realiza la publicación desde el panel de MonsterASP.NET mediante Git Deploy.

## Características

- Catálogo con filtros, ficha de cada cómic (`/comic/{id}`) y navegación programática.
- Favoritos con servicio de estado y notificación reactiva.
- Formulario de sugerencias con validación avanzada (`EditForm`, validadores propios).
- Administración (`/admin/comics`): crear, editar, eliminar, búsqueda y paginación.
- Diseño responsive con Bootstrap 5, HTML semántico y CSS aislado.
- JS interop: botón "Copiar enlace".
- Persistencia con EF Core + SQLite, migraciones y datos de ejemplo.

## Tecnologías

.NET 10 · Blazor Server · EF Core + SQLite · Bootstrap 5 · GitHub Actions · Docker

## Requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- Git
- Herramienta de EF Core:

```bash
dotnet tool install --global dotnet-ef --version 10.*
```

## Instalación y ejecución local

```bash
git clone https://github.com/EmaGota/BovedaUru.git
cd BovedaUru
dotnet restore
dotnet run
```

La base de datos (`boveda.db`) se crea y se llena con datos de ejemplo al iniciar.

Abrir la URL que muestra la consola (por ejemplo, `https://localhost:5026`).

## Configuración

La cadena de conexión está en `appsettings.json`:

```json
"ConnectionStrings": {
  "Default": "Data Source=boveda.db"
}
```

## Migraciones

```bash
dotnet ef migrations add NombreDeLaMigracion
dotnet ef database update
```

## Estructura

```text
Components/   páginas, layout y componentes reutilizables
Datos/        DbContext y datos de seed
Servicios/    servicios de datos y de estado
Migrations/   versiones del esquema
```

## Convención de commits

Se usa [Conventional Commits](https://www.conventionalcommits.org/): `feat`, `fix`, `docs`, `style`, `refactor`, `build`, `ci`, `chore`.

## Autor

Emanuel Gota — [GitHub](https://github.com/EmaGota)