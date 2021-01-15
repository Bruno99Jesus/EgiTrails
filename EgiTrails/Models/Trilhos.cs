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

        public string Distancia { get; set; }

        public string LocIni { get; set; }

        public string LocInter { get; set; }

        public string LocFim { get; set; }

        public string LimMaxPes { get; set; }

    }
}
