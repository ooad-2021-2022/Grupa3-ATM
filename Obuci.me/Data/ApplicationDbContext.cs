using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obuci.me.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Artikl> Artikl { get; set; }
        public DbSet<Korpa> Korpa { get; set; }
        public DbSet<Dostava> Dostava { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<KorisnikRacuni> KorisnikRacuni { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikl>().ToTable("Artikl");
            modelBuilder.Entity<Korpa>().ToTable("Korpa");
            modelBuilder.Entity<Dostava>().ToTable("Dostava");
            modelBuilder.Entity<Racun>().ToTable("Racun");
            modelBuilder.Entity<Narudzba>().ToTable("Narudzba");
            modelBuilder.Entity<KorisnikRacuni>().ToTable("KorisnikRacunu");
            base.OnModelCreating(modelBuilder);
        }

    }
}
