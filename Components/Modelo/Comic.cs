namespace BovedaUru.Components.Modelo
{
    public class Comic
    {
        public string Personaje { get; set; } = "";
        public string Grupo { get; set; } = "";
        public int Año { get; set; }
        public string Editorial { get; set; } = "";
        public string Imagen { get; set; } = "";
        public string Titulo { get; set; } = "";

        public int Id {get; set;}
        public string Descripcion { get; set;} = "";
        public List<EnlacesComic> Enlaces{ get; set; } = new();
    }

    public class EnlacesComic
    {
        public string Nombre { get; set;} = "";
        public string Url {get; set;} = "";
    }
}