using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class FacturadorContext : DbContext
    {
        public FacturadorContext()
        { 
        
        }

        public FacturadorContext(DbContextOptions<FacturadorContext> options) : base(options)
        { 
        
        }
        
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Detalle> Detalle { get; set; }
    }
}
