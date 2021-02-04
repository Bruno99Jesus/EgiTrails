using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Reservas
    {
        public int ReservasId { get; set; }

        
        [Required(ErrorMessage = "Insira o Nome")]
        [StringLength(256)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o Telemóvel")]
        public int Telemovel { get; set; }
        [Required(ErrorMessage = "Insira o E-mail")]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira a Data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Indique o nº de Pessoas")]
        public int NPessoas { get; set; }

        [Required]
        public string TipoVeiculo { get; set; }
        public string Estado { get; set; }
        public DateTime? DataEstado { get; set; }

      //  public int VeiculosID { get; set; }
      //  public int TrilhosID { get; set; }

       // public virtual ICollection<Veiculos> Veiculos { get; set; }
       // public virtual Trilhos Trilhos { get; set; }



    }
}
