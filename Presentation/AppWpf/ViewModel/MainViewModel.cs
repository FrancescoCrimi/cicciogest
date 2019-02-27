using GalaSoft.MvvmLight;
using CiccioGest.Presentation.AppWpf.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using Castle.Core.Logging;
using GalaSoft.MvvmLight.Messaging;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public sealed class MainViewModel : ViewModelBase, IDisposable, ICazzo
    {
        public ICommand ApriFattureCommand { get; private set; }
        public ICommand NuovaFatturaCommand { get; private set; }
        public ICommand ApriProdottiCommand { get; private set; }
        //public ICommand NuovoProdottoCommand { get; private set; }
        public ICommand ApriCategorieCommand { get; private set; }
        private ILogger logger;
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainViewModel(ILogger logger, IDataService dataService)
        {
            this.logger = logger;
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            ApriFattureCommand = new RelayCommand(apriFatture);
            NuovaFatturaCommand = new RelayCommand(nuovaFattura);
            ApriProdottiCommand = new RelayCommand(apriProdotti);
            //NuovoProdottoCommand = new RelayCommand(nuovoProdotto);
            ApriCategorieCommand = new RelayCommand(apriCategorie);
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Created");
        }

        private void apriCategorie()
        {
            MessengerInstance.Send(new NotificationMessage("ApriCategorie"));
        }

        //private void nuovoProdotto()
        //{
        //}

        private void apriProdotti()
        {
            MessengerInstance.Send(new NotificationMessage("ApriProdotti"));
        }

        private void nuovaFattura()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFattura"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdCliente"));
        }

        private void apriFatture()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFattura"));
            MessengerInstance.Send(new NotificationMessage<int>(0, "IdFattura"));
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        public void Dispose()
        {
            Cleanup();
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Disposed");
        }
    }
}