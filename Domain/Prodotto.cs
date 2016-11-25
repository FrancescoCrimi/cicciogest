using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ciccio1.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public class Prodotto : Entity<Prodotto>
    {
        private string nome;
        private int prezzo;
        private Guid idProdotto;
        private Categoria categoria;

        protected Prodotto() { }
        internal Prodotto(Guid id)
        {
            IdProdotto = id;
        }

        [DataMember]
        public virtual Guid IdProdotto
        {
            get { return idProdotto; }
            protected set { idProdotto = value; }
        }

        [DataMember]
        public virtual string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                NotifyPropertyChanged("Nome");
            }
        }

        [DataMember]
        public virtual int Prezzo
        {
            get { return prezzo; }
            set
            {
                prezzo = value;
                NotifyPropertyChanged("Prezzo");
            }
        }

        [DataMember]
        public virtual Categoria Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                NotifyPropertyChanged("Categoria");
            }
        }


        public virtual string NomeCategoria
        {
            get
            {
                if (this.Categoria == null) return "";
                else return this.Categoria.Nome;
            }
        }

        public override bool IsTransient()
        {
            return (IdProdotto == Guid.Empty);
        }
    }
}
