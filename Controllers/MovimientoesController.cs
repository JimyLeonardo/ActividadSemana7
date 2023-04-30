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
    public class MovimientoesController : Controller
    {
        private readonly ComercializadoraContext _context;

        public MovimientoesController(ComercializadoraContext context)
        {
            _context = context;
        }

        // GET: Movimientoes
        public async Task<IActionResult> Index()
        {
            var comercializadoraContext = _context.Movimientos.Include(m => m.IdProductoNavigation).Include(m => m.IdTerceroNavigation).Include(m => m.IdTipoMovimientoNavigation).Include(m => m.IdUsuarioNavigation);
            return View(await comercializadoraContext.ToListAsync());
        }

        // GET: Movimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos
                .Include(m => m.IdProductoNavigation)
                .Include(m => m.IdTerceroNavigation)
                .Include(m => m.IdTipoMovimientoNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // GET: Movimientoes/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre");
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "Id", "Nombre");
            ViewData["IdTipoMovimiento"] = new SelectList(_context.TipoMovimientos, "Id", "Nombre");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: Movimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTercero,IdUsuario,IdProducto,Estado,IdTipoMovimiento,Valor,Fecha")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre", movimiento.IdProducto);
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "Id", "Nombre", movimiento.IdTercero);
            ViewData["IdTipoMovimiento"] = new SelectList(_context.TipoMovimientos, "Id", "Nombre", movimiento.IdTipoMovimiento);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre", movimiento.IdUsuario);
            return View(movimiento);
        }

        // GET: Movimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre", movimiento.IdProducto);
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "Id", "Nombre", movimiento.IdTercero);
            ViewData["IdTipoMovimiento"] = new SelectList(_context.TipoMovimientos, "Id", "Nombre", movimiento.IdTipoMovimiento);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre", movimiento.IdUsuario);
            return View(movimiento);
        }

        // POST: Movimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTercero,IdUsuario,IdProducto,Estado,IdTipoMovimiento,Valor,Fecha")] Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoExists(movimiento.Id))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Nombre", movimiento.IdProducto);
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "Id", "Nombre", movimiento.IdTercero);
            ViewData["IdTipoMovimiento"] = new SelectList(_context.TipoMovimientos, "Id", "Nombre", movimiento.IdTipoMovimiento);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nombre", movimiento.IdUsuario);
            return View(movimiento);
        }

        // GET: Movimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos
                .Include(m => m.IdProductoNavigation)
                .Include(m => m.IdTerceroNavigation)
                .Include(m => m.IdTipoMovimientoNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // POST: Movimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movimientos == null)
            {
                return Problem("Entity set 'ComercializadoraContext.Movimientos'  is null.");
            }
            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento != null)
            {
                _context.Movimientos.Remove(movimiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoExists(int id)
        {
          return (_context.Movimientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
