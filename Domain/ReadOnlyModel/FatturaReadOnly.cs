using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.ReadOnlyModel
{
    [Serializable]
    [DataContract(Name = "FatturaReadOnly", Namespace = "http://cicciogest.it")]
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
