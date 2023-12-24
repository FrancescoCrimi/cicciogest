using System;
using System.Collections.Generic;

namespace CiccioGest.Domain.Magazino
{
    public class ArticoloReadOnly
    {
        public ArticoloReadOnly(int id, string? nome, int prezzo, IEnumerable<Categoria> categorie)
        {
            Id = id;
            Nome = nome;
            Prezzo = prezzo;
            Categorie = categorie;
        }
        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public int Prezzo { get; private set; }
        public IEnumerable<Categoria> Categorie { get; private set; }
    }
}
