using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClientiView : Window
    {
        private readonly ClientiViewModel clientiViewModel;

        public ClientiView(ClientiViewModel clientiViewModel)
        {
            InitializeComponent();
            DataContext = clientiViewModel;
            this.clientiViewModel = clientiViewModel;
            clientiViewModel.OnRequestClose += ClientiViewModel_OnRequestClose;
        }

        private void ClientiViewModel_OnRequestClose(object sender, EventArgs e)
        {
            clientiViewModel.OnRequestClose -= ClientiViewModel_OnRequestClose;
            Close();
        }
    }
}
