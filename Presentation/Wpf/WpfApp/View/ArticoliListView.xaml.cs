using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ArticoliListView : Page
    {
        public ArticoliListView(ArticoliListViewModel articoliDialogViewModel)
        {
            InitializeComponent();
            DataContext = articoliDialogViewModel;
        }
    }
}
