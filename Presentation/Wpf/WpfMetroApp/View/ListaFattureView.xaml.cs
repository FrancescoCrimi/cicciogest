using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ListaFattureView : Page
    {
        public ListaFattureView(ListaFattureViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
