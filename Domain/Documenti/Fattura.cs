using CiccioGest.Domain.Common;
using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;
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

        private void Initialize()
        {
            dettagli = new CiccioList<Dettaglio>();
        }

        [OnDeserializing]
        void OnDeserializing(StreamingContext c)
        {
            Initialize();
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

        [DataMember]
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
