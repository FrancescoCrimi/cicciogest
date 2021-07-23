﻿using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class CategoriaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;

        public CategoriaViewModel(ILogger<CategoriaViewModel> logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Categorie = new ObservableCollection<Categoria>();
            SalvaCommand = new RelayCommand(Salva);
            RimuoviCommand = new RelayCommand(Rimuovi);
            NuovoCommand = new RelayCommand(Nuova);
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        public Categoria CategoriaSelezionata { set { Mostra(value); } }

        public ICommand SalvaCommand { get; private set; }
        public ICommand RimuoviCommand { get; private set; }
        public ICommand NuovoCommand { get; private set; }
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand( async () => 
        {
            await Aggiorna();
        }));


        private async void Salva()
        {
            try
            {
                await service.SaveCategoria(Categoria);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private async void Rimuovi()
        {
            try
            {
                await service.DeleteCategoria(Categoria.Id);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void Mostra(Categoria categoria)
        {
            if (categoria != null && categoria != Categoria)
            {
                Categoria = categoria;
                OnPropertyChanged(nameof(Categoria));
            }
        }

        private void Nuova()
        {
            Mostra(new Categoria());
        }

        private async Task Aggiorna()
        {
            Nuova();
            Categorie.Clear();
            foreach (Categoria ca in await service.GetCategorie())
            {
                Categorie.Add(ca);
            }
        }


        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
