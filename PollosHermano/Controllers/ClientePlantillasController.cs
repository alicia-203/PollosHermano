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
    public class ClientePlantillasController : Controller
    {
        private readonly PollosHermanoContext _context;

        public ClientePlantillasController(PollosHermanoContext context)
        {
            _context = context;
        }

        // GET: ClientePlantillas
        public async Task<IActionResult> Index()
        {
            var pollosHermanoContext = _context.ClientePlantillas.Include(c => c.Cliente).Include(c => c.Plantilla);
            return View(await pollosHermanoContext.ToListAsync());
        }

        // GET: ClientePlantillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientePlantilla = await _context.ClientePlantillas
                .Include(c => c.Cliente)
                .Include(c => c.Plantilla)
                .FirstOrDefaultAsync(m => m.ClientePlantillaId == id);
            if (clientePlantilla == null)
            {
                return NotFound();
            }

            return View(clientePlantilla);
        }

        // GET: ClientePlantillas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            ViewData["PlantillaId"] = new SelectList(_context.Plantillas, "PlantillaId", "Nombre");
            return View();
        }

        // POST: ClientePlantillas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientePlantillaId,ClienteId,PlantillaId")] ClientePlantilla clientePlantilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientePlantilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", clientePlantilla.ClienteId);
            ViewData["PlantillaId"] = new SelectList(_context.Plantillas, "PlantillaId", "Nombre", clientePlantilla.PlantillaId);
            return View(clientePlantilla);
        }

        // GET: ClientePlantillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientePlantilla = await _context.ClientePlantillas.FindAsync(id);
            if (clientePlantilla == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", clientePlantilla.ClienteId);
            ViewData["PlantillaId"] = new SelectList(_context.Plantillas, "PlantillaId", "Nombre", clientePlantilla.PlantillaId);
            return View(clientePlantilla);
        }

        // POST: ClientePlantillas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientePlantillaId,ClienteId,PlantillaId")] ClientePlantilla clientePlantilla)
        {
            if (id != clientePlantilla.ClientePlantillaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientePlantilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientePlantillaExists(clientePlantilla.ClientePlantillaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", clientePlantilla.ClienteId);
            ViewData["PlantillaId"] = new SelectList(_context.Plantillas, "PlantillaId", "Nombre", clientePlantilla.PlantillaId);
            return View(clientePlantilla);
        }

        // GET: ClientePlantillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientePlantilla = await _context.ClientePlantillas
                .Include(c => c.Cliente)
                .Include(c => c.Plantilla)
                .FirstOrDefaultAsync(m => m.ClientePlantillaId == id);
            if (clientePlantilla == null)
            {
                return NotFound();
            }

            return View(clientePlantilla);
        }

        // POST: ClientePlantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientePlantilla = await _context.ClientePlantillas.FindAsync(id);
            _context.ClientePlantillas.Remove(clientePlantilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientePlantillaExists(int id)
        {
            return _context.ClientePlantillas.Any(e => e.ClientePlantillaId == id);
        }
    }
}
