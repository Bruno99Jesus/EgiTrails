using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Turista
    {
        public int turistaId { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telemovel")]
        public int Telemovel { get; set; }

        [Required]
        [Display(Name = "Nfi")]
        public int Nfi { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
