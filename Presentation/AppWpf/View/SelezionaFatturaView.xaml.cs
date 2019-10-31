using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class SelezionaFatturaView : Page
    {
        public SelezionaFatturaView()
        {
            InitializeComponent();
            //Closing += SelezionaFatturaView_Closing;
        }

        private void SelezionaFatturaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
