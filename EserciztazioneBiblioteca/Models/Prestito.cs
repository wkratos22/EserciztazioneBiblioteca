using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EserciztazioneBiblioteca.Models
{
    public class Prestito
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data inizio")]
        public DateTime Data_inizio { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data fine")]
        public DateTime Data_fine { get; set; }

        public Cliente? Clienti { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public string Descrizione { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Prezzo { get; set; }

        public ICollection<LibroPrestito>? LibriPrestiti { get; set; }
    }
}
