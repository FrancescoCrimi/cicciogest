// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Indirizzo : DomainValueObject, IEquatable<Indirizzo>
    {
        private string? via;
        private string? civico;
        private string? cap;
        private string? citta;
        private string? stato;

        public Indirizzo() { }

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
        public virtual string? Citta
        {
            get => citta;
            set
            {
                if (value != citta)
                {
                    citta = value;
                    NotifyPropertyChanged(nameof(Citta));
                }
            }
        }
        public virtual string? Stato
        {
            get => stato;
            set
            {
                if (value != stato)
                {
                    stato = value;
                    NotifyPropertyChanged(nameof(Stato));
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
                   Citta == other.Citta &&
                   Stato == other.Stato;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Via, Civico, CAP, Citta, Stato);
        }
    }
}
