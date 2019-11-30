using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.View
{
    public partial class ArticoloView : Page
    {
        public ArticoloView()
        {
            InitializeComponent();
            //Closing += ProdottoView_Closing;
        }

        private void ProdottoView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
