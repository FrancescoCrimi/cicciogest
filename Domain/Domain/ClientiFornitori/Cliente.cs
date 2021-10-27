using CiccioGest.Domain.Common;
using System;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Cliente : Persona, IEquatable<Cliente>
    {

        public Cliente() { }

        public override string ToString() => $"{Nome} {Cognome}";

        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }

        public virtual bool Equals(Cliente other)
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
