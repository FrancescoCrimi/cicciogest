using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Indirizzo : DomainValueObject
    {
        private string via;
        private string civico;
        private string cap;
        private string citta;
        private string stato;

        public Indirizzo() { }

        public virtual string Via
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
        public virtual string Civico
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
        public virtual string CAP
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
        public virtual string Citta
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
        public virtual string Stato
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
    }
}
