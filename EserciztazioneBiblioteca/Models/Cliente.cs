using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace EserciztazioneBiblioteca.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        [Display(Name = "Codice fiscale")]
        public string Codice_fisc { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        [Display(Name = "Data di nascita")]
        public DateTime Data_di_nascita { get; set; }

        [Display(Name = "Numero cellulare")]
        public int Numero_cellulare { get; set; }

        public ICollection<Prestito>? Prestiti { get; set; }
    }
}
