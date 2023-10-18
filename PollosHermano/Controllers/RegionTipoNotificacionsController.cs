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
    public class RegionTipoNotificacionsController : Controller
    {
        private readonly PollosHermanoContext _context;

        public RegionTipoNotificacionsController(PollosHermanoContext context)
        {
            _context = context;
        }

        // GET: RegionTipoNotificacions
        public async Task<IActionResult> Index()
        {
            var pollosHermanoContext = _context.RegionTipoNotificacions.Include(r => r.Region).Include(r => r.TipoNotificacion);
            return View(await pollosHermanoContext.ToListAsync());
        }

        // GET: RegionTipoNotificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionTipoNotificacion = await _context.RegionTipoNotificacions
                .Include(r => r.Region)
                .Include(r => r.TipoNotificacion)
                .FirstOrDefaultAsync(m => m.RegionTipoNotificacionId == id);
            if (regionTipoNotificacion == null)
            {
                return NotFound();
            }

            return View(regionTipoNotificacion);
        }

        // GET: RegionTipoNotificacions/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Nombre");
            ViewData["TipoNotificacionId"] = new SelectList(_context.TipoNotificacions, "TipoNotificacionId", "Nombre");
            return View();
        }

        // POST: RegionTipoNotificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionTipoNotificacionId,RegionId,TipoNotificacionId")] RegionTipoNotificacion regionTipoNotificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regionTipoNotificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Nombre", regionTipoNotificacion.RegionId);
            ViewData["TipoNotificacionId"] = new SelectList(_context.TipoNotificacions, "TipoNotificacionId", "Nombre", regionTipoNotificacion.TipoNotificacionId);
            return View(regionTipoNotificacion);
        }

        // GET: RegionTipoNotificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionTipoNotificacion = await _context.RegionTipoNotificacions.FindAsync(id);
            if (regionTipoNotificacion == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Nombre", regionTipoNotificacion.RegionId);
            ViewData["TipoNotificacionId"] = new SelectList(_context.TipoNotificacions, "TipoNotificacionId", "Nombre", regionTipoNotificacion.TipoNotificacionId);
            return View(regionTipoNotificacion);
        }

        // POST: RegionTipoNotificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegionTipoNotificacionId,RegionId,TipoNotificacionId")] RegionTipoNotificacion regionTipoNotificacion)
        {
            if (id != regionTipoNotificacion.RegionTipoNotificacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regionTipoNotificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionTipoNotificacionExists(regionTipoNotificacion.RegionTipoNotificacionId))
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
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Nombre", regionTipoNotificacion.RegionId);
            ViewData["TipoNotificacionId"] = new SelectList(_context.TipoNotificacions, "TipoNotificacionId", "Nombre", regionTipoNotificacion.TipoNotificacionId);
            return View(regionTipoNotificacion);
        }

        // GET: RegionTipoNotificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionTipoNotificacion = await _context.RegionTipoNotificacions
                .Include(r => r.Region)
                .Include(r => r.TipoNotificacion)
                .FirstOrDefaultAsync(m => m.RegionTipoNotificacionId == id);
            if (regionTipoNotificacion == null)
            {
                return NotFound();
            }

            return View(regionTipoNotificacion);
        }

        // POST: RegionTipoNotificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regionTipoNotificacion = await _context.RegionTipoNotificacions.FindAsync(id);
            _context.RegionTipoNotificacions.Remove(regionTipoNotificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionTipoNotificacionExists(int id)
        {
            return _context.RegionTipoNotificacions.Any(e => e.RegionTipoNotificacionId == id);
        }
    }
}
