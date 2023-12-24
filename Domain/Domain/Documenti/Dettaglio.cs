using CiccioGest.Domain.Common;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Domain.Documenti
{
    public class Dettaglio : DomainValueObject, IEquatable<Dettaglio?>
    {
        private int _quantita;
        private Articolo? _articolo;

        public Dettaglio() { }

        public Dettaglio(Articolo articolo, int quantita)
        {
            ModificaQuantita(quantita);
            ModificaProdotto(articolo);
        }

        public Dettaglio(int id, Articolo articolo, int quantita)
            : this(articolo, quantita)
        {
            this.Id = id;
        }

        public virtual int Quantita
        {
            get { return _quantita; }
            set
            {
                if (value != _quantita)
                    ModificaQuantita(value);
            }
        }

        public virtual Articolo? Articolo
        {
            get { return _articolo; }
            set
            {
                if (value != _articolo)
                    ModificaProdotto(value);
            }
        }

        public virtual int Totale { get; protected set; }

        public virtual string? NomeProdotto { get; protected set; }

        public virtual int PrezzoProdotto { get; protected set; }

        //internal protected virtual Fattura Fattura { get; set; }


        private void ModificaQuantita(int quantita)
        {
            this._quantita = quantita;
            NotifyPropertyChanged(nameof(Quantita));
            CalcolaTotale();
        }

        private void ModificaProdotto(Articolo? articolo)
        {
            if (articolo != null)
            {
                _articolo = articolo;
                NomeProdotto = articolo.Nome;
                PrezzoProdotto = articolo.Prezzo;
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

        public override bool Equals(object? obj)
        {
            return Equals(obj as Dettaglio);
        }

        public virtual bool Equals(Dettaglio? other)
        {
            return other is not null &&
                   EqualityComparer<Articolo?>.Default.Equals(Articolo, other.Articolo);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Articolo);
        }
    }
}
