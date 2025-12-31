// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System;
using System.Linq;

namespace CiccioGest.Domain.Anagrafica
{
    public class Indirizzo : DomainValueObject, IEquatable<Indirizzo>
    {
        private string? via;
        private string? civico;
        private string? cap;
        private string? comune;
        private string? provincia;
        private string? nazione;

        public Indirizzo() { }

        /// <summary>
        /// Crea un nuovo Indirizzo. 
        /// Se il CAP non è fornito, viene utilizzato il primo CAP disponibile del comune.
        /// Se lo Nazione non è fornito, viene impostato su "Italia".
        /// </summary>
        public Indirizzo(string via,
                         string civico,
                         Comune comune,
                         string? cap = null)
        {
            // Validazione Invarianti
            ArgumentException.ThrowIfNullOrWhiteSpace(via);
            ArgumentException.ThrowIfNullOrWhiteSpace(civico);
            ArgumentNullException.ThrowIfNull(comune);

            Via = via;
            Civico = civico;
            Comune = comune.Nome;
            Provincia = comune.Provincia;
            Nazione = comune.Nazione.Nome;

            // Se il CAP è nullo o vuoto, prendiamo il primo dal comune
            if (string.IsNullOrWhiteSpace(cap))
            {
                // Verifichiamo che il comune abbia almeno un CAP per evitare eccezioni
                CAP = comune.Caps.FirstOrDefault()
                    ?? throw new DomainException($"Impossibile determinare un CAP per il comune {comune.Nome}");
            }
            else
            {
                // Se il CAP è fornito, validiamo che appartenga effettivamente al comune
                if (!comune.Caps.Contains(cap))
                    throw new CapNonValidoException(cap, comune.Nome);
                CAP = cap;
            }
        }

        public virtual string? Via
        {
            get => via;
            set
            {
                if (value != via)
                {
                    via = value;
                    NotifyPropertyChanged(nameof(Via));
                }
            }
        }
        public virtual string? Civico
        {
            get => civico;
            set
            {
                if (value != civico)
                {
                    civico = value;
                    NotifyPropertyChanged(nameof(Civico));
                }
            }
        }
        public virtual string? CAP
        {
            get => cap;
            set
            {
                if (value != cap)
                {
                    cap = value;
                    NotifyPropertyChanged(nameof(CAP));
                }
            }
        }
        public virtual string? Comune
        {
            get => comune;
            set
            {
                if (value != comune)
                {
                    comune = value;
                    NotifyPropertyChanged(nameof(Comune));
                }
            }
        }
        public virtual string? Provincia
        {
            get => provincia;
            set
            {
                if (value != provincia)
                {
                    provincia = value;
                    NotifyPropertyChanged(nameof(Provincia));
                }
            }
        }
        public virtual string? Nazione
        {
            get => nazione;
            set
            {
                if (value != nazione)
                {
                    nazione = value;
                    NotifyPropertyChanged(nameof(Nazione));
                }
            }
        }


        public override bool Equals(object? obj)
        {
            return Equals(obj as Indirizzo);
        }

        public virtual bool Equals(Indirizzo? other)
        {
            return other != null &&
                   Id == other.Id &&
                   Via == other.Via &&
                   Civico == other.Civico &&
                   CAP == other.CAP &&
                   Comune == other.Comune &&
                   Nazione == other.Nazione;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Via, Civico, CAP, Comune, Nazione);
        }

        // Best Practice DDD: Override di ToString per facilitare il debug/logging
        public override string ToString() => $"{Via} {Civico}, {CAP} {Comune} {Provincia}, {Nazione}";
    }
}
