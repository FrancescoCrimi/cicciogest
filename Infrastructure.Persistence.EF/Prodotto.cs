namespace Ciccio1.Infrastructure.Persistence.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotto")]
    public partial class Prodotto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotto()
        {
            Dettaglio = new HashSet<Dettaglio>();
        }

        public int Id { get; set; }

        public Guid IdProdotto { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public int Prezzo { get; set; }

        public int Categoria_Id { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettaglio> Dettaglio { get; set; }
    }
}
