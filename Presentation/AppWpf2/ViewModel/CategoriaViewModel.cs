using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf2.ViewModel
{
    public sealed class CategoriaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;
        private ICommand nuovoCommand;
        private ICommand rimuoviCommand;
        private ICommand salvaCommand;

        public CategoriaViewModel(ILogger logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Categorie = new ObservableCollection<Categoria>();

            if (App.InDesignMode)
            {
                foreach (Categoria ca in service.GetCategorie().Result)
                {
                    Categorie.Add(ca);
                }
                Categoria = service.GetCategoria(4).Result;
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        public Categoria CategoriaSelezionata { set { Mostra(value); } }

        public ICommand SalvaCommand => salvaCommand ?? (salvaCommand = new RelayCommand(async () => await Salva()));
        public ICommand RimuoviCommand => rimuoviCommand ?? (rimuoviCommand = new RelayCommand(async () => await Rimuovi()));
        public ICommand NuovoCommand => nuovoCommand ?? (nuovoCommand = new RelayCommand(Nuova));
        public ICommand LoadedCommand => loadedCommand ??
            (loadedCommand = new RelayCommand( async () => await Aggiorna()));


        private async Task Salva()
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

        private async Task Rimuovi()
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
                RaisePropertyChanged(nameof(Categoria));
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
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
