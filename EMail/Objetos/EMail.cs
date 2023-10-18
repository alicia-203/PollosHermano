using System;
using System.Collections.Generic;
using System.Text;

namespace Objetos
{
  public class EMail
  {
    #region Constructor
    public EMail()
    {

    }
    #endregion Constructor

    #region Propiedades
    public int EMailID { get; set; }
    public string Body { get; set; }
    public string Subject { get; set; }
    public int Priority { get; set; }
    public string Destinatario { get; set; }
    #endregion Propiedades
  }
}
