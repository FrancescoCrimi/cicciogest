using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.EF
{
    class ModelContext : DbContext
    {
        public ModelContext()
            : base("")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Categoria> CategoriaSet { get; set; }
        public virtual DbSet<Prodotto> ProdottoSet { get; set; }
        public virtual DbSet<Dettaglio> DettaglioSet { get; set; }
        public virtual DbSet<Fattura> FatturaSet { get; set; }
    }
}
