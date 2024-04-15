using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M1_G1_Admin.Models;

namespace M1_G1_Admin.Controllers
{
    public class Categoria_PlatosController : Controller
    {
        private readonly RestaurantContext _context;

        public Categoria_PlatosController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Categoria_Platos
        public async Task<IActionResult> Index()
        {
            return View(await _context.categorias_platos.ToListAsync());
        }

        // GET: Categoria_Platos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Platos = await _context.categorias_platos
                .FirstOrDefaultAsync(m => m.categoria_id == id);
            if (categoria_Platos == null)
            {
                return NotFound();
            }

            return View(categoria_Platos);
        }

        // GET: Categoria_Platos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria_Platos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("categoria_id,nombre")] Categoria_Platos categoria_Platos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria_Platos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria_Platos);
        }

        // GET: Categoria_Platos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Platos = await _context.categorias_platos.FindAsync(id);
            if (categoria_Platos == null)
            {
                return NotFound();
            }
            return View(categoria_Platos);
        }

        // POST: Categoria_Platos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("categoria_id,nombre")] Categoria_Platos categoria_Platos)
        {
            if (id != categoria_Platos.categoria_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria_Platos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Categoria_PlatosExists(categoria_Platos.categoria_id))
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
            return View(categoria_Platos);
        }

        // GET: Categoria_Platos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria_Platos = await _context.categorias_platos
                .FirstOrDefaultAsync(m => m.categoria_id == id);
            if (categoria_Platos == null)
            {
                return NotFound();
            }

            return View(categoria_Platos);
        }

        // POST: Categoria_Platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria_Platos = await _context.categorias_platos.FindAsync(id);
            if (categoria_Platos != null)
            {
                _context.categorias_platos.Remove(categoria_Platos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categoria_PlatosExists(int id)
        {
            return _context.categorias_platos.Any(e => e.categoria_id == id);
        }
    }
}
