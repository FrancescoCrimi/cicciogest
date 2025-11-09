// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Common;
using System;

namespace CiccioGest.Domain.Magazzino
{
    public class Categoria : DomainEntity, IEquatable<Categoria>
    {
        private string? nome;

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

        public override bool Equals(object? obj)
        {
            return Equals(obj as Categoria);
        }

        public virtual bool Equals(Categoria? other)
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
