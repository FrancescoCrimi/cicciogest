// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;

namespace CiccioGest.Domain.Anagrafica
{
    public class Nazione : DomainEntity
    {
        public Nazione(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }

        protected Nazione()
        {
            Nome = null!;
            Sigla = null!;
        }

        public virtual string Nome { get; protected set; }
        public virtual string Sigla { get; protected set; } // es: IT, FR, US
    }
}
