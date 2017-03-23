using CiccioGest.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Categoria : DomainEntity<Categoria>
    {
        private string nome;

        internal Categoria() { }

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
