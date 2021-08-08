using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClientiView : Window
    {
        public ClientiView(ClientiViewModel clientiViewModel)
        {
            InitializeComponent();
            DataContext = clientiViewModel;
        }
    }
}
