using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Reservas
    {
        public int ReservasId { get; set; }
        [Required(ErrorMessage = "E obrigatorio por o Nome")]
        [StringLength(256)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Tem de por o Telemovel")]
        public int Telemovel { get; set; }
        [Required(ErrorMessage = "Tem de por o E-mail")]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tem de por a data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "diga quantas pessoas sao")]
        public int NPessoas { get; set; }

        [Required]
        public string TipoVeiculo { get; set; }
        public string Estado { get; set; }
        public DateTime? DataEstado { get; set; }
    }
}
