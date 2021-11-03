using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ListaArticoliView : Page
    {
        public ListaArticoliView(ListaArticoliViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
