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
    public class TipoNotificacionsController : Controller
    {
        private readonly PollosHermanoContext _context;

        public TipoNotificacionsController(PollosHermanoContext context)
        {
            _context = context;
        }

        // GET: TipoNotificacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoNotificacions.ToListAsync());
        }

        // GET: TipoNotificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoNotificacion = await _context.TipoNotificacions
                .FirstOrDefaultAsync(m => m.TipoNotificacionId == id);
            if (tipoNotificacion == null)
            {
                return NotFound();
            }

            return View(tipoNotificacion);
        }

        // GET: TipoNotificacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoNotificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoNotificacionId,Nombre")] TipoNotificacion tipoNotificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoNotificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoNotificacion);
        }

        // GET: TipoNotificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoNotificacion = await _context.TipoNotificacions.FindAsync(id);
            if (tipoNotificacion == null)
            {
                return NotFound();
            }
            return View(tipoNotificacion);
        }

        // POST: TipoNotificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoNotificacionId,Nombre")] TipoNotificacion tipoNotificacion)
        {
            if (id != tipoNotificacion.TipoNotificacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoNotificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoNotificacionExists(tipoNotificacion.TipoNotificacionId))
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
            return View(tipoNotificacion);
        }

        // GET: TipoNotificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoNotificacion = await _context.TipoNotificacions
                .FirstOrDefaultAsync(m => m.TipoNotificacionId == id);
            if (tipoNotificacion == null)
            {
                return NotFound();
            }

            return View(tipoNotificacion);
        }

        // POST: TipoNotificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoNotificacion = await _context.TipoNotificacions.FindAsync(id);
            _context.TipoNotificacions.Remove(tipoNotificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoNotificacionExists(int id)
        {
            return _context.TipoNotificacions.Any(e => e.TipoNotificacionId == id);
        }
    }
}
