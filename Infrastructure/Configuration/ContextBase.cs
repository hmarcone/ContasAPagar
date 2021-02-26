using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Configuration
{
    public class ContextBase: DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<Conta> Conta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        private string GetStringConectionConfig()
        {
            var strConexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ContasApagar;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            return strConexao;
        }
    }
}
