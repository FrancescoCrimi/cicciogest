//using CiccioGest.Presentation.WpfApp.ViewModel;
using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClientiView : Page
    {
        public ClientiView(ClientiViewModel clientiViewModel)
        {
            InitializeComponent();
            DataContext = clientiViewModel;
        }
    }
}
