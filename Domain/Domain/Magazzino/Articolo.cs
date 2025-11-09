// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Common;
using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;

namespace CiccioGest.Domain.Magazzino
{
    public class Articolo : DomainEntity, IEquatable<Articolo>
    {
        private string? nome;
        private int prezzo;
        private Fornitore? fornitore;
        private string? descrizione;

        public Articolo(int id, string nome, int prezzo)
            : this(nome, prezzo)
        {
            Id = id;
        }
        public Articolo(string nome, int prezzo)
            : this()
        {
            this.nome = nome;
            this.prezzo = prezzo;
        }
        public Articolo()
        {
            Categorie = new CiccioSet<Categoria>();
        }

        public virtual string? Nome
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

        public virtual int Prezzo
        {
            get { return prezzo; }
            set
            {
                if (value != prezzo)
                {
                    prezzo = value;
                    NotifyPropertyChanged(nameof(Prezzo));
                }
            }
        }

        public virtual string? Descrizione
        {
            get => descrizione;
            set
            {
                if (value != descrizione)
                {
                    descrizione = value;
                    NotifyPropertyChanged(nameof(Descrizione));
                }
            }
        }

        public virtual ISet<Categoria> Categorie { get; protected set; }

        public virtual Fornitore? Fornitore
        {
            get => fornitore;
            set
            {
                if (value != fornitore)
                {
                    fornitore = value;
                    NotifyPropertyChanged(nameof(Fornitore));
                }
            }
        }


        public virtual void AddCategoria(Categoria categoria)
        {
            Categorie.Add(categoria);
        }

        public virtual void RemoveCategoria(Categoria categoria)
        {
            Categorie.Remove(categoria);
        }




        public override bool Equals(object? obj)
        {
            return Equals(obj as Articolo);
        }

        public virtual bool Equals(Articolo? other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
