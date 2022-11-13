using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class FornitoriView : Page
    {
        public FornitoriView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<FornitoriViewModel>();
        }
    }
}
