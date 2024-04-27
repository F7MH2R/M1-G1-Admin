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
    public class PromocionesController : Controller
    {
        private readonly RestaurantContext _context;

        public PromocionesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Promociones
        public async Task<IActionResult> Index()
        {
            return View(await _context.promociones.ToListAsync());
        }


        /// Add
         public async Task<IActionResult> Add(int id)
        {
            var promociones = await _context.promociones.FindAsync(id);

            if (promociones == null)
            {
                return NotFound();
            }

            var platos = await _context.platos.ToListAsync();

            var mostrarPlatoModel = new MostrarPlato
            {
                promocion_id = promociones.promocion_id,
                listadeplatos = platos
            };

            return View(mostrarPlatoModel);
         }

        //
        [HttpPost, ActionName("Agregar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar(int platoId, int promoId)
        {
            try
            {
                PromocionesPlatos promocionesPlatos = new PromocionesPlatos();
                promocionesPlatos.plato_id = platoId; 
                promocionesPlatos.promocion_id = promoId;
                _context.promociones_platos.Add(promocionesPlatos);
                await _context.SaveChangesAsync();

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(Add), new {id = promoId});
        }
        // GET: Promociones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promociones = await _context.promociones
                .FirstOrDefaultAsync(m => m.promocion_id == id);
            if (promociones == null)
            {
                return NotFound();
            }

            return View(promociones);
        }

        // GET: Promociones/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Promociones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("promocion_id,nombre,descripcion,descuento,fecha_inicio,fecha_fin")] Promociones promociones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promociones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promociones);
        }

        // GET: Promociones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promociones = await _context.promociones.FindAsync(id);
            if (promociones == null)
            {
                return NotFound();
            }
            return View(promociones);
        }

        // POST: Promociones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("promocion_id,nombre,descripcion,descuento,fecha_inicio,fecha_fin")] Promociones promociones)
        {
            if (id != promociones.promocion_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promociones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocionesExists(promociones.promocion_id))
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
            return View(promociones);
        }

        // GET: Promociones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promociones = await _context.promociones
                .FirstOrDefaultAsync(m => m.promocion_id == id);
            if (promociones == null)
            {
                return NotFound();
            }

            return View(promociones);
        }

        // POST: Promociones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promociones = await _context.promociones.FindAsync(id);
            if (promociones != null)
            {
                _context.promociones.Remove(promociones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocionesExists(int id)
        {
            return _context.promociones.Any(e => e.promocion_id == id);
        }

    }
}
