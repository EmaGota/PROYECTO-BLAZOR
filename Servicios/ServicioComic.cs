using System.ComponentModel.DataAnnotations;
using BovedaUru.Components.Modelo;
namespace BovedaUru.Servicios;

public class ComicServicio
{
    private readonly List<Comic> _comics = new()
    {
        new Comic
        {
            Id = 1,
            Titulo = "All new Ghost Rider",
            Imagen = "images/ANGR_01.jpg",
            Año = 2014,
            Editorial = "Marvel Comics",
            Grupo = "Ghost Rider",
            Enlaces = new()
            {
                new() { Nombre = "Leer en sitio A", Url = "https://ejemplo.com/a" },
                new() { Nombre = "Leer en sitio B", Url = "https://ejemplo.com/b" }
            }
        },
        new Comic
        {
            Id = 2,
            Titulo = "Beta Ray Bill #1",
            Imagen = "images/BETA_RAY_BILL_2021.jpg",
            Año = 2021,
            Editorial = "Marvel Comics",
            Grupo ="Asgard, Cosmico",
            Enlaces = new()
            {
                new() {Nombre = "Enlace 1: ", Url = "https://ejemplo.com/a"},
                new() {Nombre = "Enlace 2: ", Url = "https://ejemplo.com/b"}
            }
        },
        new Comic
        {
            Id= 3,
            Titulo ="Fear Itself: Book One",
            Imagen = "images/FEAR_ITSELF_BOOK_ONE.jpg",
            Año = 2011,
            Editorial = "Marvel Comics",
            Grupo = "Asgard, Eventos",
            Enlaces = new()
            {
                new() {Nombre = "Enlace 1: ", Url = "https://ejemplo.com/a"},
                new() {Nombre = "Enlace 2: ", Url = "https://ejemplo.com/b"}
            }

        },
        new Comic
        {
            Id = 4,
            Titulo = "Spawn Issue 15",
            Imagen = "images/SPAWN_15.jpg",
            Año = 1994,
            Editorial = "Image Comics",
            Grupo = "Otras Editoriales, Spawn",
            Enlaces = new()
            {
                new() {Nombre = "Enlace 1: ", Url = "https://ejemplo.com/a"},
                new() {Nombre = "Enlace 2: ", Url = "https://ejemplo.com/b"}
            }
        },
        new Comic
        {
            Id = 5,
            Titulo = "War of the Realms #1",
            Imagen = "images/WAR_OF_THE_REALMS_2019.jpg",
            Año = 2019,
            Editorial = "Marvel Comics",
            Grupo = "Eventos",
            Enlaces = new()
            {
                new() {Nombre = "Enlace 1: ", Url = "https://ejemplo.com/a"},
                new() {Nombre = "Enlace 2: ", Url = "https://ejemplo.com/b"}
            }
        },
        new Comic
        {
            Id = 6,
            Titulo = "Ghost rider & Blaze: Spirits of Vengeance",
            Imagen = "images/SPIRITS_OF_VENGANCE.jpg",
            Año = 1990,
            Editorial = "Image Comics",
            Grupo = "Ghost Rider, Mistico",
            Enlaces = new()
            {
                new() {Nombre = "Enlace 1: ", Url = "https://ejemplo.com/a"},
                new() {Nombre = "Enlace 2: ", Url = "https://ejemplo.com/b"}
            }
        },
        new Comic
        {
            Id = 7,
            Titulo = "Hellboy: Seed of Destruction",
            Imagen = "images/HELLBOY_ISSUE_1.jpg",
            Año = 1994,
            Editorial = "Dark Horse Comics",
            Grupo = "Otras Editoriales",
            Enlaces = new()
            {
                new() {Nombre = "Enlace 1: ", Url = "https://ejemplo.com/a"},
                new() {Nombre = "Enlace 2: ", Url = "https://ejemplo.com/b"}
            }
        },
        new Comic
        {
            Id = 8,
            Titulo = "Spawn Issue 9",
            Imagen = "images/ANGELA_SPAWN.jpg",
            Año = 1990,
            Editorial = "Image Comics",
            Grupo = "Otras Editoriales, Spawn",
            Enlaces = new()
            {
                new() {Nombre = "Enlace 1: ", Url = "https://ejemplo.com/a"},
                new() {Nombre = "Enlace 2: ", Url = "https://ejemplo.com/b"}
            }
        }
        

    };

    public List<Comic> ObtenerTodos() => _comics;
    public Comic? ObtenerPorId(int id) => _comics.FirstOrDefault(c => c.Id == id);
}