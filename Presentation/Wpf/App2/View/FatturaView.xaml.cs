using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class FatturaView : Window
    {
        public FatturaView()
        {
            InitializeComponent();
            Registramessaggi();
            Closing += FatturaView_Closing;
        }

        private void Registramessaggi()
        {
            Messenger.Default.Register<NotificationMessage>(this, ns =>
            {
                if (ns.Notification == "SelezionaProdotto")
                {
                    new ListaArticoliView().ShowDialog();
                }
                else if (ns.Notification == "SelezionaFattura")
                {
                    new ListaFattureView().ShowDialog();
                }
            });
        }

        private void FatturaView_Closing(object sender, CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
