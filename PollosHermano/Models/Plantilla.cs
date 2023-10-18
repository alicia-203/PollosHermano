using System;
using System.Collections.Generic;

#nullable disable

namespace PollosHermano.Models
{
    public partial class Plantilla
    {
        public Plantilla()
        {
            ClientePlantillas = new HashSet<ClientePlantilla>();
        }

        public int PlantillaId { get; set; }
        public string Nombre { get; set; }
        public string Body { get; set; }

        public virtual ICollection<ClientePlantilla> ClientePlantillas { get; set; }
    }
}
