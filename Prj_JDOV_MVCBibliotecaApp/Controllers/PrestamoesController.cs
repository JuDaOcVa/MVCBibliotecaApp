using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prj_JDOV_MVCBibliotecaApp.Models;

namespace Prj_JDOV_MVCBibliotecaApp.Controllers
{
    public class PrestamoesController : Controller
    {
        private readonly BdJdovLaboratorio2Context _context;

        public PrestamoesController(BdJdovLaboratorio2Context context)
        {
            _context = context;
        }

        // GET: Prestamoes
        public async Task<IActionResult> Index()
        {
            var bdJdovLaboratorio2Context = _context.Prestamos.Include(p => p.IdusuarioNavigation).Include(p => p.IsbnNavigation);
            return View(await bdJdovLaboratorio2Context.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.IdusuarioNavigation)
                .Include(p => p.IsbnNavigation)
                .FirstOrDefaultAsync(m => m.Idprestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public IActionResult Create()
        {
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario");
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn");
            return View();
        }

        // POST: Prestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idprestamo,Isbn,Idusuario,FechaPrestamo,FechaDevolucion")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario", prestamo.Idusuario);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", prestamo.Isbn);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario", prestamo.Idusuario);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", prestamo.Isbn);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idprestamo,Isbn,Idusuario,FechaPrestamo,FechaDevolucion")] Prestamo prestamo)
        {
            if (id != prestamo.Idprestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.Idprestamo))
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
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Idusuario", "Idusuario", prestamo.Idusuario);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", prestamo.Isbn);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prestamos == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.IdusuarioNavigation)
                .Include(p => p.IsbnNavigation)
                .FirstOrDefaultAsync(m => m.Idprestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prestamos == null)
            {
                return Problem("Entity set 'BdJdovLaboratorio2Context.Prestamos'  is null.");
            }
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
          return (_context.Prestamos?.Any(e => e.Idprestamo == id)).GetValueOrDefault();
        }
    }
}
