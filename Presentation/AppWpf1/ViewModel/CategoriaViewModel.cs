using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf1.ViewModel
{
    public sealed class CategoriaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;

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
                foreach (Categoria ca in service.GetCategorie())
                {
                    Categorie.Add(ca);
                }
                Categoria = service.GetCategoria(4);
            }
            else
            {
                Aggiorna();
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        public Categoria CategoriaSelezionata { set { Mostra(value); } }
        public ICommand SalvaCommand { get; private set; }
        public ICommand RimuoviCommand { get; private set; }
        public ICommand NuovoCommand { get; private set; }


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

        private void Aggiorna()
        {
            Nuova();
            Categorie.Clear();
            foreach (Categoria ca in service.GetCategorie())
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
