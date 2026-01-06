// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Domain
{
    /// <summary>
    /// Classe base per tutte le eccezioni del dominio.
    /// Rappresenta una violazione delle regole di business.
    /// </summary>
    public class DomainException : Exception
    {
        // Uso del Primary Constructor non è ideale qui perché vogliamo ereditare da Exception
        public DomainException(string message) : base(message) { }

        public DomainException(string message, Exception innerException)
            : base(message, innerException) { }

        // Possiamo aggiungere un codice di errore specifico per il frontend
        public virtual string? ErrorCode { get; }
    }

    public class CapNonValidoException(string cap, string comune)
        : DomainException($"Il CAP '{cap}' non risulta associato al comune di {comune}.")
    {
        public override string ErrorCode => "INVALID_CAP";
    }
}
