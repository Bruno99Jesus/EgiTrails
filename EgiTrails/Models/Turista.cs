using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Turista
    {

        public int TuristaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int NIF { get; set; }

    }
}
