using CiccioGest.Domain.Common;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Documenti
{
    [Serializable]
    public class Dettaglio : DomainValueObject, IEquatable<Dettaglio>
    {
        private int quantita;
        private Articolo articolo;

        public Dettaglio() { }

        public Dettaglio(Articolo prodotto, int quantita)
        {
            ModificaQuantita(quantita);
            ModificaProdotto(prodotto);
        }

        public Dettaglio(int id, Articolo prodotto, int quantita)
            : this(prodotto, quantita)
        {
            this.Id = id;
        }

        public virtual int Quantita
        {
            get { return quantita; }
            set
            {
                if (value != quantita)
                    ModificaQuantita(value);
            }
        }

        public virtual Articolo Articolo
        {
            get { return articolo; }
            set
            {
                if (value != articolo)
                    ModificaProdotto(value);
            }
        }

        public virtual int Totale { get; protected set; }

        public virtual string NomeProdotto { get; protected set; }

        public virtual int PrezzoProdotto { get; protected set; }

        //internal protected virtual Fattura Fattura { get; set; }


        private void ModificaQuantita(int quantita)
        {
            this.quantita = quantita;
            NotifyPropertyChanged(nameof(Quantita));
            CalcolaTotale();
        }

        private void ModificaProdotto(Articolo prodotto)
        {
            if (prodotto != null)
            {
                this.articolo = prodotto;
                NomeProdotto = prodotto.Nome;
                PrezzoProdotto = prodotto.Prezzo;
                NotifyPropertyChanged(nameof(NomeProdotto));
                NotifyPropertyChanged(nameof(PrezzoProdotto));
                CalcolaTotale();
            }
        }

        private void CalcolaTotale()
        {
            Totale = PrezzoProdotto * Quantita;
            NotifyPropertyChanged(nameof(Totale));
            //if (Fattura != null)
            //    Fattura.CalcolaTotale();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Dettaglio);
        }

        public virtual bool Equals(Dettaglio other)
        {
            return other != null &&
                   EqualityComparer<Articolo>.Default.Equals(Articolo, other.Articolo);
        }

        public override int GetHashCode()
        {
            return -209438310 + EqualityComparer<Articolo>.Default.GetHashCode(Articolo);
        }
    }
}
