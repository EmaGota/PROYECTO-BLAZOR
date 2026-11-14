using System.ComponentModel.DataAnnotations;

namespace BovedaUru.Components.Modelo;

public class SugerenciaComic : IValidatableObject
{
    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "El título debe tener entre 3 y 80 caracteres.")]
    public string Titulo { get; set; } = "";

    [Required(ErrorMessage = "La editorial es obligatoria.")]
    public string Editorial { get; set; } = "";

    [Required(ErrorMessage = "El año es obligatorio.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "El año debe tener exactamente 4 números.")]
    public string Año { get; set; } = "";

    [Required(ErrorMessage = "La imagen es obligatoria.")]
    [RegularExpression(@"^images/[\w\-]+\.(jpg|jpeg|png|webp)$",
        ErrorMessage = "Usa una ruta como images/portada.jpg")]
    public string Imagen { get; set; } = "";

    [StringLength(300, ErrorMessage = "Máximo 300 caracteres.")]
    public string Descripcion { get; set; } = "";

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (int.TryParse(Año, out var a) && (a < 1930 || a > DateTime.Now.Year))
        {
            yield return new ValidationResult(
                $"El año debe estar entre 1930 y {DateTime.Now.Year}.",
                new[] { nameof(Año) });
        }
    }
}