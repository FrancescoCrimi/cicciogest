using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    public class Indirizzo : DomainValueObject
    {
        protected Indirizzo() { }

        public string Via { get; private set; }
        public string Civico { get; private set; }
        public string CAP { get; private set; }
        public Citta Citta { get; private set; }
        public Stato Stato { get; private set; }
    }
}
