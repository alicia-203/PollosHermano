using System;
using System.Collections.Generic;
using System.Text;

namespace Objetos
{
 public class SmtpClient
  {
    #region Miembros
    #endregion
    #region Constructores
    public SmtpClient()
    {

    }
    #endregion

    #region Propiedades
    public string Host { get; set; }
    public int Port { get; set; }
    public string Remitente { get; set; }
    public string Contraseña { get; set; }
    public bool EnableSsl { get; set; }
    #endregion
  }
}
