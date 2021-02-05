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
        [MinLength(9, ErrorMessage = "O número de telefone deve ter 9 digitos")]
        [MaxLength(9)]
        [Display(Name = "NIF")]
        public int NIF { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

       // public int ReservasID { get; set; }

        //public virtual ICollection<Reservas> Reservas { get; set; }
    }
}