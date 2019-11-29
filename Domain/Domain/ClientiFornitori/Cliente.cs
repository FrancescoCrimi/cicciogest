using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    [DataContract(Name = "Cliente", Namespace = "http://gest.cicciosoft.tk")]
    public class Cliente : DomainEntity, IEquatable<Cliente>
    {
        private string nome;
        private string cognome;

        protected Cliente() { }

        public virtual string Nome
        {
            get { return nome; }
            set
            {
                if (value != nome)
                {
                    nome = value;
                    NotifyPropertyChanged(nameof(Nome));
                    ImpostaNomeCompleto();
                }
            }
        }

        public virtual string Cognome
        {
            get { return cognome; }
            set
            {
                if (value != cognome)
                {
                    cognome = value;
                    NotifyPropertyChanged(nameof(Cognome));
                    ImpostaNomeCompleto();
                }
            }
        }

        public virtual string NomeCompleto { get; protected set; }

        private void ImpostaNomeCompleto()
        {
            NomeCompleto = Nome + " " + Cognome;
            NotifyPropertyChanged(nameof(NomeCompleto));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }

        public bool Equals(Cliente other)
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
