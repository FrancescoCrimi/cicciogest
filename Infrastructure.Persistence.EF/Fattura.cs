namespace Ciccio1.Infrastructure.Persistence.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fattura")]
    public partial class Fattura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fattura()
        {
            Dettaglio = new HashSet<Dettaglio>();
        }

        public int Id { get; set; }

        public Guid IdFattura { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettaglio> Dettaglio { get; set; }
    }
}
