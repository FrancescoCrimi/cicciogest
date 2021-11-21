using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
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
