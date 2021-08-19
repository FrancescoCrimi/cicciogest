using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class ShellViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService ns;
        private RelayCommand apriClientiCommand;
        private RelayCommand apriCategorieCommand;
        private RelayCommand apriArticoliCommand;
        private RelayCommand apriFattureCommand;

        public ShellViewModel(ILogger<ShellViewModel> logger,
                              INavigationService ns)
        {
            this.logger = logger;
            this.ns = ns;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ICommand ApriFattureCommand => apriFattureCommand ??=
            new RelayCommand(() => ns.NavigateTo(typeof(FattureViewModel).Name, true));

        public ICommand ApriArticoliCommand => apriArticoliCommand ??=
            new RelayCommand(() => ns.NavigateTo(typeof(ArticoliViewModel).Name, true));

        public ICommand ApriCategorieCommand => apriCategorieCommand ??=
            new RelayCommand(() => ns.NavigateTo(typeof(CategoriaViewModel).Name, true));

        public ICommand ApriClientiCommand => apriClientiCommand ??=
            new RelayCommand(() => ns.NavigateTo(typeof(ClientiViewModel).Name));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
