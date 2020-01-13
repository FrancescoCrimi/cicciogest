using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.View
{
    public partial class FatturaView : Page
    {
        public FatturaView()
        {
            InitializeComponent();
            //Closing += FatturaView_Closing;
        }

        private void FatturaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            //App.Windsor.Release(DataContext);
        }
    }
}
