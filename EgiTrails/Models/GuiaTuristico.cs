using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class GuiaTuristico
    {
        public int GuiaTuristicoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int Telefone { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
