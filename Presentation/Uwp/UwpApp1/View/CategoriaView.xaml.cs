using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
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
