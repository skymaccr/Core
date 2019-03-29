using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
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
        //Esto hace un log de los queries, como un profiler
        [Obsolete]
        public static readonly LoggerFactory MyConsoleLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((Category, level) =>
                Category == DbLoggerCategory.Database.Command.Name &&
                level == LogLevel.Information, true)
            });

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        [Obsolete]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiAppDataEFCore;Integrated Security = True;");
        }
    }
}
