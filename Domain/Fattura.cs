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
    public class Fattura : DomainEntity<Fattura>
    {
        private string nome;
        private ISet<Dettaglio> dettagli;

        internal Fattura()
        {
            Dettagli = new HashSet<Dettaglio>();
        }

        [DataMember]
        public virtual string Nome
        {
            get { return nome; }
            set
            {
                if (value != nome)
                {
                    this.nome = value;
                    NotifyPropertyChanged("Nome");
                }
            }
        }

        [DataMember]
        public virtual IEnumerable<Dettaglio> Dettagli
        {
            get { return dettagli; }
            protected set
            {
                foreach (Dettaglio dett in value)
                {
                    dett.TotaleChanged += dettaglioTotaleChanged;
                }
                dettagli = (ISet<Dettaglio>)value;
            }
        }

        [DataMember]
        public virtual int Totale { get; protected set; }

        public virtual void AddDettaglio(Dettaglio dettaglio)
        {
            //dettaglio.ImpostaFattura(this);
            if (!dettagli.Contains(dettaglio))
            {
                dettagli.Add(dettaglio);
                dettaglio.TotaleChanged += dettaglioTotaleChanged;
                calcolaTotale();
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
                dettaglio.TotaleChanged -= dettaglioTotaleChanged;
                calcolaTotale();
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

        private void calcolaTotale()
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

        private void dettaglioTotaleChanged(object sender, EventArgs e)
        {
            calcolaTotale();
        }
    }
}
