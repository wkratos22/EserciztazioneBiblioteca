using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EserciztazioneBiblioteca.Data;
using EserciztazioneBiblioteca.Models;

namespace EserciztazioneBiblioteca.Controllers
{
    public class LibriController : Controller
    {
        private readonly EserciztazioneBibliotecaContext _context;

        public LibriController(EserciztazioneBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libri
        public async Task<IActionResult> Index()
        {
            var eserciztazioneBibliotecaContext = await _context.Libro
                .Include(l => l.Autore)
                .Include(l => l.Genere)
                .Include(l => l.Prestiti)
                .Include(l => l.casa_Editrice)
                .ToListAsync();
            return View( eserciztazioneBibliotecaContext);
        }

        // GET: Libri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libro == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro
                .Include(l => l.Autore)
                .Include(l => l.Genere)
                .Include(l => l.Prestiti)
                .Include(l => l.casa_Editrice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libri/Create
        public IActionResult Create()
        {
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Nome");
            ViewData["GenereId"] = new SelectList(_context.Genere, "Id", "Descrizione");
            ViewData["PrestitoId"] = new SelectList(_context.Set<Prestito>(), "Id", "Id");
            ViewData["Casa_editriceId"] = new SelectList(_context.Casa_editrice, "Id", "nome_editore");
            return View();
        }

        // POST: Libri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titolo,Anno_di_pubblicazione,Lingua,Formato,isbn,GenereId,AutoreId,Casa_editriceId,PrestitoId,Prezzo")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Id", libro.AutoreId);
            ViewData["GenereId"] = new SelectList(_context.Genere, "Id", "Id", libro.GenereId);
            ViewData["PrestitoId"] = new SelectList(_context.Set<Prestito>(), "Id", "Id", libro.PrestitoId);
            ViewData["Casa_editriceId"] = new SelectList(_context.Casa_editrice, "Id", "Id", libro.Casa_editriceId);
            return View(libro);

        }

        // GET: Libri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libro == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Nome", libro.AutoreId);
            ViewData["GenereId"] = new SelectList(_context.Genere, "Id", "Descrizione", libro.GenereId);
            ViewData["PrestitoId"] = new SelectList(_context.Set<Prestito>(), "Id", "Id", libro.PrestitoId);
            ViewData["Casa_editriceId"] = new SelectList(_context.Casa_editrice, "Id", "nome_editore", libro.Casa_editriceId);
            return View(libro);
        }

        // POST: Libri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titolo,Anno_di_pubblicazione,Lingua,Formato,isbn,GenereId,AutoreId,Casa_editriceId,PrestitoId,Prezzo")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoreId"] = new SelectList(_context.Autore, "Id", "Nome", libro.AutoreId);
            ViewData["GenereId"] = new SelectList(_context.Genere, "Id", "Descrizione", libro.GenereId);
            ViewData["PrestitoId"] = new SelectList(_context.Set<Prestito>(), "Id", "Id", libro.PrestitoId);
            ViewData["Casa_editriceId"] = new SelectList(_context.Casa_editrice, "Id", "nome_editore", libro.Casa_editriceId);
            return View(libro);
        }

        // GET: Libri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libro == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro
                .Include(l => l.Autore)
                .Include(l => l.Genere)
                .Include(l => l.Prestiti)
                .Include(l => l.casa_Editrice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libro == null)
            {
                return Problem("Entity set 'EserciztazioneBibliotecaContext.Libro'  is null.");
            }
            var libro = await _context.Libro.FindAsync(id);
            if (libro != null)
            {
                _context.Libro.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return (_context.Libro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
