using System;
using System.Collections.Generic;

#nullable disable

namespace PollosHermano.Models
{
    public partial class RegionTipoNotificacion
    {
        public int RegionTipoNotificacionId { get; set; }
        public int RegionId { get; set; }
        public int TipoNotificacionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual TipoNotificacion TipoNotificacion { get; set; }
    }
}
