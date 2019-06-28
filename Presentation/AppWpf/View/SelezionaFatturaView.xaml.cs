using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class SelezionaFatturaView : Window
    {
        public SelezionaFatturaView()
        {
            InitializeComponent();
            Closing += SelezionaFatturaView_Closing;
        }

        private void SelezionaFatturaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            Bootstrap.Windsor.Release(DataContext);
        }
    }
}