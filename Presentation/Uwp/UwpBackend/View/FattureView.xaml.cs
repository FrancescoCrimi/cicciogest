using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpBackend.View
{
    public sealed partial class FattureView : Page
    {
        public FattureView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<FattureViewModel>();
        }
    }
}
