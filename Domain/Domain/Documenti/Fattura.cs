using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Common;
using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;

namespace CiccioGest.Domain.Documenti
{
    public class Fattura : DomainEntity, IEquatable<Fattura>
    {
        //private string nome;
        private IList<Dettaglio> dettagli;
        private Cliente cliente;

        // usato da nhibernate
        protected Fattura()
        {
            //dettagli = new CiccioList<Dettaglio>();
        }

        public Fattura(int id, Cliente cliente)
            : this(cliente)
        {
            this.Id = id;
        }

        public Fattura(Cliente cliente)
        {
            Cliente = cliente;
            dettagli = new CiccioList<Dettaglio>();
        }


        public virtual Cliente Cliente
        {
            get => cliente;
            protected set => cliente = value;
        }

        public virtual string Nome => cliente.NomeCompleto;

        public virtual IList<Dettaglio> Dettagli
        {
            get => dettagli;
            protected set
            {
                if (value != dettagli)
                {
                    dettagli = value;
                    NotifyPropertyChanged(nameof(Dettagli));
                }
            }
        }

        public virtual int Totale { get; protected set; }


        public virtual void AddDettaglio(Dettaglio dettaglio)
        {
            if (!dettagli.Contains(dettaglio))
            {
                dettagli.Add(dettaglio);
                CalcolaTotale();
            }
            else
            {
                Dettaglio d = dettagli[dettagli.IndexOf(dettaglio)];
                d.Quantita = (d.Quantita + dettaglio.Quantita);
                CalcolaTotale();
            }
        }

        public virtual void RemoveDettaglio(Dettaglio dettaglio)
        {
            if (dettagli.Contains(dettaglio))
            {
                dettagli.Remove(dettaglio);
                CalcolaTotale();
            }
        }

        public virtual void AddDettagli(ISet<Dettaglio> dettagli)
        {
            foreach (Dettaglio dettaglio in dettagli)
                AddDettaglio(dettaglio);
        }


        private void CalcolaTotale()
        {
            Totale = 0;
            if (Dettagli != null)
            {
                if (dettagli.Count > 0)
                {
                    foreach (Dettaglio prodItem in Dettagli)
                    {
                        Totale += prodItem.Totale;
                    }
                }
            }
            NotifyPropertyChanged(nameof(Totale));
        }


        public override bool Equals(object? obj)
        {
            return Equals(obj as Fattura);
        }

        public virtual bool Equals(Fattura? other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
