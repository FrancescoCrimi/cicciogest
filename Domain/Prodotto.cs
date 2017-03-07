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
    public class Prodotto : DomainEntity<Prodotto>
    {
        private string nome;
        private int prezzo;
        private Categoria categoria;

        internal Prodotto() { }

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
        public virtual int Prezzo
        {
            get { return prezzo; }
            set
            {
                if (value != prezzo)
                {
                    prezzo = value;
                    NotifyPropertyChanged("Prezzo");
                }
            }
        }

        //[DataMember]
        public virtual Categoria Categoria
        {
            get { return categoria; }
            set
            {
                if(value != categoria)
                {
                    categoria = value;
                    NomeCategoria = categoria.Nome;
                    NotifyPropertyChanged("NomeCategoria");
                }
            }
        }

        [DataMember]
        public virtual string NomeCategoria { get; protected set; }
    }
}
