# La Bóveda de Uru

![CI/CD](https://github.com/EmaGota/BovedaUru/actions/workflows/ci-cd.yml/badge.svg)

Catálogo web de cómics hecho con **Blazor Server** y **Entity Framework Core**: filtros, fichas con enlaces de lectura, favoritos y administración con CRUD.

**Demo:** https://<nombre>.onrender.com
*(el servicio gratuito se duerme: el primer acceso puede tardar unos segundos)*

## Capturas

![Inicio](docs/inicio.png)
![Catálogo](docs/catalogo.png)

## Características

- Catálogo con filtros, ficha de cada cómic (`/comic/{id}`) y navegación programática.
- Favoritos con servicio de estado y notificación reactiva.
- Formulario de sugerencias con validación avanzada (`EditForm`, validadores propios).
- Administración (`/admin/comics`): crear, editar, eliminar, búsqueda y paginación.
- Diseño responsive con Bootstrap 5, HTML semántico y CSS aislado.
- JS interop: botón "Copiar enlace".
- Persistencia con EF Core + SQLite, migraciones y datos de ejemplo.

## Tecnologías

.NET 10 · Blazor Server · EF Core + SQLite · Bootstrap 5 · GitHub Actions · Docker · Render

## Requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- Git
- Herramienta de EF Core: `dotnet tool install --global dotnet-ef --version 10.*`

## Instalación y ejecución local

```bash
git clone https://github.com/EmaGota/BovedaUru.git
cd BovedaUru
dotnet restore
dotnet run
```

La base de datos (`boveda.db`) se crea y se llena con datos de ejemplo al iniciar.
Abre la URL que muestra la consola (por ejemplo, `https://localhost:5026`).

## Configuración

La cadena de conexión está en `appsettings.json`:

```json
"ConnectionStrings": { "Default": "Data Source=boveda.db" }
```

## Migraciones

```bash
dotnet ef migrations add NombreDeLaMigracion
dotnet ef database update
```

## Estructura

```
Components/   páginas, layout y componentes reutilizables
Datos/        DbContext y datos de seed
Servicios/    servicios de datos y de estado
Migrations/   versiones del esquema
```

## CI/CD y despliegue

Cada push y pull request a `main` compila el proyecto con GitHub Actions.
Si el build pasa en `main`, el workflow dispara el despliegue en Render
(imagen Docker construida desde el `Dockerfile`).

## Convención de commits

Se usa [Conventional Commits](https://www.conventionalcommits.org/): `feat`, `fix`, `docs`, `style`, `refactor`, `build`, `ci`, `chore`.

## Autor

Emanuel Gota — https://github.com/EmaGota