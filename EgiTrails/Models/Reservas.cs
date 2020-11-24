using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Reservas
    {
        public int ReservasId { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public int NPessoas { get; set; }

        public string Descricao { get; set; }

    }
}
