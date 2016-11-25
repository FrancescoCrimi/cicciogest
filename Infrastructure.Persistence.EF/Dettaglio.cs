namespace Ciccio1.Infrastructure.Persistence.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dettaglio")]
    public partial class Dettaglio
    {
        public int Id { get; set; }

        public int Quantità { get; set; }

        public int Prodotto_Id { get; set; }

        public int Fattura_Id { get; set; }

        public virtual Prodotto Prodotto { get; set; }

        public virtual Fattura Fattura { get; set; }
    }
}
