using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Domain
{
    public class DomainEntity<TEntity> : Entity<TEntity, int>
        where TEntity : DomainEntity<TEntity>
    { }

    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
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
                nome = value;
                NotifyPropertyChanged("Nome");
            }
        }
    }
}
