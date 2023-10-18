using System;
using System.Collections.Generic;

#nullable disable

namespace PollosHermano.Models
{
  public partial class EnviarNotificacion
  {
    public int ClienteId { get; set; }
    public int PlantillaId { get; set; }
    public string Body { get; set; }

    public virtual Cliente Cliente { get; set; }
    public virtual Plantilla Plantilla { get; set; }
  }
}
