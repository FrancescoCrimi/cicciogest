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
        private int quantità;
        private Prodotto prodotto;
        public virtual event EventHandler TotaleChanged;


        public Dettaglio() { }

        public Dettaglio(Prodotto prodotto, int quantità)
        {
            modificaQuantita(quantità);
            modificaProdotto(prodotto);
        }

        [DataMember]
        public virtual int Quantità
        {
            get { return quantità; }
            set
            {
                if (value != quantità)
                    modificaQuantita(value);
            }
        }

        [DataMember]
        public virtual Prodotto Prodotto
        {
            get { return prodotto; }
            set
            {
                if (value != prodotto)
                    modificaProdotto(value);
            }
        }

        [DataMember]
        public virtual int Totale { get; protected set; }

        [DataMember]
        public virtual string NomeProdotto { get; protected set; }

        [DataMember]
        public virtual int PrezzoProdotto { get; protected set; }


        private void modificaQuantita(int quantità)
        {
            this.quantità = quantità;
            NotifyPropertyChanged("Quantità");
            calcolaTotale();
        }

        private void modificaProdotto(Prodotto prodotto)
        {
            this.prodotto = prodotto;
            NomeProdotto = prodotto.Nome;
            PrezzoProdotto = prodotto.Prezzo;
            NotifyPropertyChanged("NomeProdotto");
            NotifyPropertyChanged("PrezzoProdotto");
            calcolaTotale();
        }

        private void calcolaTotale()
        {
            Totale = PrezzoProdotto * Quantità;
            NotifyPropertyChanged("Totale");
            if (TotaleChanged != null)
                TotaleChanged(this, new EventArgs());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Prodotto.Id;
            //yield return Quantità;
            yield break;
        }
    }
}
