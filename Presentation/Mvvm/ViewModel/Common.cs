// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public interface IViewModel
    {
        void Initialize(object? parameter);
        //void Terminate();
    }


    public enum WizardResult
    {
        Finished,
        Canceled
    }


    public class FattureViewReturn
    {
        public FattureViewReturn(WizardResult result, int idFattura)
        {
            Result = result;
            IdFattura = idFattura;
        }
        public WizardResult Result { get; }
        public int IdFattura { get; }
    }

    public delegate Task FattureViewReturnHandler(FattureViewReturn fattureViewReturn);


    public class ClientiViewReturn
    {
        public ClientiViewReturn(WizardResult result, int idCliente)
        {
            Result = result;
            IdCliente = idCliente;
        }
        public WizardResult Result { get; }
        public int IdCliente { get; }
    }

    public delegate Task ClientiViewReturnHandler(ClientiViewReturn clientiViewReturn);

    public class FornitoriViewReturn
    {
        public FornitoriViewReturn(WizardResult result, int idFornitore)
        {
            Result = result;
            IdFornitore = idFornitore;
        }
        public WizardResult Result { get; }
        public int IdFornitore { get; }
    }

    public delegate Task FornitoriViewReturnHandler(FornitoriViewReturn fornitoriViewReturn);


    public class ArticoliViewReturn
    {
        public ArticoliViewReturn(WizardResult result, int idArticolo)
        {
            Result = result;
            IdArticolo = idArticolo;
        }
        public WizardResult Result { get; }
        public int IdArticolo { get; }
    }

    public delegate Task ArticoliViewReturnHandler(ArticoliViewReturn articoliViewReturn);


    public class CategoriaViewReturn
    {
        public CategoriaViewReturn(WizardResult result, int idArticolo)
        {
            Result = result;
            IdCategoria = idArticolo;
        }
        public WizardResult Result { get; }
        public int IdCategoria { get; }
    }

    public delegate Task CategoriaViewReturnHandler(CategoriaViewReturn categoriaViewReturn);
}
