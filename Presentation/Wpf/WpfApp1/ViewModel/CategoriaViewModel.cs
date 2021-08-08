using CiccioGest.Application;
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

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public sealed class CategoriaViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;
        private ICommand nuovoCommand;
        private ICommand rimuoviCommand;
        private ICommand salvaCommand;

        public CategoriaViewModel(ILogger<CategoriaViewModel> logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Categorie = new ObservableCollection<Categoria>();

            //if (IsInDesignMode)
            //{
            //    foreach (Categoria ca in service.GetCategorie().Result)
            //    {
            //        Categorie.Add(ca);
            //    }
            //    Categoria = service.GetCategoria(4).Result;
            //}
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        public Categoria CategoriaSelezionata { set { Mostra(value); } }

        public ICommand SalvaCommand => salvaCommand ??= new RelayCommand(async () =>
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
        });

        public ICommand RimuoviCommand => rimuoviCommand ??= new RelayCommand(async () =>
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
        });

        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(() => Mostra(new Categoria()));

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () => await Aggiorna());

        private void Mostra(Categoria categoria)
        {
            if (categoria != null && categoria != Categoria)
            {
                Categoria = categoria;
                OnPropertyChanged(nameof(Categoria));
            }
        }

        private async Task Aggiorna()
        {
            Mostra(new Categoria());
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
