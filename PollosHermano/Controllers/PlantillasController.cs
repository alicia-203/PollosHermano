using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PollosHermano.Models;

namespace PollosHermano.Controllers
{
    public class PlantillasController : Controller
    {
        private readonly PollosHermanoContext _context;

        public PlantillasController(PollosHermanoContext context)
        {
            _context = context;
        }

        // GET: Plantillas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plantillas.ToListAsync());
        }

        // GET: Plantillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantilla = await _context.Plantillas
                .FirstOrDefaultAsync(m => m.PlantillaId == id);
            if (plantilla == null)
            {
                return NotFound();
            }

            return View(plantilla);
        }

        // GET: Plantillas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plantillas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantillaId,Nombre,Body")] Plantilla plantilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantilla);
        }

        // GET: Plantillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantilla = await _context.Plantillas.FindAsync(id);
            if (plantilla == null)
            {
                return NotFound();
            }
            return View(plantilla);
        }

        // POST: Plantillas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantillaId,Nombre,Body")] Plantilla plantilla)
        {
            if (id != plantilla.PlantillaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantillaExists(plantilla.PlantillaId))
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
            return View(plantilla);
        }

        // GET: Plantillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantilla = await _context.Plantillas
                .FirstOrDefaultAsync(m => m.PlantillaId == id);
            if (plantilla == null)
            {
                return NotFound();
            }

            return View(plantilla);
        }

        // POST: Plantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantilla = await _context.Plantillas.FindAsync(id);
            _context.Plantillas.Remove(plantilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantillaExists(int id)
        {
            return _context.Plantillas.Any(e => e.PlantillaId == id);
        }
    }
}
