using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.IO;
using System.Linq;

using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Trilhos
    {
        public int TrilhosId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string TipoTrilho { get; set; }

        public string Description { get; set; }

        public string Trajeto { get; set; }

        public float Distancia { get; set; }

        public string LocIni { get; set; }

        public string LocInter { get; set; }

        public string LocFim { get; set; }

        public int LimMaxPes { get; set; }

        public byte[] Photo { get; set; }

       

    }
}
