using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ShellViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly INavigationService ns;

        public ShellViewModel(ILogger logger, INavigationService ns)
        {
            this.logger = logger;
            this.ns = ns;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovaFatturaCommand => new RelayCommand(NuovaFattura);

        private void NuovaFattura()
        {
            ns.NavigateTo("Fattura", true);
        }

        public ICommand ApriProdottiCommand => new RelayCommand(ApriProdotti);

        private void ApriProdotti()
        {
            ns.NavigateTo("Articolo", true);
        }

        public ICommand ApriCategorieCommand => new RelayCommand(ApriCategorie);

        private void ApriCategorie()
        {
            ns.NavigateTo("Categoria", true);
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
