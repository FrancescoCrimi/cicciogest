using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.UwpBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;


namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class FornitoreViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<FornitoreViewModel> logger;
        private readonly INavigationService navigationService;
        //private readonly IMessageBoxService messageBoxService;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private RelayCommand loadedCommand;
        private RelayCommand nuovoFornitoreCommand;
        private AsyncRelayCommand salvaFornitoreCommand;
        private RelayCommand apriFornitoreCommand;
        private AsyncRelayCommand eliminaFornitoreCommand;

        public FornitoreViewModel(ILogger<FornitoreViewModel> logger,
                                  INavigationService navigationService,
                                  //IMessageBoxService messageBoxService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            //this.messageBoxService = messageBoxService;
            this.clientiFornitoriService = clientiFornitoriService;
            RegistraMessaggi();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Fornitore Fornitore { get; private set; }

        public Indirizzo Indirizzo { get; private set; }



        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() => { }));

        public ICommand NuovoFornitoreCommand => nuovoFornitoreCommand ?? (nuovoFornitoreCommand = new RelayCommand(()
            => MostraFornitore(new Fornitore())));

        public IAsyncRelayCommand SalvaFornitoreCommand => salvaFornitoreCommand ?? (salvaFornitoreCommand = new AsyncRelayCommand(async () =>
        {
            try
            {
                await clientiFornitoriService.SaveFornitore(Fornitore);
            }
            catch (Exception)
            {
                //messageBoxService.Show("Errore: " + ex.Message);
            }
        }));

        public IAsyncRelayCommand EliminaFornitoreCommand => eliminaFornitoreCommand ?? (eliminaFornitoreCommand = new AsyncRelayCommand(async () =>
        {
            try
            {
                await clientiFornitoriService.DeleteFornitore(Fornitore.Id);
            }
            catch (Exception)
            {
                //messageBoxService.Show("Errore: " + ex.Message);
            }
        }));

        public ICommand ApriFornitoreCommand => apriFornitoreCommand ?? (apriFornitoreCommand = new RelayCommand(()
            => navigationService.Navigate(nameof(ListaFornitoriViewModel))));



        private void RegistraMessaggi()
        {
            Messenger.Register<FornitoreIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    Fornitore fornitore = await clientiFornitoriService.GetFornitore(m.Value);
                    MostraFornitore(fornitore);
                }
            });
        }

        private void MostraFornitore(Fornitore fornitore)
        {
            Fornitore = fornitore;
            OnPropertyChanged(nameof(Fornitore));
            Indirizzo = fornitore.IndirizzoNew;
            OnPropertyChanged(nameof(Indirizzo));
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
