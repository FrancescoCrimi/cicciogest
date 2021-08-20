using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ClientiView : Page
    {
        public ClientiView(ClientiViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
