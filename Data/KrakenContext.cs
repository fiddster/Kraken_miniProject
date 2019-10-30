using Kraken_WeaponSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Kraken_WeaponSystem.Data
{
    class KrakenContext : DbContext
    {

        public DbSet<Target> Target { get; set; }
        //private ILoggerFactory Logger { get; }

        public KrakenContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLoggerFactory(Logger);

            optionsBuilder.UseSqlServer("Server=.;Database=Projekt_Kraken;Trusted_Connection=true");
        }
    }

}

