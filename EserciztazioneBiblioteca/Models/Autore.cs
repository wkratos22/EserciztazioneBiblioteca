using System.ComponentModel.DataAnnotations;

namespace EserciztazioneBiblioteca.Models
{
    public class Autore
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        [Display(Name = "Anno di nascita")]
        public DateTime Anno_di_nascita { get; set; }

        [Display(Name = "Luogo di nascita")]
        public string Luogo_di_nascita { get; set; }

        public ICollection<Libro>? Libri { get; set; }

    }
}
