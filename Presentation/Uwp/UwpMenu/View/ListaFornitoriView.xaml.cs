using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpMenu.View
{
    public sealed partial class ListaFornitoriView : Page
    {
        public ListaFornitoriView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ListaFornitoriViewModel>();
        }
    }
}
