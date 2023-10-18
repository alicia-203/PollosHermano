using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EMail.Controllers
{
  public class EMailController : Controller
  {
    #region Miembros
    private Negocio.EMail mEMail;
    #endregion Miembros

    #region Constructor
    public EMailController()
    {
      this.mEMail = new Negocio.EMail();
    }
    #endregion Constructor

    #region Metodos
    [Route("Enviar")]
    [HttpPost]
    public IActionResult Enviar(Objetos.EMail pEMail , Objetos.Attachment pAttachment, Objetos.SmtpClient pSmtpClient)
    {
      try
      {
        return Ok(this.mEMail.Enviar(pEMail, pAttachment, pSmtpClient));
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }
    #endregion Metodos
  }
}

