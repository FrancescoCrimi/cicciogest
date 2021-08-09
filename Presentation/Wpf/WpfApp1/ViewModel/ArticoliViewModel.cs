using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
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
    public sealed class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand selezionaArticoloCommand;
        private ICommand loadedCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazinoService service)
        {
            this.logger = logger;
            this.service = service;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato { private get; set; }

        public ICommand SelezionaArticoloCommand => selezionaArticoloCommand ??= new RelayCommand<Window>((wnd) =>
        {
            if (ArticoloSelezionato != null)
            {
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                wnd.Close();
            }
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Articoli.Add(pr);
            }
        });

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
