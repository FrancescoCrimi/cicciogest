using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public sealed class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly IWindowManagerService windowManagerService;
        private ICommand loadedCommand;
        private ICommand apriFatturaCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IFatturaService fatturaService,
                                IWindowManagerService windowManagerService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.windowManagerService = windowManagerService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }

        public FatturaReadOnly FatturaSelezionata { private get; set; }

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand<Window>((wnd) =>
        {
            if (FatturaSelezionata != null)
            {
                windowManagerService.OpenWindow(typeof(FatturaView));
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
                wnd.Close();
            }
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () => 
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        });

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
