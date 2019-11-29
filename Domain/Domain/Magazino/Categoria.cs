using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Magazino
{
    [Serializable]
    [DataContract(Name = "Categoria", Namespace = "http://gest.cicciosoft.tk")]
    public class Categoria : DomainEntity, IEquatable<Categoria>
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
                    NotifyPropertyChanged(nameof(Nome));
                }
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Categoria);
        }

        public virtual bool Equals(Categoria other)
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
