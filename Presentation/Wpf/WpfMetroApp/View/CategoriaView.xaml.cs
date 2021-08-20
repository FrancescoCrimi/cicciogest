using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class CategoriaView : Page
    {
        public CategoriaView(CategoriaViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
