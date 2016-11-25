using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DddTest.Infrastructure.Builders;
using System.Runtime.Serialization;
using System.ComponentModel;
using Ciccio1.Infrastructure.DomainBase;

namespace Ciccio1.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public class Dettaglio : ValueObject<Dettaglio>
    {
        private int quantità = 0;
        private Prodotto prodotto = null;

        protected Dettaglio() { } // Needed by Hibernate

        internal Dettaglio(Prodotto prodotto, int quantità)
        {
            Quantità = quantità;
            Prodotto = prodotto;
        }

        [DataMember]
        public virtual int Quantità
        {
            get { return quantità; }
            set { modificaQuantita(value); }
        }

        [DataMember]
        public virtual Prodotto Prodotto
        {
            get { return prodotto; }
            set { modificaProdotto(value); }
        }

        public virtual int Totale
        {
            get
            {
                if (Prodotto != null)
                    return Prodotto.Prezzo * Quantità;
                else
                    return 0;
            }
        }

        public virtual string Nome
        {
            get
            {
                if (this.Prodotto == null) return "";
                else return this.Prodotto.Nome;
            }
        }

        public virtual int Prezzo
        {
            get
            {
                if (this.Prodotto == null) return 0;
                else return this.Prodotto.Prezzo;
            }
        }


        private void modificaQuantita(int quantita)
        {
            quantità = quantita;
            NotifyPropertyChanged("Totale");
        }

        private void modificaProdotto(Prodotto prod)
        {
            prodotto = prod;
            NotifyPropertyChanged("Prezzo");
            NotifyPropertyChanged("Totale");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Prodotto.Id;
            //yield return Quantità;
            yield break;
        }
    }
}
