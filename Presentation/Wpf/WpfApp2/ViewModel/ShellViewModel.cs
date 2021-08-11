using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
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
            new RelayCommand(() => ns.NavigateTo(typeof(FattureView), true));

        public ICommand ApriArticoliCommand => apriArticoliCommand ??=
            new RelayCommand(() => ns.NavigateTo(typeof(ArticoliView), true));

        public ICommand ApriCategorieCommand => apriCategorieCommand ??=
            new RelayCommand(() => ns.NavigateTo(typeof(CategoriaView), true));

        public ICommand ApriClientiCommand => apriClientiCommand ??=
            new RelayCommand(() => ns.NavigateTo(typeof(ClientiView)));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
