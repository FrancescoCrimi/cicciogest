// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Fornitore : Persona, IEquatable<Fornitore>
    {
        public Fornitore() { }


        public override bool Equals(object? obj)
        {
            return Equals(obj as Fornitore);
        }

        public virtual bool Equals(Fornitore? other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
