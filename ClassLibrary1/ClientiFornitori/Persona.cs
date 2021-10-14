﻿using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    public abstract class Persona : DomainEntity
    {
        private string nome;
        private string cognome;
        private string email;
        private string telefono;
        private string indirizzo;
        private string partitaIva;
        private string codiceFiscale;

        public virtual string Nome
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

        public virtual string Cognome
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

        public virtual string NomeCompleto => Nome + " " + Cognome;

        public virtual string Email
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

        public virtual string Telefono
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

        public virtual string Indirizzo
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

        public virtual string PartitaIva
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

        public virtual string CodiceFiscale
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
    }
}