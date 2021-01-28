using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EgiTrails.Models
{
    public class Veiculos
    {
        public int VeiculosId { get; set; }
        public string Modelo { get; set; }
        public string NumLugares { get; set; }
        public string Desativo { get; set; }
        public byte[] Photo { get; set; }


    }
}
