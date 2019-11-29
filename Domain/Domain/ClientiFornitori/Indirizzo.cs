using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Indirizzo : DomainValueObject
    {
        protected Indirizzo() { }

        [DataMember]
        public string Via { get; private set; }
        [DataMember]
        public string Civico { get; private set; }
        [DataMember]
        public string CAP { get; private set; }
        [DataMember]
        public Citta Citta { get; private set; }
        [DataMember]
        public Stato Stato { get; private set; }
    }
}
