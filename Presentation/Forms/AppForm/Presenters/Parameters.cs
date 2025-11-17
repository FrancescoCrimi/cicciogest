// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public abstract class ParameterBase { }

    public sealed class IdClienteParameter : ParameterBase
    {
        public IdClienteParameter(int idCliente) => IdCliente = idCliente;
        public int IdCliente { get; private set; }
    }

    public sealed class IdFatturaParameter : ParameterBase
    {
        public IdFatturaParameter(int idFattura) => IdFattura = idFattura;
        public int IdFattura { get; private set; }
    }

    public sealed class IdArticoloParameter : ParameterBase
    {
        public IdArticoloParameter(int idArticolo) => IdArticolo = idArticolo;
        public int IdArticolo { get; private set; }
    }

    public sealed class IdFornitoreParameter : ParameterBase
    {
        public IdFornitoreParameter(int idFornitore) => IdFornitore = idFornitore;
        public int IdFornitore { get; private set; }
    }

    //public sealed class IdCategoriaParameter : ParameterBase
    //{
    //    public IdCategoriaParameter(CategoriaDto categoria) => Categoria = categoria;
    //    public CategoriaDto Categoria { get; private set; }
    //}
}
