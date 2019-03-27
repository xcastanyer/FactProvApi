using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactXCO.Models
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {

        public Contexto(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<ProveedorModel> Proveedores { get; set; }
        public DbSet<FacturaProveedor> FacturasProveedor { get; set; }        
        public DbSet<IvaFactura> IvasFactura { get; set; }
        public DbSet<VencimientoFactura> VencimientosFacturas { get; set; }
    }
}
