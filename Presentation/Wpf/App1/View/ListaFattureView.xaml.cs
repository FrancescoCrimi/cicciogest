using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.View
{
    public partial class ListaFattureView : Page
    {
        public ListaFattureView()
        {
            InitializeComponent();
            //Closing += SelezionaFatturaView_Closing;
        }

        private void SelezionaFatturaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            //App.Windsor.Release(DataContext);
        }
    }
}
