using CiccioGest.Presentation.WinUiApp1.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp1.View
{
    public sealed partial class ListaFattureView : Page
    {
        public ListaFattureView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ListaFattureViewModel>();
        }
    }
}
