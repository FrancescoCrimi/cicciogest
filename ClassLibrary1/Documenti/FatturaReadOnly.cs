using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Documenti
{
    [Serializable]
    public class FatturaReadOnly
    {
        public FatturaReadOnly(int Id, string Nome, int Totale)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Totale = Totale;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Totale { get; private set; }
    }
}
