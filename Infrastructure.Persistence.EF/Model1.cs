namespace Ciccio1.Infrastructure.Persistence.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Dettaglio> Dettaglio { get; set; }
        public virtual DbSet<Fattura> Fattura { get; set; }
        public virtual DbSet<Prodotto> Prodotto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Prodotto)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.Categoria_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fattura>()
                .HasMany(e => e.Dettaglio)
                .WithRequired(e => e.Fattura)
                .HasForeignKey(e => e.Fattura_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotto>()
                .HasMany(e => e.Dettaglio)
                .WithRequired(e => e.Prodotto)
                .HasForeignKey(e => e.Prodotto_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
