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
    public class PrestitoController : Controller
    {
        private readonly EserciztazioneBibliotecaContext _context;

        public PrestitoController(EserciztazioneBibliotecaContext context)
        {
            _context = context;
        }

        // GET: Prestito
        public async Task<IActionResult> Index()
        {

            var eserciztazioneBibliotecaContext = await _context.Prestito.Include(p => p.Clienti).ToListAsync();
            var clienti = await _context.Cliente.Select(e=> new { e.Id, NomeCompleto = e.Nome + " " + e.Cognome }).ToListAsync();
            ViewData["Clienti"] = new SelectList(clienti,"Id", "NomeCompleto");
            ViewData["Example"] = "Ciao gatto";
            return View( eserciztazioneBibliotecaContext);
        }

        // GET: Prestito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prestito == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestito
                .Include(p => p.Clienti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestito == null)
            {
                return NotFound();
            }

            return View(prestito);
        }

        // GET: Prestito/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            return View();
        }

        // POST: Prestito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit([Bind("Id,Data_inizio,Data_fine,ClienteId,Descrizione,Prezzo")] Prestito prestito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", prestito.ClienteId);
            return View(prestito);
        }


        // GET: Prestito/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            /*var Prestito = await _context.Prestito.Where(p => p.Id = id).FirstOrDefaultAsync();
            return PartialView("_EditPrestitoPartialView", prestito);*/


            if (id == null || _context.Prestito == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestito.FindAsync(id);
            if (prestito == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", prestito.ClienteId); 
            return PartialView("_EditPrestitoPartialView", prestito);
        }


        // POST: Prestito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data_inizio,Data_fine,ClienteId,Descrizione,Prezzo")] Prestito prestito)
        {
            
            
            if (id != prestito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestitoExists(prestito.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", prestito.ClienteId);
            return PartialView("_EditPrestitoPartialView", prestito);
        }
            
        

        // GET: Prestito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prestito == null)
            {
                return NotFound();
            }

            var prestito = await _context.Prestito
                .Include(p => p.Clienti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestito == null)
            {
                return NotFound();
            }

            return View(prestito);
        }

        // POST: Prestito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prestito == null)
            {
                return Problem("Entity set 'EserciztazioneBibliotecaContext.Prestito'  is null.");
            }
            var prestito = await _context.Prestito.FindAsync(id);
            if (prestito != null)
            {
                _context.Prestito.Remove(prestito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestitoExists(int id)
        {
          return (_context.Prestito?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
