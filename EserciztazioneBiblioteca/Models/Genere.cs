namespace EserciztazioneBiblioteca.Models
{
    public class Genere
    {
        public int Id { get; set; }

        public string Descrizione { get; set; }
        public ICollection<Libro>? Libri { get; set; }
    }
}
