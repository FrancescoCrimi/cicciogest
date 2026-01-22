// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

namespace CiccioGest.Domain.Anagrafica
{
    public class CapNonValidoException(string cap, string comune)
        : DomainException($"Il CAP '{cap}' non risulta associato al comune di {comune}.")
    {
        public override string ErrorCode => "INVALID_CAP";
    }
}
