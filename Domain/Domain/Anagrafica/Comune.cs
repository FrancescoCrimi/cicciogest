// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System.Collections.Generic;

namespace CiccioGest.Domain.Anagrafica
{
    public class Comune : DomainEntity
    {
        public Comune(string nome, string provincia, List<string> list, Nazione nazione)
        {
            Nome = nome;
            Provincia = provincia;
            Caps = list;
            Nazione = nazione;
        }

        protected Comune()
        {
            Nome = null!;
            Provincia = null!;
            Caps = [];
            Nazione = null!;
        }

        public virtual string Nome { get; protected set; }

        public virtual string Provincia { get; protected set; }

        public virtual IList<string> Caps { get; protected set; }

        public virtual Nazione Nazione { get; protected set; }
    }
}
