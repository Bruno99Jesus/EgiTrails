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
        public string Nome { get; set; }
        [Required(ErrorMessage = "Tem de por a data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "diga quantas pessoas sao")]
        public int NPessoas { get; set; }
        [Required(ErrorMessage = "o numero de telemovel")]
        public int Telemovel { get; set; }
        [Required]
        public string Descricao { get; set; }

    }
}
