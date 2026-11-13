using BovedaUru.Components.Modelo;
using Microsoft.EntityFrameworkCore;

namespace BovedaUru.Datos;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Comic> Comics => Set<Comic>();
    public DbSet<EnlacesComic> Enlaces => Set<EnlacesComic>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Comic>(e =>
        {
            e.Property(c => c.Titulo).IsRequired().HasMaxLength(120);
            e.Property(c => c.Personaje).IsRequired().HasMaxLength(80);
            e.Property(c => c.Editorial).IsRequired().HasMaxLength(120);
            e.Property(c => c.Imagen).IsRequired().HasMaxLength(200);

            e.HasMany(c => c.Enlaces)
             .WithOne(l => l.Comic)
             .HasForeignKey(l => l.ComicId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        mb.Entity<Comic>().HasData(Semilla.Comics());
        mb.Entity<EnlacesComic>().HasData(Semilla.Enlaces());
    }
}

public static class Semilla
{
    public static Comic[] Comics() => new[]
    {
        new Comic { Id = 1, Personaje = "Ghost Rider", Grupo = "Ghost Rider", Año = 2014, Editorial = "Marvel Comics", Imagen = "images/ANGR_01.jpg", Titulo = "All-New Ghost Rider" },
        new Comic { Id = 2, Personaje = "Beta Ray Bill", Grupo = "Asgard, Cosmico", Año = 2021, Editorial = "Marvel Comics", Imagen = "images/BETA_RAY_BILL_2021.jpg", Titulo = "Beta Ray Bill" },
        new Comic { Id = 3, Personaje = "Varios", Grupo = "Asgard, Eventos", Año = 2011, Editorial = "Marvel Comics", Imagen = "images/FEAR_ITSELF_BOOK_ONE.jpg", Titulo = "Fear Itself: Book One" },
        new Comic { Id = 4, Personaje = "Varios", Grupo = "Eventos", Año = 2019, Editorial = "Marvel Comics", Imagen = "images/WAR_OF_THE_REALMS_2019.jpg", Titulo = "War of the Realms" },
        new Comic { Id = 5, Personaje = "Ghost Rider", Grupo = "Ghost Rider", Año = 1990, Editorial = "Marvel Comics", Imagen = "images/SPIRITS_OF_VENGANCE.jpg", Titulo = "Ghost Rider & Blaze: Spirits of Vengeance" },
        new Comic { Id = 6, Personaje = "Hellboy", Grupo = "Hellboy", Año = 2001, Editorial = "Dark Horse Comics, Otras Editoriales", Imagen = "images/HELLBOY_ISSUE_1.jpg", Titulo = "Hellboy: Seed of Destruction" },
        new Comic { Id = 7, Personaje = "Spawn", Grupo = "Spawn", Año = 1990, Editorial = "Image Comics, Otras Editoriales", Imagen = "images/SPAWN_15.jpg", Titulo = "Spawn: issue #15" },
        new Comic { Id = 8, Personaje = "Angela", Grupo = "Angela, Spawn", Año = 1990, Editorial = "Image Comics, Otras Editoriales", Imagen = "images/ANGELA_SPAWN.jpg", Titulo = "Spawn: Issue #9" }
    };

    // Reemplaza las URLs de ejemplo por las reales
    public static EnlacesComic[] Enlaces() => new[]
    {
        new EnlacesComic { Id = 1, ComicId = 1, Nombre = "Leer en sitio A", Url = "https://ejemplo.com/a" },
        new EnlacesComic { Id = 2, ComicId = 1, Nombre = "Leer en sitio B", Url = "https://ejemplo.com/b" },
        new EnlacesComic { Id = 3, ComicId = 2, Nombre = "Leer en sitio A", Url = "https://ejemplo.com/c" }
    };
}