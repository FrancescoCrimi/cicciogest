using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.DomainBase;
using DddTest.Infrastructure.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CiccioGest.Domain.Documenti
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    [KnownType(typeof(Categoria))]
    public class Dettaglio : ValueObject<Dettaglio>
    {
        private int quantita;
        private Prodotto prodotto;

        public Dettaglio() { }

        public Dettaglio(Prodotto prodotto, int quantita)
        {
            modificaQuantita(quantita);
            modificaProdotto(prodotto);
        }

        [DataMember]
        public virtual int Quantita
        {
            get { return quantita; }
            set
            {
                if (value != quantita)
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

        internal protected virtual Fattura Fattura { get; set; }


        private void modificaQuantita(int quantita)
        {
            this.quantita = quantita;
            NotifyPropertyChanged("Quantita");
            calcolaTotale();
        }

        private void modificaProdotto(Prodotto prodotto)
        {
            if (prodotto != null)
            {
                this.prodotto = prodotto;
                NomeProdotto = prodotto.Nome;
                PrezzoProdotto = prodotto.Prezzo;
                NotifyPropertyChanged("NomeProdotto");
                NotifyPropertyChanged("PrezzoProdotto");
                calcolaTotale();
            }
        }

        private void calcolaTotale()
        {
            Totale = PrezzoProdotto * Quantita;
            NotifyPropertyChanged("Totale");
            if (Fattura != null)
                Fattura.CalcolaTotale();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            if(Prodotto != null)
                yield return Prodotto.Id;
            //yield return Quantità;
            yield break;
        }
    }
}
