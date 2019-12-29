﻿using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Fornitore : DomainEntity, IEquatable<Fornitore>
    {
        protected Fornitore() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as Fornitore);
        }

        public bool Equals(Fornitore other)
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