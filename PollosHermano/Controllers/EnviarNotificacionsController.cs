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
  public class EnviarNotificacionsController : Controller
  {
    private readonly PollosHermanoContext _context;

    public EnviarNotificacionsController(PollosHermanoContext context)
    {
      _context = context;
    }

    public IActionResult Enviar()
    {
      ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre");
      ViewData["PlantillaId"] = new SelectList(_context.Plantillas, "PlantillaId", "Nombre");

      return View();
    }
   

  }
}
