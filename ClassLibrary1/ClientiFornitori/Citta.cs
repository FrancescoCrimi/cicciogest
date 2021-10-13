using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    public class Citta : DomainEntity, IEquatable<Citta>
    {
        protected Citta() { }

        public string Nome { get; private set; }

        public string Provincia { get; private set; }


        public override bool Equals(object obj)
        {
            return Equals(obj as Citta);
        }

        public bool Equals(Citta other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
