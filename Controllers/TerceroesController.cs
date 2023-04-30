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
    public class TerceroesController : Controller
    {
        private readonly ComercializadoraContext _context;

        public TerceroesController(ComercializadoraContext context)
        {
            _context = context;
        }

        // GET: Terceroes
        public async Task<IActionResult> Index()
        {
            var comercializadoraContext = _context.Terceros.Include(t => t.IdTipoTerceroNavigation);
            return View(await comercializadoraContext.ToListAsync());
        }

        // GET: Terceroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Terceros == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .Include(t => t.IdTipoTerceroNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // GET: Terceroes/Create
        public IActionResult Create()
        {
            ViewData["IdTipoTercero"] = new SelectList(_context.TipoTerceros, "Id", "Nombre");
            return View();
        }

        // POST: Terceroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Documento,Nombre,Apellido,Telefono,Correo,Direccion,Estado,IdTipoTercero,Fecha")] Tercero tercero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoTercero"] = new SelectList(_context.TipoTerceros, "Id", "Nombre", tercero.IdTipoTercero);
            return View(tercero);
        }

        // GET: Terceroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Terceros == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero == null)
            {
                return NotFound();
            }
            ViewData["IdTipoTercero"] = new SelectList(_context.TipoTerceros, "Id", "Nombre", tercero.IdTipoTercero);
            return View(tercero);
        }

        // POST: Terceroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Documento,Nombre,Apellido,Telefono,Correo,Direccion,Estado,IdTipoTercero,Fecha")] Tercero tercero)
        {
            if (id != tercero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerceroExists(tercero.Id))
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
            ViewData["IdTipoTercero"] = new SelectList(_context.TipoTerceros, "Id", "Nombre", tercero.IdTipoTercero);
            return View(tercero);
        }

        // GET: Terceroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Terceros == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .Include(t => t.IdTipoTerceroNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // POST: Terceroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Terceros == null)
            {
                return Problem("Entity set 'ComercializadoraContext.Terceros'  is null.");
            }
            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero != null)
            {
                _context.Terceros.Remove(tercero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerceroExists(int id)
        {
          return (_context.Terceros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
