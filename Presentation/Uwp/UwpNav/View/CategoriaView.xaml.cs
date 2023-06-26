using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpNav.View
{
    public sealed partial class CategoriaView : Page
    {
        public CategoriaView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<CategoriaViewModel>();
        }
    }
}
