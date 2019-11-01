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

namespace CiccioGest.Presentation.AppWpf1.ViewModel
{
    public sealed class CategoriaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;

        public CategoriaViewModel(ILogger logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Categorie = new ObservableCollection<Categoria>();
            SalvaCommand = new RelayCommand(Salva);
            RimuoviCommand = new RelayCommand(Rimuovi);
            NuovoCommand = new RelayCommand(Nuova);

            //if (App.InDesignMode())
            if (IsInDesignModeStatic)
            {
                foreach (Categoria ca in service.GetCategorie().Result)
                {
                    Categorie.Add(ca);
                }
                Categoria = service.GetCategoria(4).Result;
            }
            //else
            //{
            //    Aggiorna();
            //}
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
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


        private void Salva()
        {
            try
            {
                service.SaveCategoria(Categoria);
                Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void Rimuovi()
        {
            try
            {
                service.DeleteCategoria(Categoria.Id);
                Aggiorna();
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
