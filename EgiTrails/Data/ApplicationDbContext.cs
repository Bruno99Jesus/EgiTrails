using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EgiTrails.Models;

namespace EgiTrails.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EgiTrails.Models.Trilhos> Trilhos { get; set; }
        public DbSet<EgiTrails.Models.Veiculos> Veiculos { get; set; }
        public DbSet<EgiTrails.Models.Reservas> Reservas { get; set; }
    }
}
