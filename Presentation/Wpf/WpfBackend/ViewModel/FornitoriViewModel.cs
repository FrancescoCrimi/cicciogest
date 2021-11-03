using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class FornitoriViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<FornitoriViewModel> logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly INavigationService navigationService;
        private Fornitore fornitoreSelezionato;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand nuovoFornitoreCommand;
        private RelayCommand apriFornitoreCommand;
        private AsyncRelayCommand aggiornaFornitoriCommand;

        public FornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                  INavigationService navigationService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            this.clientiFornitoriService = clientiFornitoriService;
            Fornitori = new ObservableCollection<Fornitore>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<Fornitore> Fornitori { get; private set; }
        public Fornitore FornitoreSelezionato
        {
            protected get => fornitoreSelezionato;
            set
            {
                if (value != fornitoreSelezionato)
                {
                    fornitoreSelezionato = value;
                    apriFornitoreCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoadedCommand => loadedCommand ??=
            new AsyncRelayCommand(AggiornaFornitori);

        public ICommand NuovoFornitoreCommand => nuovoFornitoreCommand ??= new RelayCommand(() =>
        {
        });

        public ICommand ApriFornitoreCommand => apriFornitoreCommand ??=
            new RelayCommand(ApriFornitore, () => FornitoreSelezionato != null);

        public ICommand AggiornaFornitoriCommand => aggiornaFornitoriCommand ??=
            new AsyncRelayCommand(AggiornaFornitori);



        private async Task AggiornaFornitori()
        {
            Fornitori.Clear();
            foreach (var item in await clientiFornitoriService.GetFornitori())
            {
                Fornitori.Add(item);
            }
            OnPropertyChanged(nameof(Fornitori));
        }

        protected virtual void ApriFornitore()
        {
            if (FornitoreSelezionato != null)
            {
                navigationService.NavigateTo(nameof(FornitoreViewModel));
                Messenger.Send(new FornitoreIdMessage(FornitoreSelezionato.Id));
            }
        }


        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
