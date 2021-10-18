using CiccioGest.Domain.Common;
using System;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Fornitore : Persona, IEquatable<Fornitore>
    {
        public Fornitore() { }


        public override bool Equals(object obj)
        {
            return Equals(obj as Fornitore);
        }

        public virtual bool Equals(Fornitore other)
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
