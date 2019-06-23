using CiccioGest.Domain.Common;
using CiccioUtils.CiccioListe;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
//using System.Linq;
using System.Text;

namespace CiccioGest.Domain.Documenti
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Fattura : DomainEntity<Fattura>
    {
        private string nome;
        private IList<Dettaglio> dettagli;

        public Fattura()
        {
            dettagli = new DomainList<Dettaglio>();
            ((IBindingList)dettagli).ListChanged += Fattura_ListChanged;
            ((INotifyCollectionChanged)dettagli).CollectionChanged += Fattura_CollectionChanged;
        }

        private void Fattura_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void Fattura_ListChanged(object sender, ListChangedEventArgs e)
        {            
        }

        public Fattura(string nome)
            :this()
        {
            Nome = nome;
        }
        public Fattura(int id, string nome)
            :this(nome)
        {
            this.Id = id;
        }


        [DataMember]
        public virtual string Nome
        {
            get { return nome; }
            set
            {
                if (value != nome)
                {
                    nome = value;
                    NotifyPropertyChanged("Nome");
                }
            }
        }

        [DataMember]
        public virtual IList<Dettaglio> Dettagli
        {
            get { return dettagli; }
            protected set { dettagli = value; }
        }

        [DataMember]
        public virtual int Totale { get; protected set; }

        public virtual void AddDettaglio(Dettaglio dettaglio)
        {
            if (!dettagli.Contains(dettaglio))
            {
                dettaglio.Fattura = this;
                dettagli.Add(dettaglio);
                CalcolaTotale();
            }
            else
            {
                //DettaglioFattura d = Dettagli[Dettagli.IndexOf(dettaglio)];
                //DettaglioFattura d = Dettagli.foreac
                //d.Quantità = (dettaglio.Quantità + d.Quantità);
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

        //public virtual void ReplaceDettagli(IEnumerable<Dettaglio> dettagli)
        //{
        //    var newdett = new HashSet<Dettaglio>();
        //    foreach (Dettaglio item in dettagli)
        //    {
        //        newdett.Add(item);
        //    }
        //    this.dettagli = newdett;
        //}

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

        protected internal virtual void CalcolaTotale()
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
            NotifyPropertyChanged("Totale");
        }
    }
}
