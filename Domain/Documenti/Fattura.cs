using CiccioGest.Domain.Common;
using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Documenti
{
    [Serializable]
    [DataContract(Name = "Fattura", Namespace = "http://gest.cicciosoft.tk")]
    public class Fattura : DomainEntity, IEquatable<Fattura>
    {
        [NonSerialized]
        private string nome;
        private IList<Dettaglio> dettagli;

        public Fattura()
        {
            Initialize();
        }

        private void Initialize()
        {
            dettagli = new CiccioList<Dettaglio>();
            //dettagli = new List<Dettaglio>();
            ((IBindingList)dettagli).ListChanged += Fattura_ListChanged;
            //((INotifyCollectionChanged)dettagli).CollectionChanged += Fattura_CollectionChanged;
        }

        //private void Fattura_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //}

        private void Fattura_ListChanged(object sender, ListChangedEventArgs e)
        {
            CalcolaTotale();
        }

        //[OnDeserialized]
        //void OnDeserialized(StreamingContext c)
        //{
        //}

        [OnDeserializing]
        void OnDeserializing(StreamingContext c)
        {
            Initialize();
        }

        public Fattura(string nome)
            : this()
        {
            Nome = nome;
        }
        public Fattura(int id, string nome)
            : this(nome)
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
                    NotifyPropertyChanged(nameof(Nome));
                }
            }
        }

        [DataMember]
        public virtual IList<Dettaglio> Dettagli
        {
            get { return dettagli; }
            protected set
            {
                //((IBindingList)dettagli).ListChanged -= Fattura_ListChanged;
                dettagli = value ?? throw new ArgumentNullException(nameof(Dettagli));
                //((IBindingList)dettagli).ListChanged += Fattura_ListChanged;
            }
        }

        [DataMember]
        public virtual int Totale { get; protected set; }

        public virtual void AddDettaglio(Dettaglio dettaglio)
        {
            if (!dettagli.Contains(dettaglio))
            {
                //dettaglio.Fattura = this;
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Fattura);
        }

        public virtual bool Equals(Fattura other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
