using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class ArticoloViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private readonly IMessageBoxService messageBoxService;
        private RelayCommand loadedCommand;
        private RelayCommand unloadedCommand;
        private RelayCommand nuovoCommand;
        private AsyncRelayCommand salvaCommand;
        private AsyncRelayCommand eliminaCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand aggiungiCategoriaCommand;
        private RelayCommand rimuoviCategoriaCommand;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger,
                                 IMagazinoService magazinoService,
                                 INavigationService navigationService,
                                 IMessageBoxService messageBoxService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;
            RegistraMessaggi();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Articolo Articolo { get; private set; }

        public ICollection<Categoria> Categorie { get; private set; }

        public Categoria CategoriaSelezionata { get; set; }


        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public ICommand UnloadedCommand => unloadedCommand ??= new RelayCommand(() =>
        {
            Messenger.Unregister<ArticoloIdMessage>(this);
            Messenger.Unregister<CategoriaIdMessage>(this);
        });

        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(()
            => MostraArticolo(new Articolo()));

        public IAsyncRelayCommand EliminaCommand => eliminaCommand ??= new AsyncRelayCommand(async () =>
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
        });

        public IAsyncRelayCommand SalvaCommand => salvaCommand ??= new AsyncRelayCommand(async () =>
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
        });

        public ICommand ApriArticoloCommand => apriArticoloCommand ??= new RelayCommand(()
            => navigationService.NavigateTo(nameof(ListaArticoliViewModel)));

        public ICommand AggiungiCategoriaCommand => aggiungiCategoriaCommand ??= new RelayCommand(()
            => navigationService.NavigateTo(nameof(CategoriaViewModel)));

        public ICommand RimuoviCategoriaCommand => rimuoviCategoriaCommand ??= new RelayCommand(() =>
        {
            if (CategoriaSelezionata != null)
            {
                Articolo.RemoveCategoria(CategoriaSelezionata);
                OnPropertyChanged(nameof(Categorie));
            }
        });



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
            Messenger.Register<CategoriaIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
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
            //Categorie = new ObservableList<Categoria>(articolo.Categorie);
            Categorie = articolo.Categorie;
            OnPropertyChanged(nameof(Categorie));
        }


        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
