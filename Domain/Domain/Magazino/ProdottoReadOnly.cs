using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazino
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class ProdottoReadOnly
    {
        public ProdottoReadOnly(int Id, string Nome, int Prezzo, string NomeCategoria)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Prezzo = Prezzo;
            this.NomeCategoria = NomeCategoria;
        }
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Nome { get; private set; }
        [DataMember]
        public int Prezzo { get; private set; }
        [DataMember]
        public string NomeCategoria { get; private set; }
    }
}
