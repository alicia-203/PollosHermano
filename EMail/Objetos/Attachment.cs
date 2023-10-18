using System;
using System.Collections.Generic;
using System.Text;

namespace Objetos
{
  public class Attachment
  {
    #region Miembros
    #endregion
    #region Constructores
    public Attachment()
    {

    }
    #endregion

    #region Propiedades
    public int AttachmentID { get; set; }
    public int EMailID { get; set; }
    public string Nombre { get; set; }
    public byte[] ArchivoBytes { get; set; }

    #endregion
  }
}
