using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Registarturista
    {
        [Required]
        [StringLength(128)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Phone]
        [MinLength(9, ErrorMessage = "O número de telefone deve ter 9 digitos")]
        [MaxLength(9)]
        [Display(Name = "Telemóvel")]
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

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
