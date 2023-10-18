using System;
using System.Collections.Generic;

#nullable disable

namespace PollosHermano.Models
{
    public partial class Region
    {
        public Region()
        {
            RegionTipoNotificacions = new HashSet<RegionTipoNotificacion>();
        }

        public int RegionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RegionTipoNotificacion> RegionTipoNotificacions { get; set; }
    }
}
