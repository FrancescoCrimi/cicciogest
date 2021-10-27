using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfBackend.Services;
using CiccioSoft.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class ArticoloViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly IMessageBoxService messageBoxService;
        private RelayCommand loadedCommand;
        private RelayCommand unloadedCommand;
        private RelayCommand nuovoCommand;
        private AsyncRelayCommand salvaCommand;
        private AsyncRelayCommand eliminaCommand;
        private RelayCommand aggiungiCategoriaCommand;
        private RelayCommand rimuoviCategoriaCommand;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger,
                                 IMessageBoxService messageBoxService,
                                 IMagazinoService magazinoService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.messageBoxService = messageBoxService;
            RegistraMessaggi();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Articolo Articolo { get; private set; }

        public ObservableList<Categoria> Categorie { get; private set; }

        public Categoria CategoriaSelezionata { private get; set; }

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public ICommand UnloadedCommand => unloadedCommand ??= new RelayCommand(() =>
        {
            Messenger.Unregister<ArticoloIdMessage>(this);
        });

        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(() 
            => MostraArticolo(new Articolo()));
        public IAsyncRelayCommand EliminaCommand => eliminaCommand ??= new AsyncRelayCommand(Elimina);
        public IAsyncRelayCommand SalvaCommand => salvaCommand ??= new AsyncRelayCommand(Salva);



        private void RegistraMessaggi()
        {
            Messenger.Register<ArticoloIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    Articolo articolo = await magazinoService.GetArticolo(m.Value);
                    MostraArticolo(articolo);
                }
                else
                {
                    MostraArticolo(new Articolo());
                }
            });
            Messenger.Register<CategoriaIdMessage>(this, async(r, m) =>
            {
                if(m.Value != 0)
                {
                    Categoria categoria = await magazinoService.GetCategoria(m.Value);
                    Articolo.AddCategoria(categoria);
                    OnPropertyChanged(nameof(Categorie));
                }
            });
        }

        private void MostraArticolo(Articolo articolo)
        {
            Articolo = articolo;
            OnPropertyChanged(nameof(Articolo));
            Categorie = new ObservableList<Categoria>(articolo.Categorie);
            OnPropertyChanged(nameof(Categorie));
        }

        private async Task Elimina()
        {
            try
            {
                await magazinoService.DeleteArticolo(Articolo.Id);
                MostraArticolo(new Articolo());
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        }

        private async Task Salva()
        {
            try
            {
                await magazinoService.SaveArticolo(Articolo);
                MostraArticolo(new Articolo());
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        }



        public ICommand AggiungiCategoriaCommand => aggiungiCategoriaCommand ??= new RelayCommand(AggiungiCategoria);

        private void AggiungiCategoria()
        {
        }

        public ICommand RimuoviCategoriaCommand => rimuoviCategoriaCommand ??= new RelayCommand(RimuoviCategoria);

        private void RimuoviCategoria()
        {
        }



        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }

        private RelayCommand apriClienteCommand;
        public ICommand ApriClienteCommand => apriClienteCommand ??= new RelayCommand(ApriCliente);

        private void ApriCliente()
        {
        }
    }
}
