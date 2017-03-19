using CiccioGest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EFC
{
    class ModelContext : DbContext
    {
        public virtual DbSet<Fattura> FatturaSet { get; set; }
        public virtual DbSet<Prodotto> ProdottoSet { get; set; }
        public virtual DbSet<Categoria> CategoriaSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CiccioEFC.mdf; Integrated Security=True";
            optionsBuilder.UseSqlServer(cs);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fattura>()
                .ToTable("Fatture")
                .HasKey(f => f.Id);
            modelBuilder.Entity<Fattura>()
                .HasMany(f => f.Dettagli);

            modelBuilder.Entity<Dettaglio>()
                .ToTable("Dettagli")
                .HasKey(f => f.Id);

            modelBuilder.Entity<Prodotto>()
                .ToTable("Prodotti")
                .HasKey(f => f.Id);

            modelBuilder.Entity<Categoria>()
                .ToTable("Categorie")
                .HasKey(f => f.Id);
        }
    }
}
