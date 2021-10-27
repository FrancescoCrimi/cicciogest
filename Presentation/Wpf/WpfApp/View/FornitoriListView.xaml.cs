using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FornitoriListView : Page
    {
        public FornitoriListView(FornitoriListViewModel fornitoriListViewModel)
        {
            InitializeComponent();
            DataContext = fornitoriListViewModel;
        }
    }
}
