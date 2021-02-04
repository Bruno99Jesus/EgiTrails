using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class editlogin
    {
        [Required]
        [StringLength(128)]
        public string Nome { get; set; }

        [Required]
        public int Telemovel { get; set; }

        [Required]
        public int NIF { get; set; }

        public string Email { get; set; }
    }
}
