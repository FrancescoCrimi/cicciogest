using CiccioGest.Presentation.WinUiApp1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp1.View
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
