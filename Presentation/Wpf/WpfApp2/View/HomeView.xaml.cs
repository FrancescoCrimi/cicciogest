using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.View
{
    public partial class HomeView : Page
    {
        public HomeView(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            DataContext = homeViewModel;
        }
    }
}
