using CiccioGest.Presentation.Wpf.App2.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            RegistraMessaggi();
            Closing += MainWindow_Closing;
        }

        private void RegistraMessaggi()
        {
            Messenger.Default.Register<NotificationMessage>(this, ns =>
            {
                if (ns.Notification == "ApriFatture")
                {
                     new FatturaView().Show();
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

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            App.Windsor.Release(DataContext);
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }
    }
}
