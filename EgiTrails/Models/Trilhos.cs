using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Trilhos
    {
        public int TrilhosId { get; set; }

        public string Nome { get; set; }

        public string TipoTrilho { get; set; }

        public string Description { get; set; }

        public string Trajeto { get; set; }

    }
}
