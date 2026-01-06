// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public class FattureViewReturn(int idFattura)
    {
        public int IdFattura { get; } = idFattura;
    }

    public class ClientiViewReturn(int idCliente)
    {
        public int IdCliente { get; } = idCliente;
    }

    public class FornitoriViewReturn(int idFornitore)
    {
        public int IdFornitore { get; } = idFornitore;
    }

    public class ArticoliViewReturn(int idArticolo)
    {
        public int IdArticolo { get; } = idArticolo;
    }

    public class CategoriaViewReturn(int idArticolo)
    {
        public int IdCategoria { get; } = idArticolo;
    }
}
