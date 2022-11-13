using CiccioGest.Presentation.WinUiApp1.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp1.View
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
