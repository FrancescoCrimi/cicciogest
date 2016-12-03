using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
//using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace Ciccio1.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public class Fattura : Entity<int>
    {
        private string nome;

        [DataMember]
        protected IList<Dettaglio> dettagli;

        internal Fattura()
        {
            dettagli = new Collection<Dettaglio>();
        } // Needed by Nhibernate



        [DataMember]
        public virtual string Nome
        {
            get { return nome; }
            set
            {
                this.nome = value;
                NotifyPropertyChanged("Nome");
            }
        }

        public virtual IReadOnlyList<Dettaglio> Dettagli
        {
            get
            {
                return new ReadOnlyCollection<Dettaglio>(dettagli);
            }
        }

        public virtual int Totale
        {
            get
            {
                int totale = 0;
                if (Dettagli != null)
                {
                    if (dettagli.Count > 0)
                    {
                        foreach (Dettaglio prodItem in Dettagli)
                        {
                            totale += prodItem.Totale;
                        }
                    }
                }
                return totale;
            }
        }


        public virtual void AddDettaglio(Dettaglio dettaglio)
        {
            //dettaglio.ImpostaFattura(this);
            if (!dettagli.Contains(dettaglio))
            {
                dettagli.Add(dettaglio);
            }
            else
            {
                //DettaglioFattura d = Dettagli[Dettagli.IndexOf(dettaglio)];
                //DettaglioFattura d = Dettagli.foreac
                //d.Quantità = (dettaglio.Quantità + d.Quantità);
            }
            NotifyPropertyChanged("Totale");
        }

        public virtual void RemoveDettaglio(Dettaglio dettaglio)
        {
            if (dettagli.Contains(dettaglio))
            {
                dettagli.Remove(dettaglio);
            }
            NotifyPropertyChanged("Totale");
        }

        public virtual void ReplaceDettagli(IEnumerable<Dettaglio> dettagli)
        {
            var newdett = new Collection<Dettaglio>();
            foreach (Dettaglio item in dettagli)
            {
                newdett.Add(item);
            }
            this.dettagli = newdett;
        }

        public virtual void AddDettagli(ISet<Dettaglio> dettagli)
        {
            foreach (Dettaglio dettaglio in dettagli)
                AddDettaglio(dettaglio);
        }

        //public virtual void AddOrUpdate(Prodotto product)
        //{
        //    if (!products.Contains(product))
        //        products.Add(product);
        //    else
        //        products[products.IndexOf(product)] = product;
        //}
    }
}
