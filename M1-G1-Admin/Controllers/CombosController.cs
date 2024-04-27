using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using M1_G1_Admin.Models;
using M1_G1_Admin.Pages;

namespace M1_G1_Admin.Controllers
{
    public class CombosController : Controller
    {
        private readonly RestaurantContext _context;

        public CombosController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Combos
        public async Task<IActionResult> Index()
        {
            return View(await _context.combos.ToListAsync());
        }

        // GET: Combos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combos = await _context.combos
                .FirstOrDefaultAsync(m => m.combo_id == id);
            if (combos == null)
            {
                return NotFound();
            }

            return View(combos);
        }

        // GET: Combos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Combos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("combo_id,nombre,descripcion,precio,disponible")] Combos combos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(combos);
        }

        // GET: Combos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combos = await _context.combos.FindAsync(id);
            if (combos == null)
            {
                return NotFound();
            }
            return View(combos);
        }

        // POST: Combos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("combo_id,nombre,descripcion,precio,disponible")] Combos combos)
        {
            if (id != combos.combo_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombosExists(combos.combo_id))
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
            return View(combos);
        }

        // GET: Combos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combos = await _context.combos
                .FirstOrDefaultAsync(m => m.combo_id == id);
            if (combos == null)
            {
                return NotFound();
            }

            return View(combos);
        }

        // POST: Combos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var combos = await _context.combos.FindAsync(id);
            if (combos != null)
            {
                _context.combos.Remove(combos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Combos/Add
        public async Task<IActionResult> Add(int id)
        {
            var combo = await _context.combos.FindAsync(id);
            
            if (combo == null)
                return NotFound();
            var platosCombo = await _context.combos_platos
                .Where(combo => combo.combo_id == id)
                .Select(combo => combo.plato_id)
                .ToListAsync();
 
            AgregarPlatos agregarPlatos = new AgregarPlatos();
            agregarPlatos.combo = combo;
            
            agregarPlatos.platos = await _context
                .platos
                .Where(pt => !platosCombo.Contains(pt.plato_id))
                .ToListAsync();

            agregarPlatos.platosXCombo = await _context
                .platos
                .Where(p => platosCombo.Contains(p.plato_id))
                .ToListAsync();
            
            return View(agregarPlatos);
        }

        [HttpPost, ActionName("AddPlato")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPlato(int plato, int idCombo)
        {
            
            try
            {
                CombosPlatos combPlato = new CombosPlatos();
                combPlato.combo_id = idCombo;
                combPlato.plato_id = plato;

                _context.combos_platos.Add(combPlato);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return RedirectToAction(nameof(Add), new { id = idCombo });
        }

        private bool CombosExists(int id)
        {
            return _context.combos.Any(e => e.combo_id == id);
        }
    }
}
