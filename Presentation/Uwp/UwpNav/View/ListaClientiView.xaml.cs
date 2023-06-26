using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpNav.View
{
    public sealed partial class ListaClientiView : Page
    {
        public ListaClientiView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ListaClientiViewModel>();
        }
    }
}
