using System.ComponentModel.DataAnnotations;

namespace BovedaUru.Components.Modelo
{
    public class Comic
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "El título debe tener entre 3 y 120 caracteres.")]
        public string Titulo { get; set; } = "";

        [Required(ErrorMessage = "El personaje es obligatorio.")]
        public string Personaje { get; set; } = "";

        public string Grupo { get; set; } = "";

        [Range(1930, 2100, ErrorMessage = "El año debe estar entre 1930 y 2100.")]
        public int Año { get; set; }

        [Required(ErrorMessage = "La editorial es obligatoria.")]
        public string Editorial { get; set; } = "";

        [Required(ErrorMessage = "La imagen es obligatoria.")]
        [RegularExpression(@"^images/[\w\-]+\.(jpg|jpeg|png|webp)$", ErrorMessage = "Usa una ruta como images/portada.jpg")]
        public string Imagen { get; set; } = "";

        public string Descripcion { get; set; } = "";

        public List<EnlacesComic> Enlaces { get; set; } = new();
    }

    public class EnlacesComic
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Url { get; set; } = "";

        public int ComicId { get; set; }      // clave foránea
        public Comic? Comic { get; set; }     // navegación
    }

    public record ResultadoPaginado<T>(List<T> Items, int Total, int Pagina, int Tamano)
    {
        public int TotalPaginas => (int)Math.Ceiling(Total / (double)Tamano);
    }
}