using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FattureListView : Page
    {
        public FattureListView(FattureListViewModel fattureDialogViewModel)
        {
            InitializeComponent();
            DataContext = fattureDialogViewModel;
        }
    }
}
