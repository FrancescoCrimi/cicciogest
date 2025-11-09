// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System;

namespace CiccioGest.Domain.ClientiFornitori
{
    public abstract class Persona : DomainEntity
    {
        private string? nome;
        private string? cognome;
        private string? societa;
        private string? email;
        private string? telefono;
        private string? mobile;
        private string? indirizzo;
        private string? partitaIva;
        private string? codiceFiscale;
        private Indirizzo? indirizzoNew;

        protected Persona()
        {
            IndirizzoNew = new Indirizzo();
        }

        public virtual string? Nome
        {
            get => nome;
            set
            {
                if (value != nome)
                {
                    nome = value;
                    NotifyPropertyChanged(nameof(Nome));
                    NotifyPropertyChanged(nameof(NomeCompleto));
                }
            }
        }

        public virtual string? Cognome
        {
            get => cognome;
            set
            {
                if (value != cognome)
                {
                    cognome = value;
                    NotifyPropertyChanged(nameof(Cognome));
                    NotifyPropertyChanged(nameof(NomeCompleto));
                }
            }
        }

        public virtual string? Societa
        {
            get => societa;
            set
            {
                if (value != societa)
                {
                    societa = value;
                    NotifyPropertyChanged(nameof(Societa));
                }
            }
        }

        public virtual string? NomeCompleto => Nome + " " + Cognome;

        public virtual string? Email
        {
            get => email;
            set
            {
                if (value != email)
                {
                    email = value;
                    NotifyPropertyChanged(nameof(Email));
                }
            }
        }

        public virtual string? Telefono
        {
            get => telefono;
            set
            {
                if (value != telefono)
                {
                    telefono = value;
                    NotifyPropertyChanged(nameof(Telefono));
                }
            }
        }

        public virtual string? Mobile
        {
            get => mobile;
            set
            {
                if (value != mobile)
                {
                    mobile = value;
                    NotifyPropertyChanged(nameof(Mobile));
                }
            }
        }

        public virtual string? Indirizzo
        {
            get => indirizzo;
            set
            {
                if (value != indirizzo)
                {
                    indirizzo = value;
                    NotifyPropertyChanged(nameof(Indirizzo));
                }
            }
        }

        public virtual string? PartitaIva
        {
            get => partitaIva;
            set
            {
                if (value != partitaIva)
                {
                    partitaIva = value;
                    NotifyPropertyChanged(nameof(PartitaIva));
                }
            }
        }

        public virtual string? CodiceFiscale
        {
            get => codiceFiscale;
            set
            {
                if (value != codiceFiscale)
                {
                    codiceFiscale = value;
                    NotifyPropertyChanged(nameof(CodiceFiscale));
                }
            }
        }

        public virtual Indirizzo? IndirizzoNew
        {
            get => indirizzoNew;
            set
            {
                indirizzoNew = value;
            }
        }
    }
}
