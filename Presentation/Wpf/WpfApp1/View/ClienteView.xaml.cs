using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClienteView : Window
    {
        private readonly ClienteViewModel clienteViewModel;

        public ClienteView(ClienteViewModel clienteViewModel)
        {
            InitializeComponent();
            this.clienteViewModel = clienteViewModel;
            DataContext = clienteViewModel;
            clienteViewModel.OnRequestClose += ClienteViewModel_OnRequestClose;
        }

        private void ClienteViewModel_OnRequestClose(object sender, EventArgs e)
        {
            clienteViewModel.OnRequestClose -= ClienteViewModel_OnRequestClose;
            Close();
        }
    }
}
