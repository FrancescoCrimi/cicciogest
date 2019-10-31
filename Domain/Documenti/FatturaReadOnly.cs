using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Documenti
{
    [Serializable]
    [DataContract(Name = "FatturaReadOnly", Namespace = "http://gest.cicciosoft.tk")]
    public class FatturaReadOnly
    {
        public FatturaReadOnly(int Id, string Nome, int Totale)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Totale = Totale;
        }
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Nome { get; private set; }
        [DataMember]
        public int Totale { get; private set; }
    }
}
