using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Veiculos
    {
        public int VeiculosId { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "O número de lugares deve ser entre 1 e 12")]
        public string NumLugares { get; set; }
        public string TipoVeiculo { get; set; }
        public string Desativo { get; set; }
        public byte[] Photo { get; set; }

      //  public int ReservasID { get; set; }

      //public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
