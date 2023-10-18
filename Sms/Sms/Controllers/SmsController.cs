using Microsoft.AspNetCore.Mvc;
using System;


namespace Sms.Controllers
{
  public class SmsController : Controller
  {
    #region Miembros
    private Negocio.Sms mSms;
    #endregion Miembros

    #region Constructor
    public SmsController()
    {
      this.mSms = new Negocio.Sms();
    }
    #endregion Constructor
    #region Metodos
    [Route("Enviar")]
    [HttpPost]
    public IActionResult Enviar(Objetos.Sms pSms, Objetos.TwilioAccount pTwilioAccount)
    {
      try
      {
        return Ok(this.mSms.Enviar(pSms, pTwilioAccount));
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }
    #endregion Metodos
  }
}
