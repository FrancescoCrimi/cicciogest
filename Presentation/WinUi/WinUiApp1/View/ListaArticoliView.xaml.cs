using CiccioGest.Presentation.WinUiApp1.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp1.View
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
