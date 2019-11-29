using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Stato
    {
        public Stato( string nome)
        {
            Nome = nome;
        }

        [DataMember]
        public string Nome { get; private set; }
    }
}