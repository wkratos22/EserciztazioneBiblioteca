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
    public class CasaEditriciController : Controller
    {
        private readonly EserciztazioneBibliotecaContext _context;

        public CasaEditriciController(EserciztazioneBibliotecaContext context)
        {
            _context = context;
        }

        // GET: CasaEditrici
        public async Task<IActionResult> Index()
        {
              return _context.Casa_editrice != null ? 
                          View(await _context.Casa_editrice.ToListAsync()) :
                          Problem("Entity set 'EserciztazioneBibliotecaContext.Casa_editrice'  is null.");
        }

        // GET: CasaEditrici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Casa_editrice == null)
            {
                return NotFound();
            }

            var casa_editrice = await _context.Casa_editrice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa_editrice == null)
            {
                return NotFound();
            }

            return View(casa_editrice);
        }

        // GET: CasaEditrici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasaEditrici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome_editore")] Casa_editrice casa_editrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casa_editrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casa_editrice);
        }

        // GET: CasaEditrici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Casa_editrice == null)
            {
                return NotFound();
            }

            var casa_editrice = await _context.Casa_editrice.FindAsync(id);
            if (casa_editrice == null)
            {
                return NotFound();
            }
            return View(casa_editrice);
        }

        // POST: CasaEditrici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome_editore")] Casa_editrice casa_editrice)
        {
            if (id != casa_editrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casa_editrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Casa_editriceExists(casa_editrice.Id))
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
            return View(casa_editrice);
        }

        // GET: CasaEditrici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Casa_editrice == null)
            {
                return NotFound();
            }

            var casa_editrice = await _context.Casa_editrice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa_editrice == null)
            {
                return NotFound();
            }

            return View(casa_editrice);
        }

        // POST: CasaEditrici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Casa_editrice == null)
            {
                return Problem("Entity set 'EserciztazioneBibliotecaContext.Casa_editrice'  is null.");
            }
            var casa_editrice = await _context.Casa_editrice.FindAsync(id);
            if (casa_editrice != null)
            {
                _context.Casa_editrice.Remove(casa_editrice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Casa_editriceExists(int id)
        {
          return (_context.Casa_editrice?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
