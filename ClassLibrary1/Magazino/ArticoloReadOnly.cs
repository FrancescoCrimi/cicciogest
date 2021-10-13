using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Magazino
{
    [Serializable]
    public class ArticoloReadOnly
    {
        public ArticoloReadOnly(int Id, string Nome, int Prezzo, string NomeCategoria)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Prezzo = Prezzo;
            this.NomeCategoria = NomeCategoria;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Prezzo { get; private set; }
        public string NomeCategoria { get; private set; }
    }
}
