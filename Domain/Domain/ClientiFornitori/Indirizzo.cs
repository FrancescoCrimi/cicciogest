using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Indirizzo : DomainValueObject, IEquatable<Indirizzo>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Indirizzo);
        }

        public virtual bool Equals(Indirizzo other)
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
            int hashCode = 805346116;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Via);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Civico);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CAP);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Citta);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Stato);
            return hashCode;
        }
    }
}
