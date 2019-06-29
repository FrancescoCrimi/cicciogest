using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class CategoriaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IMagazinoService service;

        public CategoriaViewModel(ILogger logger, IKernel kernel, IMagazinoService service)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            Categorie = new ObservableCollection<Categoria>();
            SalvaCommand = new RelayCommand(salva);
            RimuoviCommand = new RelayCommand(rimuovi);
            NuovoCommand = new RelayCommand(nuova);

            if (IsInDesignMode)
            {
                foreach (Categoria ca in service.GetCategorie())
                {
                    Categorie.Add(ca);
                }
                Categoria = service.GetCategoria(4);
            }
            else
            {
                aggiorna();
            }
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        public Categoria CategoriaSelezionata { set { mostra(value); } }
        public ICommand SalvaCommand { get; private set; }
        public ICommand RimuoviCommand { get; private set; }
        public ICommand NuovoCommand { get; private set; }


        private void salva()
        {
            try
            {
                service.SaveCategoria(Categoria);
                aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void rimuovi()
        {
            try
            {
                service.DeleteCategoria(Categoria.Id);
                aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void mostra(Categoria categoria)
        {
            if (categoria != null && categoria != Categoria)
            {
                Categoria = categoria;
                RaisePropertyChanged("Categoria");
            }
        }

        private void nuova()
        {
            mostra(new Categoria());
        }

        private void aggiorna()
        {
            nuova();
            Categorie.Clear();
            foreach (Categoria ca in service.GetCategorie())
            {
                Categorie.Add(ca);
            }
        }


        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
