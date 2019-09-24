using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connection = "Server = (localdb)\\mssqllocaldb; Database = SamuraiAppData; Trusted_Connection = True; ";
            options.UseSqlServer(connection);
        }
    }
}
