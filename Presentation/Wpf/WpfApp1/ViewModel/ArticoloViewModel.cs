﻿//using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp1.ViewModel
{
    public sealed class ArticoloViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;
        private ICommand nuovoCommand;
        private ICommand salvaCommand;
        private ICommand eliminaCommand;
        private ArticoloReadOnly articoloSelezionato;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            Categorie = new ObservableCollection<Categoria>();

            if (IsInDesignMode)
            {
                Articolo = service.GetArticolo(4).Result;
                foreach (Categoria cat in service.GetCategorie().Result)
                {
                    Categorie.Add(cat);
                }
                foreach (ArticoloReadOnly pr in service.GetArticoli().Result)
                {
                    Articoli.Add(pr);
                }
            }
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(Nuovo);

        public ICommand EliminaCommand => eliminaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await service.DeleteArticolo(Articolo.Id);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand SalvaCommand => salvaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await service.SaveArticolo(Articolo);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            foreach (Categoria cat in await service.GetCategorie())
            {
                Categorie.Add(cat);
            }
            await Aggiorna();
        });

        public Articolo Articolo { get; private set; }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ObservableCollection<Categoria> Categorie { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato
        {
            set
            {
                if (value != articoloSelezionato)
                {
                    Task.Run(async () =>
                    {
                        articoloSelezionato = value;
                        Articolo = await service.GetArticolo(value.Id);
                        RaisePropertyChanged(nameof(Articolo));
                    });
                }
            }
        }

        private async Task Aggiorna()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Articoli.Add(pr);
            }
            Nuovo();
        }

        private void Nuovo()
        {
            Articolo = new Articolo();
            RaisePropertyChanged(nameof(Articolo));
        }

        public void Dispose()
        {
            Cleanup();
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
