using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class ListaFattureView : Window
    {
        public ListaFattureView()
        {
            InitializeComponent();
            Closing += SelezionaFatturaView_Closing;
        }

        private void SelezionaFatturaView_Closing(object sender, CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
