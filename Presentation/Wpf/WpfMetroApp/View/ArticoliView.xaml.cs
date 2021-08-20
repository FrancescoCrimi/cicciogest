using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ArticoliView : Page
    {
        public ArticoliView(ArticoliViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
