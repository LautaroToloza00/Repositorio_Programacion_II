namespace CinePracticaParcial.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public int Anio { get; set; }
        public Genero Genero { get; set; }
    }
}
