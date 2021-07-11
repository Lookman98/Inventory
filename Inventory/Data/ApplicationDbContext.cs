using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Models.Barang;
using Inventory.Models.Daerah;
using Inventory.Models.Stesen;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}
        public DbSet<Barang> Barang { get; set; } 
        public DbSet<Stesen> Stesen { get; set; }
        public DbSet<Daerah> Daerah { get; set; }
    }
}
