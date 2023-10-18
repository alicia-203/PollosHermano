using System;
using System.Collections.Generic;

#nullable disable

namespace PollosHermano.Models
{
    public partial class ClientePlantilla
    {
        public int ClientePlantillaId { get; set; }
        public int ClienteId { get; set; }
        public int PlantillaId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Plantilla Plantilla { get; set; }
    }
}
