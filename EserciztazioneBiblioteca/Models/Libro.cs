using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EserciztazioneBiblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titolo { get; set; }


        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM - dd - yyyy HH: mm}")]

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = CultureInfo("en-US"))]
        //Console.WriteLine(datetime.ToString("d", new CultureInfo("en-US"))); // 8/24/2017
        //Console.WriteLine(datetime.ToString("d", new CultureInfo("es-ES"))); // 24/8/2017
        //Console.WriteLine(datetime.ToString("d", new CultureInfo("ja-JP"))); // 2017/08/24

        [DataType(DataType.Date)]
        [Display (Name = "Anno di pubblicazione")]
        public DateTime  Anno_di_pubblicazione { get; set; }

        public string? Lingua { get; set; }

        public string Formato { get; set; }
        [Display(Name = "ISBN")]
        public string isbn { get; set; } 

        public Genere? Genere { get; set; }
        public int GenereId { get; set; }

        public Autore? Autore { get; set; }
        public int AutoreId { get; set; }

        [Display(Name = "Casa editrice")]
        public Casa_editrice? casa_Editrice { get; set; }
        public int Casa_editriceId { get; set; }

        public Prestito? Prestiti { get; set; }

        [Display(Name = "Prestito")]
        public int? PrestitoId { get; set; }

        [Display(Name = "Prezzo")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Prezzo { get; set; }


        public ICollection<LibroPrestito>? LibriPrestiti { get; set; }

    }
}
