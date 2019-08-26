using ATINV.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace ATINV.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Fund> Funds { get; set; }
        public DbSet<Moviment> Moviments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovimentConfiguration());
            modelBuilder.ApplyConfiguration(new FundConfiguration());

            modelBuilder.Entity<Fund>().HasData(new Fund { Id = Guid.NewGuid(), Cnpj = "78092564000199", MinInicialContribution = 1000, Name = "Fundo ABC" });
            modelBuilder.Entity<Fund>().HasData(new Fund { Id = Guid.NewGuid(), Cnpj = "37165877000142", MinInicialContribution = 5000, Name = "Fundo XYZ" });
            modelBuilder.Entity<Fund>().HasData(new Fund { Id = Guid.NewGuid(), Cnpj = "10289932000150", MinInicialContribution = 100000, Name = "Fundo XPTO" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
