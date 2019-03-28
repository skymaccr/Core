using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public SamuraiContext(DbContextOptions<SamuraiContext> options)
            : base(options)
        {

        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattle> SamuraiBattles { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiAppData;Integrated Security = True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //esto es para decirle que la tabla intermedia tiene los keys de las otras 2 tables.
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });
        }
    }
}
