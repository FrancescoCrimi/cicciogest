using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazino
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Categoria : DomainEntity<Categoria>
    {
        private string nome;

        public Categoria() { }
        public Categoria(string nome)
        {
            this.nome = nome;
        }
        public Categoria(int id, string nome)
            : this(nome)
        {
            Id = id;
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
    }
}
