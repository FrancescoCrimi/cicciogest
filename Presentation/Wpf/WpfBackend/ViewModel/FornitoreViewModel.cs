﻿using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class FornitoreViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<FornitoreViewModel> logger;
        private readonly INavigationService navigationService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private RelayCommand loadedCommand;
        private RelayCommand nuovoFornitoreCommand;
        private AsyncRelayCommand salvaFornitoreCommand;
        private AsyncRelayCommand rimuoviFornitoreCommand;
        private RelayCommand apriFornitoreCommand;

        public FornitoreViewModel(ILogger<FornitoreViewModel> logger,
                                  INavigationService navigationService,
                                  IMessageBoxService messageBoxService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;
            this.clientiFornitoriService = clientiFornitoriService;
            RegistraMessaggi();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Fornitore Fornitore { get; private set; }

        public Indirizzo Indirizzo { get; private set; }


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




        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });


        public ICommand NuovoFornitoreCommand => nuovoFornitoreCommand ??= new RelayCommand(() =>
        {
            MostraFornitore(new Fornitore());
        });

        public IAsyncRelayCommand SalvaFornitoreCommand => salvaFornitoreCommand ??= new AsyncRelayCommand(SalvaFornitore);

        private async Task SalvaFornitore()
        {
            try
            {
                await clientiFornitoriService.SaveFornitore(Fornitore);
            }
            catch (Exception ex)
            {
                messageBoxService.Show("Errore: " + ex.Message);
            }
        }

        public IAsyncRelayCommand RimuoviFornitoreCommand => rimuoviFornitoreCommand ??= new AsyncRelayCommand(RimuoviFornitore);

        private async Task RimuoviFornitore()
        {
            try
            {
                await clientiFornitoriService.DeleteFornitore(Fornitore.Id);
            }
            catch (Exception ex)
            {
                messageBoxService.Show("Errore: " + ex.Message);
            }
        }

        public ICommand ApriFornitoreCommand => apriFornitoreCommand ??= new RelayCommand(
            () => navigationService.NavigateTo(nameof(ListaFornitoriViewModel)));


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
