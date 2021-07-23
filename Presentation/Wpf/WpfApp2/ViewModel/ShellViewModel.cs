using CiccioGest.Presentation.WpfApp2.Contracts;
using CiccioGest.Presentation.WpfApp2.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class ShellViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService ns;

        public ShellViewModel(ILogger<ShellViewModel> logger, INavigationService ns)
        {
            this.logger = logger;
            this.ns = ns;
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovaFatturaCommand =>
            new RelayCommand(() => ns.NavigateTo(typeof(FatturaView), true));

        public ICommand ApriArticoliCommand =>
            new RelayCommand(() => ns.NavigateTo(typeof(ArticoloView), true));

        public ICommand ApriCategorieCommand =>
            new RelayCommand(() => ns.NavigateTo(typeof(CategoriaView), true));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
