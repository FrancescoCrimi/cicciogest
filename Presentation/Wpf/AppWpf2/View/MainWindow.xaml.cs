using CiccioGest.Presentation.AppWpf2.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf2.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegistraMessaggi();
            Closing += MainWindow_Closing;
        }

        private void RegistraMessaggi()
        {
            Messenger.Default.Register<NotificationMessage>(this, ns =>
            {
                if (ns.Notification == "ApriFatturaView")
                {
                     new FatturaView().Show();
                }
                else if (ns.Notification == "ApriSelezionaFatturaView")
                {
                    new ListaFattureView().ShowDialog();
                }
                else if (ns.Notification == "ApriProdotti")
                {
                     new ArticoloView().Show();
                }
                else if (ns.Notification == "ApriCategorie")
                {
                     new CategoriaView().Show();
                }
            });
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Windsor.Release(DataContext);
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }
    }
}
