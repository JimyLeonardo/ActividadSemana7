using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Comercializadora.Models;

namespace Comercializadora.Controllers
{
    public class TipoTerceroesController : Controller
    {
        private readonly ComercializadoraContext _context;

        public TipoTerceroesController(ComercializadoraContext context)
        {
            _context = context;
        }

        // GET: TipoTerceroes
        public async Task<IActionResult> Index()
        {
              return _context.TipoTerceros != null ? 
                          View(await _context.TipoTerceros.ToListAsync()) :
                          Problem("Entity set 'ComercializadoraContext.TipoTerceros'  is null.");
        }

        // GET: TipoTerceroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoTerceros == null)
            {
                return NotFound();
            }

            var tipoTercero = await _context.TipoTerceros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTercero == null)
            {
                return NotFound();
            }

            return View(tipoTercero);
        }

        // GET: TipoTerceroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTerceroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha")] TipoTercero tipoTercero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTercero);
        }

        // GET: TipoTerceroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoTerceros == null)
            {
                return NotFound();
            }

            var tipoTercero = await _context.TipoTerceros.FindAsync(id);
            if (tipoTercero == null)
            {
                return NotFound();
            }
            return View(tipoTercero);
        }

        // POST: TipoTerceroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha")] TipoTercero tipoTercero)
        {
            if (id != tipoTercero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTerceroExists(tipoTercero.Id))
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
            return View(tipoTercero);
        }

        // GET: TipoTerceroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoTerceros == null)
            {
                return NotFound();
            }

            var tipoTercero = await _context.TipoTerceros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTercero == null)
            {
                return NotFound();
            }

            return View(tipoTercero);
        }

        // POST: TipoTerceroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoTerceros == null)
            {
                return Problem("Entity set 'ComercializadoraContext.TipoTerceros'  is null.");
            }
            var tipoTercero = await _context.TipoTerceros.FindAsync(id);
            if (tipoTercero != null)
            {
                _context.TipoTerceros.Remove(tipoTercero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTerceroExists(int id)
        {
          return (_context.TipoTerceros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
