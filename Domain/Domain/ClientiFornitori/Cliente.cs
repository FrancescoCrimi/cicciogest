// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

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
