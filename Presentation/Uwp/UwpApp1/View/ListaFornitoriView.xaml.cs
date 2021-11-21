using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
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
