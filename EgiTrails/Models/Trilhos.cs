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
        [StringLength(256)]
        public string Nome { get; set; }
        [Required]
        public string TipoTrilho { get; set; }

        public string Description { get; set; }

        public byte[] Trajeto { get; set; }
        [Required]
        [Range(1, 99999, ErrorMessage = "A distância máxima é de 99999km")]
        public float Distancia { get; set; }
        [Required]
        [StringLength(256)]
        public string LocIni { get; set; }
        [StringLength(256)]
        public string LocInter { get; set; }
        [Required]
        [StringLength(256)]
        public string LocFim { get; set; }
       
        [Range(1, 15, ErrorMessage = "O número de pessoas deve ser entre 1 e 15")]
        public int LimMaxPes { get; set; }

        public byte[] Photo { get; set; }

       public bool EstadoTrilho { get; set; }

       // public int ReservasID { get; set; }

       // public virtual ICollection<Reservas> Reservas { get; set; }

    }
}
