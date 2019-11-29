using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System.Data.Entity;

namespace CiccioGest.Infrastructure.Persistence.EF
{
    class ModelContext : DbContext
    {
        public ModelContext()
            : base("")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey()
                .HasColumnOrder(1));

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Categoria> CategoriaSet { get; set; }
        public virtual DbSet<Articolo> ArticoloSet { get; set; }
        public virtual DbSet<Dettaglio> DettaglioSet { get; set; }
        public virtual DbSet<Fattura> FatturaSet { get; set; }
    }
}
