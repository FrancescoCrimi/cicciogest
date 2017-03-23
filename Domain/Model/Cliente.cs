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
    public class Cliente : DomainEntity<Cliente>
    {
        private string nome;
        private string cognome;

        internal Cliente() { }

        public virtual string Nome
        {
            get { return nome; }
            set
            {
                if (value != nome)
                {
                    nome = value;
                    NotifyPropertyChanged("Nome");
                    impostaNomeCompleto();
                }
            }
        }

        public virtual string Cognome
        {
            get { return cognome; }
            set
            {
                if(value != cognome)
                {
                    cognome = value;
                    NotifyPropertyChanged("Cognome");
                    impostaNomeCompleto();
                }
            }
        }

        public virtual string NomeCompleto { get; protected set; }

        private void impostaNomeCompleto()
        {
            NomeCompleto = Nome + " " + Cognome;
            NotifyPropertyChanged("NomeCompleto");
        }
    }
}
