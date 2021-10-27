using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ArticoliListView : Page
    {
        public ArticoliListView(ArticoliListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
