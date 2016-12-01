using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public class Categoria : Entity<int>
    {
        private string nome;
        private Guid idCategoria;

        protected Categoria() { }

        internal Categoria(Guid id)
        {
            IdCategoria = id;
        }

        [DataMember]
        public virtual Guid IdCategoria
        {
            get { return idCategoria; }
            protected set { idCategoria = value; }
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

        public override bool IsTransient()
        {
            return (IdCategoria == Guid.Empty);
        }
    }
}
