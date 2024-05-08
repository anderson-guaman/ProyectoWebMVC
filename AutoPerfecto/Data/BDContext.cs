using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoPerfecto.Models;

namespace AutoPerfecto.Data
{
    public class BDContext : DbContext
    {
        public BDContext (DbContextOptions<BDContext> options)
            : base(options)
        {
        }

        public DbSet<AutoPerfecto.Models.Compra> Compra { get; set; } = default!;
        public DbSet<AutoPerfecto.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<AutoPerfecto.Models.Auto> Auto { get; set; } = default!;
    }
}
