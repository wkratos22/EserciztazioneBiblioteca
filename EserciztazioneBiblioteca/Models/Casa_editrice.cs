using System.ComponentModel.DataAnnotations;

namespace EserciztazioneBiblioteca.Models
{
    public class Casa_editrice
    {
        public int Id { get; set; }

        [Display(Name = "Nome editore")]
        public string nome_editore { get; set; }

        public ICollection<Libro>? Libri { get; set; }
    }
}
