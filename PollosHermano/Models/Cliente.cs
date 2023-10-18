using System;
using System.Collections.Generic;

#nullable disable

namespace PollosHermano.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClientePlantillas = new HashSet<ClientePlantilla>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ClientePlantilla> ClientePlantillas { get; set; }
    }
}
