using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EserciztazioneBiblioteca.Models;

namespace EserciztazioneBiblioteca.Data
{
    public class EserciztazioneBibliotecaContext : DbContext
    {
        public EserciztazioneBibliotecaContext (DbContextOptions<EserciztazioneBibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<EserciztazioneBiblioteca.Models.Genere> Genere { get; set; } = default!;

        public DbSet<EserciztazioneBiblioteca.Models.Autore> Autore { get; set; } = default!;

        public DbSet<EserciztazioneBiblioteca.Models.Casa_editrice> Casa_editrice { get; set; } = default!;

        public DbSet<EserciztazioneBiblioteca.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<EserciztazioneBiblioteca.Models.Libro> Libro { get; set; } = default!;

        public DbSet<EserciztazioneBiblioteca.Models.Prestito> Prestito { get; set; } = default!;
    }
}
