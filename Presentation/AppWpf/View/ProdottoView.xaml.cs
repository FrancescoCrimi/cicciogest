using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class ProdottoView : Page
    {
        public ProdottoView()
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
