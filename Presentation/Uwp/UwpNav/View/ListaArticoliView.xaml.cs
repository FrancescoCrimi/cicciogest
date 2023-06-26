using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpNav.View
{
    public sealed partial class ListaArticoliView : Page
    {
        public ListaArticoliView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ListaArticoliViewModel>();
        }
    }
}
