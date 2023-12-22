using CiccioGest.Domain.Common;
using System;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Cliente : Persona, IEquatable<Cliente?>
    {

        public Cliente() { }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Cliente);
        }

        public virtual bool Equals(Cliente? other)
        {
            return other is not null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString() => $"{Nome} {Cognome}";
    }
}
