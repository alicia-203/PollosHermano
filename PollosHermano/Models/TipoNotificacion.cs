using System;
using System.Collections.Generic;

#nullable disable

namespace PollosHermano.Models
{
    public partial class TipoNotificacion
    {
        public TipoNotificacion()
        {
            RegionTipoNotificacions = new HashSet<RegionTipoNotificacion>();
        }

        public int TipoNotificacionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RegionTipoNotificacion> RegionTipoNotificacions { get; set; }
    }
}
