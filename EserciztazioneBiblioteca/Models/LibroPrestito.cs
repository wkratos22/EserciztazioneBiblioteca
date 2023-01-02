namespace EserciztazioneBiblioteca.Models
{
    public class LibroPrestito
    {
        public int Id { get; set; }     

        public Prestito? Prestito { get; set; }
        public int PrestitoId { get; set; }

        public Libro? Libro{ get; set; }
        public int LibroId { get; set; }


    }
}
